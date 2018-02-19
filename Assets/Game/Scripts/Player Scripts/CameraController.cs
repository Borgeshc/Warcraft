using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public Vector3 offset;
    public GameObject cameraHolder;

    float horizontal;
    float horizontal2;
    float vertical;

    Vector3 velocity;
    GameObject player;

    bool leftClick;
    bool rightClick;

    Vector3 currentOffset;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void LateUpdate()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Mouse X");
        horizontal2 = Input.GetAxis("Horizontal");
        leftClick = Input.GetKey(KeyCode.Mouse0);
        rightClick = Input.GetKey(KeyCode.Mouse1);

        cameraHolder.transform.position = Vector3.SmoothDamp(cameraHolder.transform.position, player.transform.position + offset, ref velocity, speed * Time.deltaTime);
    
         if (leftClick || rightClick)
            transform.RotateAround(player.transform.position, Vector3.up, horizontal * rotationSpeed * Time.deltaTime);
        else if (horizontal2 != 0)
            transform.RotateAround(player.transform.position, Vector3.up, horizontal2 * rotationSpeed * Time.deltaTime);
    }

}
