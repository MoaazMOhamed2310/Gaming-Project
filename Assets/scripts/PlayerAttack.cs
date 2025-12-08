using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 1;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    private float attackCooldown = 0.5f;
    private float lastAttackTime = 0f;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void DoAttack()
    {
        if (Time.time - lastAttackTime < attackCooldown) return;

        lastAttackTime = Time.time;

        // Fix: Attack in the direction player is facing
        // If sprite is flipped (facing left), attack left. If not flipped (facing right), attack right
        Vector2 attackDirection = sr.flipX ? Vector2.left : Vector2.right;
        Vector2 attackPosition = (Vector2)transform.position + attackDirection * 0.5f;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPosition, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.TakeDamage(damage);
            }
            else
            {
                WalkingEnemy walkingEnemy = enemy.GetComponent<WalkingEnemy>();
                if (walkingEnemy != null)
                {
                    walkingEnemy.TakeDamage(damage);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (sr == null) sr = GetComponent<SpriteRenderer>();
        Vector2 attackDirection = sr.flipX ? Vector2.left : Vector2.right;
        Vector2 attackPosition = (Vector2)transform.position + attackDirection * 0.5f;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition, attackRange);
    }
}