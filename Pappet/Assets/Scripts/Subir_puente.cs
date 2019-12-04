using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subir_puente : MonoBehaviour
{
    public GameObject puenteIz;
    public GameObject puenteDer;
    private Rigidbody2D rb2dIzq;
    private HingeJoint2D jointRefIzq;
    private JointMotor2D motorRefIzq;
    private Rigidbody2D rb2dDer;
    private HingeJoint2D jointRefDer;
    private JointMotor2D motorRefDer;

    void Start()
    {
        rb2dIzq = puenteIz.GetComponent<Rigidbody2D>();
        jointRefIzq = puenteIz.GetComponent<HingeJoint2D>();
        motorRefIzq = jointRefIzq.motor;

        rb2dDer = puenteDer.GetComponent<Rigidbody2D>();
        jointRefDer = puenteDer.GetComponent<HingeJoint2D>();
        motorRefDer = jointRefDer.motor;
    }

    void OnTriggerEnter2D()
    {
        motorRefIzq.motorSpeed = 30;
        jointRefIzq.motor= motorRefIzq;

        motorRefDer.motorSpeed = -30;
        jointRefDer.motor= motorRefDer;
    }
}