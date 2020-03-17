using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviours : MonoBehaviour
{
    [Header("Public Variables")]    
    public float offset;
    public float speed = 0.0f;
    public bool horizontal = true;
    public bool rotate = false;
    public float rotSpeed = 250.0f;


    private Vector2 startPos;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float platspeed = speed * Time.deltaTime; 

        if (horizontal)
        {
            //startPos.x += Mathf.Sin(platspeed * Time.time) * (offset / 100);
            transform.position = new Vector3(startPos.x + Mathf.Sin(speed * Time.time) * offset, startPos.y, 0); 
            //transform.position = startPos; 
        }
        else if (!horizontal)
        {
            transform.position = new Vector3(startPos.x, startPos.y + Mathf.Sin(speed * Time.time) * offset, 0); 
        }

        if (rotate)
        {
            transform.Rotate(0, 0, rotSpeed * Time.deltaTime);
        }
    }
}
