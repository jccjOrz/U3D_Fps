using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 8f;
    [SerializeField]
    private float thrusterForce = 20;//给他一个20的推力；
    [SerializeField]
    private PlayerController controller;

    private float distToGround = 0f;

    // Start is called before the first frame update
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float yMov = Input.GetAxisRaw("Vertical");

        Vector3 velocity = (transform.right * xMov + transform.forward * yMov).normalized * speed;
        controller.Move(velocity);

        float xMouse = Input.GetAxisRaw("Mouse X");
        float yMouse = Input.GetAxisRaw("Mouse Y");

        Vector3 yRotation = new Vector3(0f, xMouse, 0f) * lookSensitivity;
        Vector3 xRotation = new Vector3(-yMouse, 0f, 0f) * lookSensitivity;
        controller.Rotate(yRotation, xRotation);

        Vector3 force = Vector3.zero;
        if (Input.GetButton("Jump"))
        {
            if (Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f))
            {
                force = Vector3.up * thrusterForce;
                controller.Thrust(force);
            }
            
        }
     
        
    }
}

