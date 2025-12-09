using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFish : MonoBehaviour
{
     public float moveSpeed;
    public GameObject[] wayPoints;
    int nextWaypoint=1;
    float distToPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move(){
        distToPoint=Vector2.Distance(transform.position,wayPoints[nextWaypoint].transform.position);
        transform.position=Vector2.MoveTowards(transform.position,wayPoints[nextWaypoint].transform.position,moveSpeed*Time.deltaTime);
        if(distToPoint<0.2f){
            TakeTurn();
        }
    }
    void TakeTurn(){
        Vector3 currRot=transform.eulerAngles;
        currRot.z+=wayPoints[nextWaypoint].transform.eulerAngles.z;
        transform.eulerAngles=currRot;
        ChooseNextWaypoint();
    }
    void ChooseNextWaypoint(){
        nextWaypoint++;
        if(nextWaypoint==wayPoints.Length){
            nextWaypoint=0;
        }
    }
}
