using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : EnemyController
{
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.flipX = false;
    }

    void FixedUpdate()
    {
        if (sr.flipX == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Attack player on collision
            PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }
}