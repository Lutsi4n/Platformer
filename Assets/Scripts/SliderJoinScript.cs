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
        // ��������� ���������� ������� �����
        if (sliderJoint.limitState == JointLimitState2D.LowerLimit)
        {
            // ���������� ����� ������� �����, ������ ����������� ��������
            movingRight = true;
            SetMotorSpeed(moveSpeed);
        }
        else if (sliderJoint.limitState == JointLimitState2D.UpperLimit)
        {
            // ���������� ������ ������� �����, ������ ����������� ��������
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
