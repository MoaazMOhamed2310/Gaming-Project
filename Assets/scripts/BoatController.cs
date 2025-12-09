using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
     public Transform pointA;  
    public Transform pointB;  
    public float speed = 3f;

    private bool playerOnBoat = false;
    private Transform targetPoint;

    void Start()
    {
        // Start moving toward point B first
        targetPoint = pointB;
    }

    void Update()
    {
        if (playerOnBoat)
        {
            // Move the boat
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

            // If the boat reaches the target, switch direction
            if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
            {
                targetPoint = (targetPoint == pointA) ? pointB : pointA;
            }
        }
    }

    // Use 2D trigger if your game is 2D!
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnBoat = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnBoat = false;
        }
    }
}


