using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bashandy : EnemyController
{
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="Player"){
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
            Flip();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
