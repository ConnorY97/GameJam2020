using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public Transform target2;
    public float smoothSpeed = 10f;
    public Vector3 offset;
    Camera main_camera;
    float vertExtent;
    float horzExtent;

    // Start is called before the first frame update
    void Start()
    {
        main_camera = FindObjectOfType<Camera>();
        vertExtent = Camera.main.orthographicSize;
        horzExtent = vertExtent * Screen.width / Screen.height;
        //CameraExtensions.OrthographicBounds(main_camera);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        //Gizmos.DrawCube(midPoint, new Vector3(1, 1, 1));
    }
}

//public static class CameraExtensions
//{
//    public static Bounds OrthographicBounds(this Camera camera)
//    {
//        float screenAspect = (float)Screen.width / (float)Screen.height;
//        float cameraHeight = camera.orthographicSize * 2;
//        Bounds bounds = new Bounds(
//            camera.transform.position,
//            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
//        return bounds;
//    }
//}
