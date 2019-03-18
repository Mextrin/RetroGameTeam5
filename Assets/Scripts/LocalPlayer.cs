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
    [SerializeField] bool onGround;

    [Header("Ball")]
    [SerializeField] bool hasLaunched;

    bool flipped;
    Sprite sprite;

    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;
    LaunchBall ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindObjectOfType<LaunchBall>()?.GetComponent<LaunchBall>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        input = GetComponent<ControllerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (input.ConnectedController)
        {
            //Moving
            float moveHorizontal = Input.GetAxis(input.Horizontal) *speed * Time.deltaTime;
        
            transform.Translate(new Vector2(moveHorizontal, 0));
            if (moveHorizontal > 0) spriteRenderer.flipX = false;
            else if (moveHorizontal < 0) spriteRenderer.flipX = true;

            //Jumping
            print(onGround);
            bool jump = Input.GetButtonDown(input.Jump);
            if (jump && onGround) rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        
            //Launching
            if (ball)
            {
                if (Input.GetButtonDown(input.Action) && ball.CanFire)
                {
                    hasLaunched = true;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            onGround = false;
        }
    }
}
