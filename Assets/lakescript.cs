using UnityEngine;

public class lakescript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "na5no5")
{FindObjectOfType<LevelManger>().RespawnPlayer();}
    }
   
}