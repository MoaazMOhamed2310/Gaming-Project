using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public AudioClip trap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other) 
    {
        if(other.tag == "Player"){
        AudioManager.instance.PlayRandomSFX(trap);
        FindObjectOfType<LevelManager>().RespawnPlayer();
        }
    }
}
