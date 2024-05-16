using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealler : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Damagable"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }

        if (!collision.CompareTag("Damagable") && !collision.CompareTag("newLayer") && !!collision.CompareTag("DeathTr") && !collision.CompareTag("NextLvl"))
        {
            Destroy(gameObject);
        }
    }
}
