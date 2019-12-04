using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subir_compuerta : MonoBehaviour
{
    public GameObject compuerta;
    private HingeJoint2D jointRef;
    private JointMotor2D motorRef;
    private JointAngleLimits2D LimitRef;
    private bool activado = false;


    void Start()
    {
        jointRef = compuerta.GetComponent<HingeJoint2D>();
        motorRef = jointRef.motor;
        LimitRef = jointRef.limits;
    }

    void OnTriggerEnter2D()
    {
        if (!activado)
        {
            motorRef.motorSpeed = 40;
            jointRef.motor = motorRef;
            activado = true;
        }
    }
}
