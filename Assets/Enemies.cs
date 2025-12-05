using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float maxSpeed=2;
    public int damage=1;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr=GetComponent<SpriteRenderer>();
    }
    public void Flip(){
        sr.flipX=!sr.flipX;
    }
    void FixedUpdate(){
        if(sr.flipX==true){
            this.GetComponent<Rigidbody2D>().velocity=
            new Vector2(-maxSpeed,this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else{
             this.GetComponent<Rigidbody2D>().velocity=
            new Vector2(maxSpeed,this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.tag=="Player"){
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
            Flip();
        }
        else if(other.tag=="Wall"){
            Flip();
        }
    }

}
