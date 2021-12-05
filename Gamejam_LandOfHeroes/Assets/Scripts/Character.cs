using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //movementt
    public CharacterController controller;

    Vector3 velocity;
    public float movementSpeed = 12f;
    public float gravity = -18f;
    public float jumpHeight = 15f;
    //ground

    public float groundDistance = 13.55f;
    public Transform groundCheck;
    public LayerMask groundMask;
    bool isGrounded;

    public LayerMask Wall;
    bool isOnWall;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(/*groundCheck.position*/groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            //velocity.y = -2f;
            velocity.y = -20f;
        }
       /* isOnWall = Physics.CheckSphere(groundCheck.position, 35f, Wall);
        if (isOnWall && velocity.y < 0)
        {
            controller.radius = 50;
            controller.height = 90;
            velocity.y -= 1000;
        }
        else
        { controller.radius = 10;
            controller.height = 50;
        }*/

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * movementSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        Debug.Log(isGrounded);
        //Debug.Log(isOnWall);
    }
}
