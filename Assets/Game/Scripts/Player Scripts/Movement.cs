using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float baseSpeed = 10f;
    public float rotationSpeed = 200f;
    public float rotationAdjustSpeed = 100f;
    public float animationSmoothing = 10f;

    float speed;

    float vertical;
    float horizontal;
    float strafe;

    Vector3 movement;

    bool rightClick;
    bool leftClick;

    Animator anim;

	void Start ()
    {
        anim = GetComponent<Animator>();
        speed = baseSpeed;
	}
	
	void FixedUpdate ()
    {
        rightClick = Input.GetKey(KeyCode.Mouse1);
        leftClick = Input.GetKey(KeyCode.Mouse0);
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        strafe = Input.GetAxis("Strafe");

        anim.SetFloat("Horizontal", horizontal, 1f, Time.deltaTime * animationSmoothing);
        anim.SetFloat("Vertical", vertical, 1f, Time.deltaTime * animationSmoothing);
        anim.SetFloat("Strafe", strafe, 1f, Time.deltaTime * animationSmoothing);

        if(vertical == 0 && strafe == 0)
        {
            anim.SetBool("IsMoving", false);
        }
        else
        {
            anim.SetBool("IsMoving", true);
        }

        if(rightClick)
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
        else
            transform.Rotate(Vector3.up * horizontal * rotationSpeed * Time.fixedDeltaTime);

        if (leftClick && rightClick)
            movement = new Vector3(strafe, 0, 1).normalized;
        else
            movement = new Vector3(strafe, 0, vertical).normalized;

        movement *= speed * Time.fixedDeltaTime;
        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0f;

        transform.position += movement;

        if (vertical > 0)
            transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z), rotationAdjustSpeed * Time.fixedDeltaTime);
    }
}
