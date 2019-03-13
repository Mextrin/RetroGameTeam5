using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2D;

    public float Speed;
    public float JumpForce;

    private bool onGround;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }

    void Movement()
    {
        float Delta = Speed * Time.deltaTime;
        float MoveX = Input.GetAxis("Horizontal") * Delta;

        transform.Translate(new Vector2(MoveX, 0));
    }

    void Jump()
    {
        bool Jump = Input.GetButtonDown("Jump");

        if (Jump)
        {
            rb2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 && !onGround)
        {
            Debug.Log("Ground");
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 && onGround)
        {
            Debug.Log("Not Ground");
            onGround = false;
        }
    }
}
