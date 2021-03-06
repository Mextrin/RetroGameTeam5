﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ControllerInput))]
[RequireComponent(typeof(Rigidbody2D))]
public class LocalPlayer : MonoBehaviour
{
    ControllerInput input;

    [Header("Movement")]
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 6.5f;
    [HideInInspector] public bool onGround;
    
    Rigidbody2D rigidbody;
    LaunchBall ball;
    HealthComponent healthComponent;
    Animator animator;
    
    void Start()
    {
        ball = FindObjectOfType<LaunchBall>()?.GetComponent<LaunchBall>();
        rigidbody = GetComponent<Rigidbody2D>();
        input = GetComponent<ControllerInput>();
        healthComponent = GetComponent<HealthComponent>();
        animator = GetComponentInChildren<Animator>();
    }
    
    void Update()
    {
        Moving();
        Jump();
    }

    void Moving()
    {
        if (input.ConnectedController)
        {
            //Moving
            float moveHorizontal = Input.GetAxis(input.Horizontal) * speed * Time.deltaTime;
            animator.SetBool("isWalking", (Mathf.Approximately(moveHorizontal, 0) ? false : true));

            if (moveHorizontal < 0) transform.localScale = new Vector3(-1, 1, 1);
            else if (moveHorizontal > 0) transform.localScale = new Vector3(1, 1, 1);

            rigidbody.velocity = new Vector2(moveHorizontal * 100, rigidbody.velocity.y);
        }
    }

    void Jump()
    {
        if (input.ConnectedController)
        {
            //Jumping
            bool jump = Input.GetButtonDown(input.Jump);
            if (jump && onGround)
            {
                rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }

            //Launching
            if (ball)
            {
                if (Input.GetButtonDown(input.Action))
                {
                    ball.Launch(transform.position);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            onGround = true;
            animator.SetBool("isJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            onGround = false;
            animator.SetBool("isJumping", true);
        }
    }
}
