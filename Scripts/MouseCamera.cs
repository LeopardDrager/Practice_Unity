using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{

       public Vector2 turn;
       public float sensitivity = .5f; // Defining sensitivity so it could posible be changed by user.

    void Start (){
        Cursor.lockState = CursorLockMode.Locked;
    }
 
     void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
}
