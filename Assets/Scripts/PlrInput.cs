using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlrMovement))]
[RequireComponent(typeof(Shooter))]
public class PlrInput : MonoBehaviour
{
    private PlrMovement plrMovement;
    private Shooter shooter;

    private void Awake()
    {
        plrMovement= GetComponent<PlrMovement>();
        shooter = GetComponent<Shooter>();
    }

    private void FixedUpdate()
    {
        float horizontalDirection = Input.GetAxis(Const.HORIZONTAL_AXIS);
        bool isJumpBtnPrssd = Input.GetButtonDown(Const.JUMP);

        if (Input.GetButtonDown(Const.FIRE_1))
        {
            shooter.Shoot(horizontalDirection);
        }

        plrMovement.Move(horizontalDirection, isJumpBtnPrssd);
    }
}
