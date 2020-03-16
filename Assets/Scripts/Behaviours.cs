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
    private Vector2 target; 
    private bool increase = true; 
    private float t = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (horizontal)
            target = startPos + new Vector2(offset, 0);
        else
            target = startPos + new Vector2(0, offset);

        float step = speed * Time.deltaTime; 


        if (transform.position == new Vector3(startPos.x, startPos.y, 0))
        {
            increase = true;
        }
        else if (transform.position == new Vector3(target.x, target.y, 0))
            increase = false; 

        if (horizontal)
        {
            if (increase)
            {
                transform.position = Vector2.MoveTowards(transform.position, target, step);
            }
            else if (!increase)
            {
                transform.position = Vector2.MoveTowards(transform.position, startPos, step);
            }
        }
        else if (!horizontal)
        {
            if (increase)
            {
                transform.position = Vector2.MoveTowards(transform.position, target, step);
            }
            else if (!increase)
            {
                transform.position = Vector2.MoveTowards(transform.position, startPos, step);
            }
        }

        if (increase)
            t += speed * Time.deltaTime;
        else if (!increase)
            t -= speed * Time.deltaTime;

        if (rotate)
        {
            transform.Rotate(0, 0, rotSpeed * Time.deltaTime);
        }

        Debug.Log(transform.position.x + ", " + startPos.x);
    }
}
