﻿using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMove : MonoBehaviour
{
    public float BaseSpeed = 10;
    public float AlterSpeed = 5;
    public float jumpForce = 10;
    public Rigidbody2D rb;
   

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        moveHorizontal();
        Jump();
    }

    public void moveHorizontal()
    {
        rb.velocity = new Vector2(BaseSpeed, rb.velocity.y); //Constant horizontal speed

        float moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        transform.position += new Vector3(moveHorizontal, 0, 0) * Time.deltaTime * AlterSpeed;
        // slow down, speed up controls AKA left and right movement on the screen
    }
    
    
    public void Jump()
    { // If input keyboard is "Jump" and character is not in the air add force to jump up
        if (CrossPlatformInputManager.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
            rb.AddForce(new Vector2(0f, jumpForce*3.1f), ForceMode2D.Impulse);
        

    }
    

}






