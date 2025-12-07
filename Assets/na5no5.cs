 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class na5no5 : MonoBehaviour
{
 public float moveSpeed;                // How fast the player moves
    public float jumpHeight;               // How high the player jumps
    public KeyCode L;                      // Left key, assign in Inspector
    public KeyCode R;                      // Right key, assign in Inspector
    public KeyCode Spacebar;               // Jump key, assign in Inspector
    public Transform groundCheck;          // Empty GameObject at player's feet
    public float groundCheckRadius;        // Radius to check if grounded
    public LayerMask whatIsGround;         // Layer for ground detection

    public KeyCode attackKey;              // Attack key, assign in Inspector
    public LayerMask enemyLayer;           // Layer for enemies
    public float attackRange;              // Automatically set based on sprite width

    private bool grounded;
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        // ===== ADDED =====
        // Automatically set attack range to roughly half the player's width
        if (sr != null)
        {
            attackRange = sr.bounds.size.x * 0.5f;
        }
        // =================
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        HandleAttack();    // ===== ADDED ===== Attack handled inside player controller
        UpdateAnimator();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    void HandleMovement()
    {
        float horizontalVelocity = 0f;

        if (Input.GetKey(L))
        {
            horizontalVelocity = -moveSpeed;
            sr.flipX = true;
        }
        else if (Input.GetKey(R))
        {
            horizontalVelocity = moveSpeed;
            sr.flipX = false;
        }

        rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(Spacebar) && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }

    void HandleAttack()
    {
        if (Input.GetKeyDown(attackKey))
        {
            anim.SetTrigger("Attack");

            // ===== ADDED =====
            // Detect all enemies in front within attack range
           // Determine attack direction based on player facing
Vector3 attackDirection = sr.flipX ? Vector3.left : Vector3.right;

Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position + attackDirection * (attackRange / 1.5f), attackRange, enemyLayer);

            foreach (Collider2D hit in hits)
            {
                // Only hit enemies with EnemyHealth script
                EnemyHealth enemyHealth = hit.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(1); // Apply damage
                }
            }
            // =================
        }
    }

    void UpdateAnimator()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("Height", rb.velocity.y);
        anim.SetBool("Grounded", grounded);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Boat"))
        {
            transform.SetParent(collision.collider.transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Boat"))
        {
            transform.SetParent(null);
        }
    }

    // ===== ADDED =====
    // Draw attack range in editor for visualization
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.right * (attackRange / 1.5f), attackRange);
    }
    // =================
}