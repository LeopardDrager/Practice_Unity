using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private void Update() {
        
        Vector2 inputVector = new Vector2(0,0); /*Reason for not just taking this in as vector 3
    1. Keyboard does not really have a z-axis
    2. You would rather the input be given to you in true form then convert rather than it be pre-converted partially true data.
    3. Also allows for easier gamepad integration
                                                */

        if (Input.GetKey(KeyCode.W))    {
            inputVector.y = +1; //character moves up
            // Debug.Log("W is preessed");
        }

        if (Input.GetKey(KeyCode.S))    {
            inputVector.y= -1; //character moves down 
            // Debug.Log("S is pressed");
        }
        
        if (Input.GetKey(KeyCode.A))    {
            inputVector.x = -1; //character moves left
            // Debug.Log("A is pressed");
        }

        if (Input.GetKey(KeyCode.D))    {
            inputVector.x = +1; //character moves right
            // Debug.Log("D is pressed");
        }
        
        inputVector= inputVector.normalized;

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * Time.deltaTime; // this is equivilant to transform.position = transform.position + moveDir * Time.deltaTime;
        // Time.deltaTime contains the amount of seconds since LAST frame.
        // We need this because other wise speed will be depend on framerate
        Debug.Log(Time.deltaTime);
    }







}
