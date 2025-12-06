using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoneySafe : MonoBehaviour
{
   public PuzzleManager puzzleManager;   // Assign the PuzzleManager in Inspector
    public GameObject pill;               // Assign the pill GameObject (inside the safe)
    public Animator anim;                 // Assign Animator on safe or its child

    void Awake()
    {
        // Ensure pill is invisible at start
        if (pill != null) pill.SetActive(false);

        // If Animator not assigned manually, try to get it from self or children
        if (anim == null)
            anim = GetComponentInChildren<Animator>();
    }

    void OnMouseDown()
    {
        // Show the puzzle when the player clicks the safe
        if (puzzleManager != null)
        {
            puzzleManager.ShowPuzzle(this);
        }
    }

    public void OpenSafe()
    {
        if (anim != null)
        {
            anim.SetTrigger("Open");  // Trigger the opening animation
        }
        else
        {
            Debug.LogWarning("Animator not assigned or found on MoneySafe!");
        }

        // Show the pill immediately
        if (pill != null)
    {
        // Move the pill slightly above and in front of the safe
        pill.transform.position = transform.position + new Vector3(0f, 0.2f, -0.1f);
        // Ensure sprite renderer is enabled
        var sr = pill.GetComponent<SpriteRenderer>();
        if (sr != null) sr.enabled = true;
        // Activate
        pill.SetActive(true);
    }
}
}


