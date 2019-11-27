using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public GameObject body;
    public float force;
    public float armSpeed;
    public Vector2 torsoAngles;
    public Vector2 headAngles;
    public Vector2 armAngles;
    public Vector2 foreArmsAngles;
    public Vector2 legsAngles;
    public Vector2 footsAngles;
    [Header("Flexed Angles")]
    public Vector2 torsoFlexedAngles;
    public Vector2 armFlexedAngles;
    public Vector2 forearmFlexedAngles;


    private GameObject torso, head, rightArm, rightHand, leftArm, leftHand, rightLeg, rightFoot, leftLeg, leftFoot;
    // Start is called before the first frame update
    void Start()
    {
        //Pillamos todos los gameobjects que tienen partes del cuerpo
        torso = body.transform.GetChild(0).gameObject;
        head = torso.transform.GetChild(0).gameObject;
        rightArm = torso.transform.GetChild(1).gameObject;
            rightHand = rightArm.transform.GetChild(0).gameObject;
        leftArm =  torso.transform.GetChild(2).gameObject;
            leftHand = leftArm.transform.GetChild(0).gameObject;
        rightLeg = torso.transform.GetChild(3).gameObject;
            rightFoot = rightLeg.transform.GetChild(0).gameObject;
        leftLeg = torso.transform.GetChild(4).gameObject;
            leftFoot = leftLeg.transform.GetChild(0).gameObject;

        //DebugBodyParts();
        SetAllJointsMovility();
        StartCoroutine(CharacterControlCoroutine());
    }

    void DebugBodyParts()
    {
        Debug.Log("body: " + body.name);
        Debug.Log("torso: " + torso.name);
        Debug.Log("head: " + head.name);
        Debug.Log("rightArm: " + rightArm.name);
        Debug.Log("rightHand: " + rightHand.name);
        Debug.Log("leftArm: " + leftArm.name);
        Debug.Log("leftHand: " + leftHand.name);
        Debug.Log("rightLeg: " + rightLeg.name);
        Debug.Log("rightFoot: " + rightFoot.name);
        Debug.Log("leftLeg: " + leftLeg.name);
        Debug.Log("leftFoot: " + leftFoot.name);
    }

    void SetFeetWeights(float weight)
    {
        //Anchor Feet
        leftFoot.GetComponent<Rigidbody2D>().mass = weight;
        rightFoot.GetComponent<Rigidbody2D>().mass = weight;
    }

    void SetAllJointsMovility()
    {
        //Torso
        setJointMovility(torso.GetComponent<HingeJoint2D>(), torsoAngles.x, torsoAngles.y);
        //Head
        setJointMovility(head.GetComponent<HingeJoint2D>(), headAngles.x, headAngles.y);
        //Arms and hands
        setJointMovility(leftArm.GetComponent<HingeJoint2D>(), armAngles.x, armAngles.y);
        setJointMovility(rightArm.GetComponent<HingeJoint2D>(), -armAngles.x, -armAngles.y);
        setJointMovility(leftHand.GetComponent<HingeJoint2D>(), foreArmsAngles.x, foreArmsAngles.y);
        setJointMovility(rightHand.GetComponent<HingeJoint2D>(), -foreArmsAngles.x, -foreArmsAngles.y);
        //Legs and feet
        setJointMovility(leftLeg.GetComponent<HingeJoint2D>(), 0, 0);
        setJointMovility(rightLeg.GetComponent<HingeJoint2D>(), 0,0);
        setJointMovility(leftFoot.GetComponent<HingeJoint2D>(), 0, 0);
        setJointMovility(rightFoot.GetComponent<HingeJoint2D>(), 0, 0);

        //setJointMovility(leftLeg.GetComponent<HingeJoint2D>(), 0, 90);
        //setJointMovility(rightLeg.GetComponent<HingeJoint2D>(), 90, 180);
        //setJointMovility(leftFoot.GetComponent<HingeJoint2D>(), 90, 180);
        //setJointMovility(rightFoot.GetComponent<HingeJoint2D>(), 0, 90);

        //setFootJointMovility(leftFoot.GetComponent<HingeJoint2D>(), footsAngles.x, footsAngles.y);
        //setFootJointMovility(rightFoot.GetComponent<HingeJoint2D>(), -footsAngles.x, -footsAngles.y);
    }
    // Update is called once per frame
    void Update()
    {
    }


    void setJointMovility(HingeJoint2D joint, float minAngle, float maxAngle)
    {
        JointAngleLimits2D limits = joint.limits;
        limits.min = minAngle; limits.max = maxAngle;
        joint.limits = limits;
    }

    public IEnumerator CharacterControlCoroutine()
    {
        do
        {
            float xAxis = Input.GetAxis("Horizontal");
            float yAxis = Input.GetAxis("Vertical");
            Vector2 dir = new Vector2(0, 1);
            // JointMotor2D motor = rightArm.GetComponent<HingeJoint2D>().motor;
            if (Input.GetMouseButtonDown(0))
            {

            }
            else
            {
 
            }
            

            Vector2 armDir, handDir;
            armDir = new Vector2(0, 1);
            handDir = new Vector2(1, 1);
            if(xAxis > 0.0f)
            {
                //Set de angulos flexionados
                setJointMovility(rightArm.GetComponent<HingeJoint2D>(),
                                    armFlexedAngles.x, armFlexedAngles.y);
                setJointMovility(rightHand.GetComponent<HingeJoint2D>(),
                                    forearmFlexedAngles.x, forearmFlexedAngles.y);

                setJointMovility(torso.GetComponent<HingeJoint2D>(), torsoFlexedAngles.x, torsoFlexedAngles.y);
                //Set de fuerzas
                //torso.GetComponent<Rigidbody2D>().AddForce(Vector2.right * armSpeed);
                Quaternion q = body.transform.rotation;
                if(q.eulerAngles.z < 20.0f)
                {
                    q.eulerAngles += new Vector3(0, 0, armSpeed * 0.1f);
                    body.transform.rotation = q;
                }
            
                rightArm.GetComponent<Rigidbody2D>().AddForce(armDir * armSpeed);
                rightHand.GetComponent<Rigidbody2D>().AddForce(new Vector2(-handDir.x ,handDir.y) * armSpeed);
            }
            else if(xAxis < 0.0f)
            {
                //Set de angulos flexionados
                setJointMovility(leftHand.GetComponent<HingeJoint2D>(),
                          -forearmFlexedAngles.x, -forearmFlexedAngles.y);
                setJointMovility(leftArm.GetComponent<HingeJoint2D>(),
                          -armFlexedAngles.x, -armFlexedAngles.y);
                setJointMovility(torso.GetComponent<HingeJoint2D>(), -torsoFlexedAngles.x, -torsoFlexedAngles.y);
                //Set de fuerzas
                leftArm.GetComponent<Rigidbody2D>().AddForce(armDir * armSpeed);
                leftHand.GetComponent<Rigidbody2D>().AddForce(handDir* armSpeed);
            }
            else
            {
                setJointMovility(torso.GetComponent<HingeJoint2D>(), torsoAngles.x, torsoAngles.y);

                setJointMovility(rightArm.GetComponent<HingeJoint2D>(), -armAngles.x, -armAngles.y);
                setJointMovility(leftArm.GetComponent<HingeJoint2D>(), armAngles.x, armAngles.y);

                setJointMovility(rightHand.GetComponent<HingeJoint2D>(), foreArmsAngles.x, foreArmsAngles.y);
                setJointMovility(leftHand.GetComponent<HingeJoint2D>(), foreArmsAngles.x, foreArmsAngles.y);
            }
            if (yAxis < 0.0f) //Agacharse
            {
               
                //torso.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -10.0f);
            }

            if (yAxis > 0.0f) //Estirarse
            {
                //torso.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10.0f);
            }
            else
            {
                //torso.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            yield return null;
        } while (true);

    }

    /*
    void setFootJointMovility(HingeJoint2D joint, float minAngle, float maxAngle)
    {
        Transform foot = joint.gameObject.transform;
        Transform leg = joint.gameObject.transform.parent;

        float angle = Quaternion.Angle(leg.rotation, foot.rotation);
        angle = foot.localRotation.z;

        Debug.Log("Angle de " + joint.gameObject.name + ": " + angle);
        JointAngleLimits2D limits = joint.limits;
        limits.min = leg.GetComponent<HingeJoint2D>().limits.min;
        limits.max = Mathf.Abs(Mathf.Abs(maxAngle) - Mathf.Abs(angle));
        if (maxAngle < 0.0f) limits.max *= -1;
        joint.limits = limits;
    }
    */
}
