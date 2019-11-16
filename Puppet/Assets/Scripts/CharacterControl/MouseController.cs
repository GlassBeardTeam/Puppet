using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public float force;
    [Range(0.0f, 1.0f)]
    float armsDeadZone;

    public Vector2 legsAngles;
    public Vector2 footsAngles;

    private GameObject body, torso, head, rightArm, rightHand, leftArm, leftHand, rightLeg, rightFoot, leftLeg, leftFoot;
    // Start is called before the first frame update
    void Start()
    {
        //Pillamos todos los gameobjects que tienen partes del cuerpo
        body = transform.GetChild(0).gameObject;
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

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        Vector2 dir = new Vector2(0,1);
        // JointMotor2D motor = rightArm.GetComponent<HingeJoint2D>().motor;
        if(Input.GetMouseButtonDown(0))
            head.GetComponent<Rigidbody2D>().velocity = dir*force;

 
            setJointMovility(leftLeg.GetComponent<HingeJoint2D>(), legsAngles.x, legsAngles.y);
            setJointMovility(rightLeg.GetComponent<HingeJoint2D>(), legsAngles.x, legsAngles.y);
            setFootJointMovility(leftFoot.GetComponent<HingeJoint2D>(), footsAngles.x, footsAngles.y);
            setFootJointMovility(rightFoot.GetComponent<HingeJoint2D>(), -footsAngles.x, -footsAngles.y);
    }


    void setJointMovility(HingeJoint2D joint, float minAngle, float maxAngle)
    {
        JointAngleLimits2D limits = joint.limits;
        limits.min = minAngle;   limits.max = maxAngle;
        joint.limits = limits;
    }
    void setFootJointMovility(HingeJoint2D joint, float minAngle, float maxAngle)
    {
        Transform foot = joint.gameObject.transform;
        Transform leg = joint.gameObject.transform.parent;

        float angle = Quaternion.Angle(leg.rotation, foot.rotation);
        angle = foot.localRotation.z;

        Debug.Log("Angle de " + joint.gameObject.name + ": " + angle);
        JointAngleLimits2D limits = joint.limits;
        limits.min = leg.GetComponent<HingeJoint2D>().limits.min;
        limits.max = Mathf.Abs(maxAngle) - Mathf.Abs(angle);
        if (maxAngle < 0.0f) limits.max *= -1;
        joint.limits = limits;


    }
}
