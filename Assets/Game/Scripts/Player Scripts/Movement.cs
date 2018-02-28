using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Variables")]
    public float baseSpeed = 10f;
    public float rotationSpeed = 200f;
    public float rotationAdjustSpeed = 100f;
    public float animationSmoothing = 10f;

    [Space, Header("Jump Variables")]
    public float jumpForce = 8f;
    public float gravity = 20f;
    public float distToGround = 1.1f;
    public LayerMask groundLayer;

    float speed;

    float vertical;
    float horizontal;
    float strafe;

    float jump;

    bool isJumping;

    Vector3 movement;

    bool rightClick;
    bool leftClick;

    Animator anim;
    CharacterController cc;

	void Start ()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        speed = baseSpeed;
	}
	
	void FixedUpdate ()
    {
        rightClick = Input.GetKey(KeyCode.Mouse1);
        leftClick = Input.GetKey(KeyCode.Mouse0);

        if (rightClick && leftClick)
            vertical = 1;
        else
            vertical = Input.GetAxis("Vertical");

        if (rightClick)
            horizontal = Input.GetAxis("Mouse X");
        else
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
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
        else
            transform.Rotate(Vector3.up * horizontal * rotationSpeed * Time.fixedDeltaTime);

        if (leftClick && rightClick)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            movement = new Vector3(strafe, 0, 1).normalized;
        }
        else
            movement = new Vector3(strafe, 0, vertical).normalized;

        if(!leftClick && !rightClick)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        movement *= speed * Time.deltaTime;
        movement = Camera.main.transform.TransformDirection(movement);

        cc.Move(movement);
        cc.Move(new Vector3(0, jump, 0));

        jump -= gravity * Time.deltaTime;

        if (isJumping && Grounded())
        {
            isJumping = false;
            anim.SetBool("Jump", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Grounded())
            Jump();

        if (vertical > 0)
            transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z), rotationAdjustSpeed * Time.fixedDeltaTime);
    }

    public void Jump()
    {
        jump = jumpForce;

        anim.SetBool("Jump", true);
        isJumping = true;
    }

    bool Grounded()
    {
        RaycastHit hit;
        return Physics.SphereCast(transform.position,1, Vector3.down, out hit, distToGround, groundLayer);
    }
}
