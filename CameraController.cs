using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;

    public Vector3 offset;

    public bool useOffsetValues;

    public float rotateSpeed;

    public Transform pivot;

    public bool invertY;

    public Joystick joystick;

	// Use this for initialization
	void Start () {
        if (!useOffsetValues)
        {
            offset = target.position - transform.position;
        }

        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;
    }
	
	// Update is called once per frame
	void LateUpdate () {

        //Get the x position of the joystick and rotate the target
        float horizontal = joystick.Horizontal * rotateSpeed;
        target.Rotate(0, horizontal, 0);

        //Move the camera based on the current rotation of the target and the original offset

        float desiredYAngle = target.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredYAngle, 0);
        transform.position = target.position - (rotation * offset);
        
        //recenter the target by looking back at it
        transform.LookAt(target);
	}
}
