using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillCollecting : MonoBehaviour
{
    private bool canCollect = false; // player is in range

    void Update()
    {
        // Check if player is in range and presses E
        if (canCollect && Input.GetKeyDown(KeyCode.E))
        {
            Collect();
        }
    }

    private void Collect()
    {
        Debug.Log("Pill collected!");
        // Optional: add to player score here

        // Disable the pill
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canCollect = true; // player entered range
            Debug.Log("Press E to collect the pill");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canCollect = false; // player left range
        }
    }
}

