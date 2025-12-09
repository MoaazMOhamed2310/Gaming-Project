using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crawllingEnemy : EnemyController
{
    public float moveSpeed;
    public GameObject[] wayPoints;
    private int nextWaypoint = 1;
    private float distToPoint;

    void Update()
    {
        Move();
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
        currRot.z = currRot.z + wayPoints[nextWaypoint].transform.eulerAngles.z;
        transform.eulerAngles = currRot;
        ChooseNextWaypoint();
    }

    void ChooseNextWaypoint()
    {
        nextWaypoint = nextWaypoint + 1;
        if (nextWaypoint == wayPoints.Length)
        {
            nextWaypoint = 0;
        }
    }

    // Override to make crawling enemy take extra damage when stomped
    public new void TakeDamage(int damage)
    {
        // Check if damage is from stomp (player above enemy)
        Collider2D playerAbove = Physics2D.OverlapCircle(transform.position, 0.5f, LayerMask.GetMask("Player"));
        if (playerAbove != null && playerAbove.transform.position.y > transform.position.y)
        {
            health = health - (damage * 2); // Double damage for stomp
        }
        else
        {
            health = health - damage;
        }

        if (health <= 0)
        {
            health = 0;
        }
        if (health == 0)
        {
            Debug.Log("Crawling Enemy Finished");
            PlayerStats.score = PlayerStats.score + 15;
            Destroy(gameObject);
        }
    }
}