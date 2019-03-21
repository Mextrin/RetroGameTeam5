using System.Collections;
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

    Sprite sprite;
    
    Rigidbody2D rigidbody;
    LaunchBall ball;
    HealthComponent healthComponent;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindObjectOfType<LaunchBall>()?.GetComponent<LaunchBall>();
        rigidbody = GetComponent<Rigidbody2D>();
        input = GetComponent<ControllerInput>();
        healthComponent = GetComponent<HealthComponent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            onGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            onGround = false;
        }
    }
}
