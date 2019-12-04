﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subir_puente2 : MonoBehaviour
{
    public GameObject puenteIz;
    public GameObject puenteDer;
    private HingeJoint2D jointRefIzq;
    private JointMotor2D motorRefIzq;
    private JointAngleLimits2D LimitRefIzq;

    private HingeJoint2D jointRefDer;
    private JointMotor2D motorRefDer;
    private JointAngleLimits2D LimitRefDer;

    private bool activado = false;

    // Start is called before the first frame update
    void Start()
    {
        jointRefIzq = puenteIz.GetComponent<HingeJoint2D>();
        motorRefIzq = jointRefIzq.motor;
        LimitRefIzq = jointRefIzq.limits;

        jointRefDer = puenteDer.GetComponent<HingeJoint2D>();
        motorRefDer = jointRefDer.motor;
        LimitRefDer = jointRefDer.limits;
    }

    void OnTriggerEnter2D()
    {
        if (!activado)
        {
            motorRefIzq.motorSpeed = -100;
            jointRefIzq.motor = motorRefIzq;
            LimitRefIzq.max = 0;
            LimitRefIzq.min = 0;
            jointRefIzq.limits = LimitRefIzq;

            motorRefDer.motorSpeed = +100;
            jointRefDer.motor = motorRefDer;
            LimitRefDer.max = 0;
            LimitRefDer.min = 0;
            jointRefDer.limits = LimitRefDer;
            activado = true;
        }
    }
}