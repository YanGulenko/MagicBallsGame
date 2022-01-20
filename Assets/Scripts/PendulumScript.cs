using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumScript : MonoBehaviour
{
    private HingeJoint pj;
    private JointMotor motor;
    // Start is called before the first frame update
    void Start()
    {
        pj = GetComponent<HingeJoint>();
        motor = pj.motor;
    }

    // Update is called once per frame
    void Update()
    {
        if (pj.angle >= pj.limits.max) { motor.targetVelocity = -150; pj.motor = motor; }
        if (pj.angle <= pj.limits.min) { motor.targetVelocity = 150; pj.motor = motor; }
    }
}
