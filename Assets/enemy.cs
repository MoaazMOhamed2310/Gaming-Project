using UnityEngine;

public class enemy : MonoBehaviour
{
    public float maxSpeed = 2;
public int damage = 1;
public SpriteRenderer sr;
void Start()

{sr = GetComponent<SpriteRenderer>();
}


public void Flip()
{
sr.flipX =! sr.flipX;
}

void OnTriggerEnter2D(Collider2D other)
{
if (other.tag == "na5no5")
{FindObjectOfType<playerstats>().TakeDamage(damage);
Flip();
}

else if (other.tag == "Wall")
{Flip();
}

}

}