using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tutorial followed: https://www.youtube.com/watch?v=dwcT-Dch0bA&t=1012s
public class PlayerMovement2 : MonoBehaviour
{
    public CharacterController2D controller;

    private float horizontalMove = 0f;

    public float runSpeed = 40f;

    private bool jump = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw(("Horizontal"))*runSpeed;
        if (Input.GetButtonDown(("Jump")))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove*Time.fixedDeltaTime,false,jump);
        jump = false;
    }
}
