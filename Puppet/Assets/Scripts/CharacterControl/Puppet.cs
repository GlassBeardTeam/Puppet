﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum BodyParts
{
    CABEZA,
    TORSO,
    BRAZO_IZ,
    BRAZO_DER,
    MANO_IZ,
    MANO_DER,
    PIERNA_IZ,
    PIERNA_DER,
    PIE_IZ,
    PIE_DER
}

public class Puppet : MonoBehaviour
{
    [Range(0.1f, 5.0f)]
    public float maxLegFlexTime;
    [Range(1000.0f, 9999.0f)]
    public float maxJumpForce;

    GameObject[] bodyParts;
    public Muscle[] muscles;
    private Vector2[] initLocalPositions;
    private bool isGrounded = true;

    private bool keepMoving = true;
    // Start is called before the first frame update
    void Start()
    {
        SetBodyParts();
        Ignore_torso_hands_collision();
        StartCoroutine(VerticalMovement());
        StartCoroutine(HorizontalMovement());
    }

    // Update is called once per frame
    void Update()
    {
        ActiveMuscles();
    }

    IEnumerator HorizontalMovement()
    {
        while(keepMoving)
        {
            //MOVIMIENTO HORIZONTAL
            float horiz = Input.GetAxis("Horizontal");
            if (horiz > 0.0f)
            {
                FlexRight();
            }
            else if (horiz < 0.0f)
            {
                FlexLeft();
            }
            else
            {
                RelaxTargetMuscles(new[]{(int)BodyParts.TORSO, (int)BodyParts.BRAZO_IZ,
                (int)BodyParts.BRAZO_DER, (int)BodyParts.MANO_IZ, (int)BodyParts.MANO_DER});
            }
            yield return null;
        }
       

    }
    IEnumerator VerticalMovement()
    {
        float flexedTime = 0.0f;
        //Guardamos las rotaciones de las piernas en variables
        float relaxedLegRot_right = muscles[(int)BodyParts.PIERNA_DER].restingRot;
        float flexedLegRot_right = muscles[(int)BodyParts.PIERNA_DER].flexedRot;
        float relaxedLegRot_left = muscles[(int)BodyParts.PIERNA_IZ].restingRot;
        float flexedLegRot_left = muscles[(int)BodyParts.PIERNA_IZ].flexedRot;
        //Seteamos la rotacion flexionada de las piernas a la de reposo
        muscles[(int)BodyParts.PIERNA_DER].flexedRot = relaxedLegRot_right;
        muscles[(int)BodyParts.PIERNA_IZ].flexedRot = relaxedLegRot_left;

        //Guardamos los rigidBody para acceder a su rotacion posteriormente
        Rigidbody2D rb_right = bodyParts[(int)BodyParts.PIERNA_DER].GetComponent<Rigidbody2D>();
        Rigidbody2D rb_left = bodyParts[(int)BodyParts.PIERNA_IZ].GetComponent<Rigidbody2D>();
        //Guardamos el rigidbody del torso para lanzarlo posteriormente
        Rigidbody2D rb_torso = bodyParts[(int)BodyParts.TORSO].GetComponent<Rigidbody2D>();

        while (keepMoving)
        {
            //MOVIMIENTO VERTICAL
            float vert = Input.GetAxis("Vertical");
            if (vert < 0.0f)
            {
                flexedTime += Time.deltaTime;
                //Aumentamos la rotacion
                float rotPercentage = flexedTime / maxLegFlexTime;
                Mathf.Clamp01(rotPercentage);
                rb_left.rotation = Mathf.Lerp(rb_left.rotation, flexedLegRot_left, rotPercentage);
                rb_right.rotation = Mathf.Lerp(rb_right.rotation, flexedLegRot_right, rotPercentage);
            }
            else
            {
             
                if(flexedTime != 0.0f)
                {
                    float rotPercentage = flexedTime / maxLegFlexTime;
                    JumpWithForce(rb_torso, Mathf.Clamp01(rotPercentage));
                }
                flexedTime = 0.0f; //reset del tiempo flexionado
                //Relajamos musculos
                RelaxTargetMuscles(new[]{(int)BodyParts.PIERNA_IZ, (int)BodyParts.PIERNA_DER,
                (int)BodyParts.PIE_IZ, (int)BodyParts.PIE_DER });
            }

            yield return null;
        }
    }
    void JumpWithForce(Rigidbody2D rb_torso, float rotPercentage)
    {
        float rot = rb_torso.rotation;
        float radiansRot = rot * Mathf.PI / 180.0f;
        float x = Mathf.Cos(radiansRot);
        float y = Mathf.Sin(radiansRot);
        /*
         El vector es y,x en vez de x,y porque el torso ya esta en
         90 respecto al mundo, aunque para nosotros este a 0
         El signo '-' de la y es porque los angulos van al reves:
         negativos a la derecha y positivos a la izquierda
        */
        Vector2 jumpDir = new Vector2(-y, x);
        float totalJumpForce = maxJumpForce * rotPercentage;
        rb_torso.AddForce(jumpDir * totalJumpForce);

    }
    void ActiveMuscles()
    {
        foreach (Muscle m in muscles)
        {
            m.ActiveMuscle();
        }
    
    }

    void RelaxTargetMuscles(int[] relaxMuscles)
    {
        for(int i = 0; i< relaxMuscles.Length; i++)
        {
            int index = relaxMuscles[i];
            muscles[index].isFlexed = false;
        }
    }

    void FlexRight()
    {
        muscles[(int)BodyParts.BRAZO_DER].isFlexed = true;
        muscles[(int)BodyParts.MANO_DER].isFlexed = true;
        muscles[(int)BodyParts.TORSO].isFlexed = true;

        float flexedRot = muscles[(int)BodyParts.TORSO].flexedRot;
        muscles[(int)BodyParts.TORSO].flexedRot = -Mathf.Abs(flexedRot);
    }

    void FlexLeft()
    {
        muscles[(int)BodyParts.BRAZO_IZ].isFlexed = true;
        muscles[(int)BodyParts.MANO_IZ].isFlexed = true;
        muscles[(int)BodyParts.TORSO].isFlexed = true;

        
        float flexedRot = muscles[(int)BodyParts.TORSO].flexedRot;
        muscles[(int)BodyParts.TORSO].flexedRot = Mathf.Abs(flexedRot);
    }

    void SetBodyParts()
    {
        bodyParts = new GameObject[System.Enum.GetNames(typeof(BodyParts)).Length];
        for (int i = 0; i< bodyParts.Length; i++)
        {
            bodyParts[i] = this.transform.GetChild(i).gameObject;
        }
    
    }

    void DisableCollisions()
    {
        for (int i = 0; i < bodyParts.Length; i++)
        {
            Collider2D target = bodyParts[i].GetComponent<Collider2D>();
            for (int j = 0; j < bodyParts.Length; j++)
            {
                Collider2D current = bodyParts[j].GetComponent<Collider2D>();
                Physics2D.IgnoreCollision(target, current);
            }
                
        }
    }
    void Ignore_torso_hands_collision()
    {
        Collider2D torso_collider = bodyParts[(int)BodyParts.TORSO].GetComponent<Collider2D>();
        Collider2D left_hand_collider = bodyParts[(int)BodyParts.MANO_IZ].GetComponent<Collider2D>();
        Collider2D right_hand_collider = bodyParts[(int)BodyParts.MANO_DER].GetComponent<Collider2D>();

        Physics2D.IgnoreCollision(torso_collider, left_hand_collider);
        Physics2D.IgnoreCollision(torso_collider, right_hand_collider);
    }
}
