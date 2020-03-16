using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 


public class Obsticals : MonoBehaviour
{
    public struct values
    {
        float max;
        float min;
    }

    public GameObject[] platforms;

    public float[] maximum;
    public float[] minimum; 

    public bool[] horizontal; 

    static float t = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < platforms.Length; i++)
        {
            switch (horizontal[i])
            {
                case true:
                    platforms[i].transform.position = new Vector2(Mathf.Lerp(maximum[i], minimum[i], t), platforms[i].transform.position.y);
                    break;

                case false:
                    platforms[i].transform.position = new Vector2(platforms[i].transform.position.x, Mathf.Lerp(maximum[i], minimum[i], t));
                    break;
            }

            t += 0.5f * Time.deltaTime;
            
            if (t > 1.0f)
            {
                float temp = maximum[i];
                maximum[i] = minimum[i];
                minimum[i] = temp;
                t = 0.0f; 
            }
        }
    }
}
