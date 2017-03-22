using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 50f; //determine the rotating speed
    public float vertMin = -45;
    public float vertMax = 45;

    float xRotation = 0;
    // Use this for initialization
    public enum RotationAxis
    {
        MouseX
    };
    public RotationAxis axes;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxis.MouseX)
        {
            transform.Rotate(0.0f, Input.GetAxis("Mouse X") * speed * Time.deltaTime, 0.0f); //Mouse control spinning horizontally
        }
        else
        {
            //transform.Rotate(Input.GetAxis("Mouse Y") * speed, 0.0f, 0.0f); //Rotating this way will cause the camera to spin uncontrollably

            xRotation -= Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
            xRotation = Mathf.Clamp(xRotation, vertMin, vertMax); //Clamp it so that it cannot change more than 45 degree
            transform.localEulerAngles = new Vector3(xRotation, transform.localEulerAngles.y, 0);
        }
    }
}
