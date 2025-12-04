using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expload : MonoBehaviour
{
    public GameObject explodedBrickPrefab;
    public float delay = 5f;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(DisappearAfterDelay());
        }
    }

    private System.Collections.IEnumerator DisappearAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        // Spawn the broken version at the trap's position
        Instantiate(explodedBrickPrefab, transform.position, Quaternion.identity);

        // Remove original trap
        gameObject.SetActive(false);
    }
}


