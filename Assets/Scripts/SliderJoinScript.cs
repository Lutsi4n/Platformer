using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderJoinScript : MonoBehaviour
{
    public SliderJoint2D sliderJoint;
    public float moveSpeed = 5f;
    public bool movingRight = true;

    private JointMotor2D motor;

    void Start()
    {
        motor = sliderJoint.motor;
    }

    void FixedUpdate()
    {
        // ѕровер€ем достижение крайних точек
        if (sliderJoint.limitState == JointLimitState2D.LowerLimit)
        {
            // ƒостигнута лева€ крайн€€ точка, мен€ем направление движени€
            movingRight = true;
            SetMotorSpeed(moveSpeed);
        }
        else if (sliderJoint.limitState == JointLimitState2D.UpperLimit)
        {
            // ƒостигнута права€ крайн€€ точка, мен€ем направление движени€
            movingRight = false;
            SetMotorSpeed(-moveSpeed);
        }
    }

    void SetMotorSpeed(float speed)
    {
        motor.motorSpeed = speed;
        sliderJoint.motor = motor;
    }
}
