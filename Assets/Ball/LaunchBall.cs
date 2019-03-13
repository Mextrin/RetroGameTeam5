using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBall : MonoBehaviour
{

    public Vector2 BallVelocity;
   
    

    [HideInInspector]
    public bool CanFire;

    Rigidbody2D BallRb2D;

    PlayerLaunchAction pla;

    private void Awake()
    {
        pla = GameObject.FindObjectOfType<PlayerLaunchAction>()?.GetComponent<PlayerLaunchAction>();

        BallRb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Launch();    
    }

    void Launch()
    {
        Vector2 vel = transform.position - pla.transform.position;
        if (pla != null)
        {
            if (pla.hasLaunched == true && CanFire == true)
            {
                Debug.Log("LAUNCH!");
                BallRb2D.bodyType = RigidbodyType2D.Dynamic;
                BallRb2D.velocity += vel;
            }
        }
        else
        {
            pla = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == pla.gameObject)
        {
            CanFire = true;
            Debug.Log("Player detected");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == pla.gameObject)
        {
            CanFire = false;
            Debug.Log("Player NOT detected");
        }
    }


}
