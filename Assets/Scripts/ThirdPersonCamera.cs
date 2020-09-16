using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public float turnSpeed = 4.0f;

    public GameObject target;
    private float targetDistance;

    public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 0.0f;
    private float rotX;
    private float rotY;

    // Start is called before the first frame update
    void Start()
    {
        targetDistance = Vector3.Distance(transform.position, target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        rotY += Input.GetAxis("Mouse X") * turnSpeed;
        rotX += Input.GetAxis("Mouse Y") * turnSpeed;

        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

        transform.eulerAngles = new Vector3(-rotX, rotY, 0);
        // move the camera position
        transform.position = target.transform.position - (transform.forward * targetDistance);
    }
}