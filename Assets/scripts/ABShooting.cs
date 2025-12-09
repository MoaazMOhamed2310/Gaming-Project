using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABShooting : MonoBehaviour
{
    public KeyCode Return;
    public Transform shootingPoint;
    public GameObject bullet;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(Return)){
            Shooting();
        }
    }
    public void Shooting()
{
    Debug.Log("SHOOT");
    Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);
}
}
