using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.EventSystems;




public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // speed 
    public Transform orientation; // angle

    float horiontalInput; // Declaring a and d input axis name.
    float verticalInput; // Declaring w and s input axis name.

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
    }


    private void Update() //This is fps dependent which is fine for user inputs.
    {
        userInput(); // Checking this, so when a user has pressed any movement keys, the character will move.
    }


    private void userInput() 
    {
        horiontalInput = Input.GetAxisRaw("Horizontal"); // Getting a and d key status or left and right. 
        verticalInput = Input.GetAxisRaw("Vertical"); // Getting w and s key status or up and down. Both of these allow for easier controller integration compared to legacy movement

    }


    private void playerMovement()
    {
        // calc move direction 
        // 🤓 calc is short for calculator btw 

        moveDir = orientation.forward * verticalInput + orientation.right * horiontalInput; // verticle input is being mutiplied by orientation.forward since it is represented by moving forward or behind and movement is along the local z-axis. horizontal input is being mutiplied by orientation.right since it is represented by moving left or right and movement is along the local x-axis.

        rb.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Force); 

    }


}