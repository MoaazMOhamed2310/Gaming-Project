using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crawllingEnemy : MonoBehaviour
{
    public float moveSpeed;
    public GameObject[] wayPoints;

    private int nextWaypoint = 1;
    private float distToPoint;

    // ---------- NEW: Enemy Health ----------
    public int health = 3;

    // ---------- NEW: Attack ----------
    public int damage = 1;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;
    private float attackCooldown = 1f; // time between attacks
    private float lastAttackTime = 0f;

    void Update()
    {
        Move();
        AttackPlayer();
    }

    void Move()
    {
        distToPoint = Vector2.Distance(transform.position, wayPoints[nextWaypoint].transform.position);
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[nextWaypoint].transform.position, moveSpeed * Time.deltaTime);

        if (distToPoint < 0.2f)
        {
            TakeTurn();
        }
    }

    void TakeTurn()
    {
        Vector3 currRot = transform.eulerAngles;
        currRot.z += wayPoints[nextWaypoint].transform.eulerAngles.z;
        transform.eulerAngles = currRot;
        ChooseNextWaypoint();
    }

    void ChooseNextWaypoint()
    {
        nextWaypoint++;
        if (nextWaypoint == wayPoints.Length)
        {
            nextWaypoint = 0;
        }
    }

    // ---------- NEW: Attack Player ----------
    void AttackPlayer()
{
    if (Time.time - lastAttackTime < attackCooldown) return;

    Collider2D playerHit = Physics2D.OverlapCircle(transform.position, attackRange, playerLayer);
    if (playerHit != null)
    {
        PlayerStats player = playerHit.GetComponent<PlayerStats>();
        if (player != null)
        {
            player.TakeDamage(damage);
            lastAttackTime = Time.time;
        }
        else
        {
            Debug.LogWarning("PlayerStats not found on the player object!");
        }
    }
}


    // ---------- NEW: Take Damage ----------
    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Optional: play death animation here
        Destroy(gameObject);
    }

    // Optional: visualize attack range in editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
