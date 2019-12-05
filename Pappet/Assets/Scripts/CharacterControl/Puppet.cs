using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


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
    private static Puppet instance_;
    public static Puppet Instace_
    {
        get
        {
            return instance_;
        }
    }
    [Range(0.1f, 5.0f)]
    public float maxLegFlexTime;
    [Range(1000.0f, 2000.0f)]
    public float minJumpForce;
    [Range(1000.0f, 10000.0f)]
    public float maxJumpForce;
    [Range(0.0f, 100.0f)]
    public float horizontalForce;

    public TouchControls inputHandler;
    private float horizontalInput;
    private float verticalInput;

    public GameObject[] bodyParts;
    public Muscle[] muscles;

    MenuController stickerMenuController;

    private Vector2[] initLocalPositions;
    //Grounded variables
    private bool isGrounded = true;

    private bool keepMoving = true;
    // Start is called before the first frame update
    void Start()
    {

        Object prefab = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Prefabs/MenuController.prefab", typeof(MenuController));
        stickerMenuController = Instantiate(prefab) as MenuController;

        instance_ = this;
        SetBodyParts();
        setStickers();
        Ignore_torso_hands_collision();
        Ignore_FeetBodyCollisions();
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
            horizontalInput = inputHandler.horizontalInput;
            Rigidbody2D rb_torso = bodyParts[(int)BodyParts.TORSO].GetComponent<Rigidbody2D>();
            float horiz = Mathf.Clamp(Input.GetAxis("Horizontal") + horizontalInput, -1, 1);
            Vector3 horizontalDir = new Vector3(1,0,0);
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
            if (!IsGrounded())
            {
                float f = horizontalForce * horiz;
                rb_torso.AddForce(horizontalDir * f);
                //rb_torso.velocity = horizontalDir * f;
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

        //Guardamos los rigidbody de los pies para cambiar su friccion
        Rigidbody2D rb_foot_right = bodyParts[(int)BodyParts.PIERNA_DER].GetComponent<Rigidbody2D>();
        Rigidbody2D rb_foot_left = bodyParts[(int)BodyParts.PIERNA_IZ].GetComponent<Rigidbody2D>();
        while (keepMoving)
        {
            //MOVIMIENTO VERTICAL
            verticalInput = inputHandler.verticalInput;
            float vert = Mathf.Clamp(Input.GetAxis("Vertical") + verticalInput, -1, 1);
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
             
                //Condicion de saltar
                if(flexedTime != 0.0f && IsGrounded())
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
    bool IsGrounded()
    {
        BoxCollider2D foot_right = bodyParts[(int)BodyParts.PIE_DER].GetComponent<BoxCollider2D>();
        BoxCollider2D foot_left = bodyParts[(int)BodyParts.PIE_IZ].GetComponent<BoxCollider2D>();

        CapsuleCollider2D right = bodyParts[(int)BodyParts.PIE_DER].GetComponent<CapsuleCollider2D>();
        CapsuleCollider2D left = bodyParts[(int)BodyParts.PIE_IZ].GetComponent<CapsuleCollider2D>();
        ContactFilter2D cf = new ContactFilter2D();
        Collider2D[] results = new Collider2D[12];

        int size = foot_right.OverlapCollider(cf.NoFilter(), results);
        isGrounded = true;
        if(!CheckIfCollidesSomethingMore(results, size))
        {
            results = new Collider2D[12];
            size = foot_left.OverlapCollider(cf.NoFilter(), results);
            if(!CheckIfCollidesSomethingMore(results, size))
            {
                isGrounded = false;
            }
        }
        return isGrounded;
    }
    bool CheckIfCollidesSomethingMore(Collider2D[] results, int size)
    {
        for(int i = 0; i< bodyParts.Length; i++)
        {
            Collider2D part = bodyParts[i].GetComponent<Collider2D>();
            for (int j = 0; j < size; j++)
            {
                Collider2D r = results[j];
                if (r.gameObject.tag != part.gameObject.tag)
                {
                    return true;
                }
            }
        }
        return false;
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
        if(totalJumpForce < minJumpForce) { totalJumpForce = minJumpForce; }
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

    public void FlexRight()
    {
        muscles[(int)BodyParts.BRAZO_DER].isFlexed = true;
        muscles[(int)BodyParts.MANO_DER].isFlexed = true;
        muscles[(int)BodyParts.TORSO].isFlexed = true;

        float flexedRot = muscles[(int)BodyParts.TORSO].flexedRot;
        muscles[(int)BodyParts.TORSO].flexedRot = -Mathf.Abs(flexedRot);
    }

    public void FlexLeft()
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

    void setStickers()
    {
        for(int i = 0; i < bodyParts.Length; i++)
        {
            Texture2D tex = stickerMenuController.stickerDict[(Pieza)i][PlayerPrefs.GetInt(i.ToString())];
            bodyParts[i].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create(tex,
                                                                                    new Rect(0, 0, tex.width, tex.height),
                                                                                    new Vector2(0.5f, 0.5f),
                                                                                    100);
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
    void Ignore_FeetBodyCollisions()
    {
        //Ignore foot collision with all body parts
        BoxCollider2D right = bodyParts[(int)BodyParts.PIE_DER].GetComponent<BoxCollider2D>();
        BoxCollider2D left = bodyParts[(int)BodyParts.PIE_IZ].GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(right, left);
        for (int i = 0; i < bodyParts.Length; i++)
        {
            Collider2D[] colliders = bodyParts[i].GetComponents<Collider2D>();
            foreach (Collider2D c in colliders)
            {
                Physics2D.IgnoreCollision(right, c);
                Physics2D.IgnoreCollision(left, c);
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
