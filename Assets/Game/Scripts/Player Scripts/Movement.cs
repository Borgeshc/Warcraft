using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float baseSpeed = 1;
    public float rotationSpeed = 100;

    float speed;

    float vertical;
    float horizontal;
    float horizontal2;
    float strafe;

    Vector3 movement;

    bool rightClick;
    bool leftClick;

	void Start ()
    {
        speed = baseSpeed;
	}
	
	void Update ()
    {
        rightClick = Input.GetKey(KeyCode.Mouse1);
        leftClick = Input.GetKey(KeyCode.Mouse0);
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        horizontal2 = Input.GetAxis("Mouse X");
        strafe = Input.GetAxis("Strafe");

        if(rightClick)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
        else
        {
            transform.Rotate(Vector3.up * horizontal * rotationSpeed * Time.deltaTime);
        }

        if (leftClick && rightClick)
            movement = new Vector3(strafe, 0, 1);
        else
            movement = new Vector3(strafe, 0, vertical);

        movement *= speed * Time.deltaTime;
        movement.Normalize();
        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0f;

        transform.position += movement;


        if (vertical > 0)
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
