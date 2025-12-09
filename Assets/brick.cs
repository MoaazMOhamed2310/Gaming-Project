using UnityEngine;

public class Brick : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic; // NOT falling at start
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object touching is the player
        if (collision.collider.CompareTag("na5no5"))
        {
            // Ensure the player is ABOVE the brick
            if (collision.contacts[0].normal.y < -0.5f)
            {
                // Delay then fall
                Invoke("DropBrick", 0.2f);
            }
        }
    }

    void DropBrick()
    {
        rb.bodyType = RigidbodyType2D.Dynamic; // Now brick falls
    }
}
