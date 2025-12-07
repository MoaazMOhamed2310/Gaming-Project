using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPill : MonoBehaviour
{
    //public AudioClip PillSound;

     void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="Player"){
            PlayerStats.lives++;
            PlayerStats.hasPill=true;
            //AudioManager.Instance.PlayMusicSFX(PillSound);
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
