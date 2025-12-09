using UnityEngine;

public class LevelManger : MonoBehaviour
{
    public GameObject CurrentCheckpoint;

    public void RespawnPlayer()
    {
        if (CurrentCheckpoint == null)
        {
            Debug.Log("No checkpoint set yet!");
            return;
        }

        FindObjectOfType<na5no5>().transform.position = CurrentCheckpoint.transform.position;
    }
}


