﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBall : MonoBehaviour
{
    #region Variabels
    [HideInInspector]
    public bool CanFire;

    [SerializeField]
    private float LaunchForce;
    [SerializeField]
    private float time;

    Rigidbody2D BallRb2D;
    PlayerLaunchAction PlayerLaAction;
    #endregion Variabels


    private void Awake()
    {
        BallRb2D = GetComponent<Rigidbody2D>();
        PlayerLaAction = GameObject.FindObjectOfType<PlayerLaunchAction>()?.GetComponent<PlayerLaunchAction>();
    }

    private void Update()
    {
        Launch();   
    }

    void Launch()
    {
        Vector2 vel = (transform.position - PlayerLaAction.transform.position) * LaunchForce;
        time = 10;

        if (PlayerLaAction != null)
        {
            if (PlayerLaAction.hasLaunched == true && CanFire == true)
            {
                Debug.Log("LAUNCH!");
                BallRb2D.bodyType = RigidbodyType2D.Dynamic;
                BallRb2D.velocity += vel;
                Invoke("BallVelDecreasment", time);
            }
        }
        else
        {
            PlayerLaAction = null;
        }
    }

    void BallVelDecreasment()
    {
        BallRb2D.drag = 100;
        /*Debug.Log("Slowed down");*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == PlayerLaAction.gameObject)
        {
            CanFire = true;
            /*Debug.Log("Player detected");*/
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == PlayerLaAction.gameObject)
        {
            CanFire = false;
            /*Debug.Log("Player NOT detected");*/
        }
    }

    //     private void OnGUI()
    //     {
    //         GUI.Label(new Rect(5f, 5f, 200f, 200f), ("Velocity: " + BallRb2D.velocity.ToString()));
    //     }
}
