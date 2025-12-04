using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public Transform pointA;  
    public Transform pointB;  
    
    public float speed = 3f;

    private bool playerOnBoat = false;

    void Update()
    {
        if (playerOnBoat)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  
        {
            playerOnBoat = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnBoat = false;
        }
    }
}


