using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2D;
    SpriteRenderer sR;

    public float Speed;
    public float JumpForce;

    public bool onGround;
    private bool flipped;
    private Sprite sprite;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
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

        transform.Translate(new Vector2(-MoveX, 0));
        if (MoveX > 0f)
        {
            sR.flipX = false;
        }
        else if (MoveX < 0f)
        {
            sR.flipX = true;
        }
    }

    void Jump()
    {
        bool Jump = Input.GetButtonDown("Jump");

        if (Jump && onGround == true)
        {
            rb2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Debug.Log("On Ground");
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Debug.Log("Not Ground");
            onGround = false;
        }
    }
}
