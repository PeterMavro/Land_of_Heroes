using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //movementt
    public CharacterController controller;
    private Vector3 OgHead;
    private Vector3 OgLegs;
    public GameObject head;
    public GameObject CasheHeadGameobject;
    public GameObject CasheLegsGameobject;

    Vector3 velocity;
    public float movementSpeed = 12f;
    public float sprintMoveSpeed = 2f;
    public float gravity = -18f;
    public float jumpHeight = 15f;
    //ground

    public float groundDistance = 13.55f;
    public Transform groundCheck;
    public LayerMask groundMask;
    bool isGrounded;

    public LayerMask Wall;
    bool isOnWall;
    private float cacheMoveSpeed;
    private float cacheScale;
    private float cacheYpos;

    // Start is called before the first frame update
    void Start()
    {
        cacheMoveSpeed = movementSpeed;
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
        if (Input.GetButton("Sprint"))
        {
            movementSpeed = sprintMoveSpeed;
        }
        else
        {
            movementSpeed = cacheMoveSpeed;
        }

        OgHead = CasheHeadGameobject.transform.position;
        OgLegs = CasheLegsGameobject.transform.position;


        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            head.transform.position = OgLegs;
            cacheScale = controller.height;
            cacheYpos = controller.center.y;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            controller.height = cacheScale / 2;
            controller.center = new Vector3(controller.center.x, cacheYpos *1.8f, controller.center.z);
            //controller.radius = cacheYpos * 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            head.transform.position = OgHead;
            controller.height = cacheScale;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 2, this.transform.position.z);
            controller.center = new Vector3(controller.center.x, cacheYpos, controller.center.z);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        Debug.Log(isGrounded);
        //Debug.Log(isOnWall);
    }
}
