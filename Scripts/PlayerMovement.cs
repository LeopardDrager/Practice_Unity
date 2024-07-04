using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;




public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // speed 
    public Transform orientation; // angle

    public float groundDrag;

    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    float horiontalInput; // Declaring a and d input axis name.
    float verticalInput; // Declaring w and s input axis name.

    public float sprintSpeed = 20f * 5f;
    private bool isSprint;

    Vector3 moveDir; // Declaring Vector for later on when I need to use movement direction.
    Rigidbody rb; // Declaring new rigidbody as rb


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Allows for me to control physic interactions with roatations.
    }


    private void FixedUpdate() //This allows for less dependent on frame rate and instead relies on a set rate defined. This rate can be changed with another command, but I left it as default for simplicity.
    {
        playerMovement(); 
        
        speedLimit();
    }


    private void Update() //This is fps dependent which is fine for user inputs.
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight *.5f + .2f, whatIsGround);// Using raycast as that is easier than placing object at bottom of player and using that.
        
        userInput(); // Checking this, so when a user has pressed any movement keys, the character will move.

        if(grounded)
        {
            rb.drag =groundDrag;
        }
        else
            rb.drag=0;
    }



    private void userInput() 
    {
        horiontalInput = Input.GetAxisRaw("Horizontal"); // Getting a and d key status or left and right. 
        verticalInput = Input.GetAxisRaw("Vertical"); // Getting w and s key status or up and down. Both of these allow for easier controller integration compared to legacy movement
        isSprint = Input.GetButton("sprint");
    }


    private void playerMovement()
    {
        // calc move direction 
        // 🤓 calc is short for calculator btw 

        moveDir = orientation.forward * verticalInput + orientation.right * horiontalInput; // verticle input is being mutiplied by orientation.forward since it is represented by moving forward or behind and movement is along the local z-axis. horizontal input is being mutiplied by orientation.right since it is represented by moving left or right and movement is along the local x-axis.

        if (isSprint==false)
        {
            rb.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Force); 
        }
        else {
            rb.AddForce(moveDir.normalized * sprintSpeed * 10f, ForceMode.Force);
        }

    }
    private void speedLimit()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVelocity.magnitude > moveSpeed && isSprint==false)
        {
            Vector3 limitedVelocity =flatVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, limitedVelocity.y, limitedVelocity.z);
        }
    }

}