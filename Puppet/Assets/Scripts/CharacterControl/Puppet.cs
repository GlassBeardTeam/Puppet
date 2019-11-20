using System.Collections;
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
    GameObject[] bodyParts;
    public Muscle[] muscles;
    private Vector2[] initLocalPositions;
    private bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        
        SetBodyParts();
        SetLocalPositions();
        //StartCoroutine(CheckGrounded());
        //DisableCollisions();
    }



    // Update is called once per frame
    void Update()
    {
        ActiveMuscles();
    }

    void ActiveMuscles()
    {
        foreach (Muscle m in muscles)
        {
            m.ActiveMuscle();
        }
        if(Input.GetKey(KeyCode.W))
        {
            //ArmsFlex();
        }
        else
        {
            //RelaxMuscles();
        }
    }
    void ArmsFlex()
    {
        muscles[(int)BodyParts.BRAZO_DER].isFlexed = true;
        muscles[(int)BodyParts.BRAZO_IZ].isFlexed = true;
        muscles[(int)BodyParts.MANO_DER].isFlexed = true;
        muscles[(int)BodyParts.MANO_IZ].isFlexed = true;
    }

    void RelaxMuscles()
    {
        foreach(Muscle m in muscles)
        {
            m.isFlexed = false;
        }
    }
    void SetLocalPositions()
    {
        initLocalPositions = new Vector2[bodyParts.Length];
        for(int i = 0; i< initLocalPositions.Length; i++)
        {
            initLocalPositions[i] = bodyParts[i].transform.localPosition;
        }
    }

    void Flex(BodyParts bp, Vector2 direction, float force)
    {
        Rigidbody2D bone = bodyParts[(int)(bp)].transform.GetComponent<Rigidbody2D>();
        bone.AddForce(force * direction);
        
    }

    void SetBodyParts()
    {
        bodyParts = new GameObject[System.Enum.GetNames(typeof(BodyParts)).Length];
        for (int i = 0; i< bodyParts.Length; i++)
        {
            bodyParts[i] = this.transform.GetChild(i).gameObject;
        }
    
    }

    IEnumerator CheckGrounded()
    {
        Collider2D floor = GameObject.Find("floor").transform.GetComponent<Collider2D>();
        Collider2D leftFoot = bodyParts[(int)BodyParts.PIERNA_IZ].transform.GetComponent<Collider2D>();
        Collider2D rightFoot = bodyParts[(int)BodyParts.PIERNA_IZ].transform.GetComponent<Collider2D>();

     ;
        do
        {
            if (leftFoot.IsTouching(floor) && leftFoot.IsTouching(floor))
            {
                isGrounded = true;
            }else
            {
                isGrounded = false;
                //poner bien
                Debug.Log("Poner bien el puppet");
                
            }
            yield return new WaitForSeconds(2.0f);
        } while (true);
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

}
