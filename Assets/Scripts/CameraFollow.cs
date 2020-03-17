using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //public Transform target = null;
    //public Transform target2 = null;
    public float smoothSpeed = 10f;
    public Vector3 offset;
    Camera main_camera;
    float vertExtent;
    float horzExtent;

    public float riseSpeed = 10.0f;
    public float speedScaler = 10.0f; 
    public float speedboost = 10.0f;
    public float maxSpeed = 1000.0f; 
    public GameObject cameraController = null;
    private Rigidbody2D cameraTrigger;
    private Vector3 cameraStartPos; 
    


    // Start is called before the first frame update
    void Start()
    {
        main_camera = FindObjectOfType<Camera>();
        vertExtent = Camera.main.orthographicSize;
        horzExtent = vertExtent * Screen.width / Screen.height;
        cameraTrigger = cameraController.GetComponent<Rigidbody2D>();
        cameraStartPos = cameraController.transform.position;
        cameraStartPos.x = 0; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector3 desiredPosition = target.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        //transform.position = smoothedPosition;

        //transform.LookAt(target);

    }

    void Update()
    {
        float speed = riseSpeed * (speedScaler / 5000) * Time.time * Time.deltaTime;
        if (speed > maxSpeed)
            speed = maxSpeed; 
        cameraStartPos.y += speed;
        //cameraController.transform.position = new Vector3(cameraStartPos.x, cameraStartPos.y += (riseSpeed * Time.deltaTime), cameraStartPos.z);
        cameraController.transform.position = cameraStartPos;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        riseSpeed  *= speedboost; 
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        riseSpeed /= speedboost; 
    }
}
