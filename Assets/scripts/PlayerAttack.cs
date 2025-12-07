using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
  public int damage = 1;
    public float attackRange = 0.7f;
    public LayerMask enemyLayer;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // choose any attack key
        {
            anim.SetTrigger("Attack");
        }
    }

    // Called from Animation Event
    public void DealDamage()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position + transform.right * 0.6f,
                                                 attackRange,
                                                 enemyLayer);

        if (hit != null)
        {
            EnemyHealth enemy = hit.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.right * 0.6f, attackRange);
    }
}

