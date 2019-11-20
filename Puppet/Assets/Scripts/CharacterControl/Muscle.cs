using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Muscle
{
    public Rigidbody2D bone;
    public float restingRot;
    public float restForce;
    public float flexedRot;
    public float flexForce;
    public bool isFlexed;

    public void ActiveMuscle()
    {
        bone.MoveRotation(Mathf.LerpAngle(bone.rotation, restingRot, restForce * Time.deltaTime));
        /*
        if (!isFlexed)
        {
            bone.MoveRotation(Mathf.LerpAngle(bone.rotation, restingRot, restForce * Time.deltaTime));
        }
        else
        {
            bone.MoveRotation(Mathf.LerpAngle(bone.rotation, flexedRot, flexForce * Time.deltaTime));
        }
        */
    }


}
