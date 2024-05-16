using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRun : MonoBehaviour
{
    [SerializeField] private float speed, timeToRevert;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sp;
    private Rigidbody2D rb;
    private const float IDLE_STATE = 0;
    private const float WALK_STATE = 1;
    private const float REVERT_STATE = 2;
    private float currentState, currentTimeToRevert;

    private void Start()
    {
        currentState = WALK_STATE;
        currentTimeToRevert = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (currentTimeToRevert >= timeToRevert)
        {
            currentTimeToRevert = 0;
            currentState = REVERT_STATE;
        }

        switch (currentState)
        {
            case IDLE_STATE:
                currentTimeToRevert += Time.deltaTime;
                break;

            case WALK_STATE:
                rb.velocity = Vector2.right * speed;
                break;

            case REVERT_STATE:
                sp.flipX = !sp.flipX;
                speed *= -1;
                currentState = WALK_STATE;
                break;

        }

        anim.SetFloat("Velocity", rb.velocity.magnitude);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("zone"))
        {
            currentState = IDLE_STATE;
        }
    }
}
