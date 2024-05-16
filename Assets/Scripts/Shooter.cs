using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireSpeed;
    [SerializeField] private Transform firePoint;

    public void Shoot(float direction)
    {
        GameObject currentBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
        Rigidbody2D currrentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();

        if (direction >= 0)
            currrentBulletVelocity.velocity = new Vector2(fireSpeed * 1, currrentBulletVelocity.velocity.y);
        else
            currrentBulletVelocity.velocity = new Vector2(fireSpeed * -1, currrentBulletVelocity.velocity.y);
    }
}
