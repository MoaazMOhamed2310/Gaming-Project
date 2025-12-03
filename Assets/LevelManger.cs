using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManger : MonoBehaviour
{
    public GameObject CurrentCheckpoint;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        CurrentCheckpoint=null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RespawnPlayer(){
        FindObjectOfType<na5no5>().transform.position=CurrentCheckpoint.transform.position;
    }
   
}
