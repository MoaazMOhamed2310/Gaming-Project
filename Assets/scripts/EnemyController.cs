using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxSpeed = 2;
    public int damage = 1;
    public SpriteRenderer sr;
    public int health = 3;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    private float attackCooldown = 1f;
    private float lastAttackTime = 0f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // This makes ALL enemies attack player when in range
        AttackPlayer();
    }

    public void AttackPlayer()
    {
        // Can't attack if on cooldown
        if (Time.time - lastAttackTime < attackCooldown) return;

        // Check if player is in attack range
        Collider2D playerHit = Physics2D.OverlapCircle(transform.position, attackRange, playerLayer);
        if (playerHit != null)
        {
            PlayerStats player = playerHit.GetComponent<PlayerStats>();
            if (player != null)
            {
                player.TakeDamage(damage);
                lastAttackTime = Time.time;
                Debug.Log("Enemy attacked player!");
            }
        }
    }

    public void Flip()
    {
        sr.flipX = !sr.flipX;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerStats player = other.GetComponent<PlayerStats>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
            Flip();
        }
        else if (other.tag == "Wall")
        {
            Flip();
        }
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            health = 0;
        }
        if (health == 0)
        {
            Debug.Log("Enemy Finished");
            PlayerStats.score = PlayerStats.score + 10;
            Destroy(gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}