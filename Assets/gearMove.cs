using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gearMove : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;
    [SerializeField]
    float moveSpeed = 2f;

    int wayPointIndex = 0;


    void Start()
    {
        transform.position = waypoints[wayPointIndex].transform.position;
    }

    void Update ()
    {
       Move();
    }
    void Move()
    {
        transform.position = Vector2.MoveTowards
            (transform.position, waypoints[wayPointIndex].transform.position, moveSpeed * Time.deltaTime);

        if (transform.position == waypoints [wayPointIndex].transform.position)
        {
            wayPointIndex += 1;
        }
        if (wayPointIndex == waypoints.Length)
            wayPointIndex = 0;
    }
}
