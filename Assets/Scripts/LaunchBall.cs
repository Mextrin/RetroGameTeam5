﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBall : MonoBehaviour
{
    #region Variabels
    [HideInInspector]
    public bool CanFire;

    [SerializeField] bool hasLaunched;
    [SerializeField] private float LaunchForce;
    [SerializeField] private float time;

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
         
    }
    
    public void Launch(Vector3 targetPosition)
    {
        Vector2 vel = Vector3.Normalize(transform.position - targetPosition) * LaunchForce;
        time = 10;
    

            float distance = Vector3.Distance(targetPosition, transform.position);
        if (distance <= 1)
        {
            Debug.Log("LAUNCH!");
            BallRb2D.gravityScale = 1;
            BallRb2D.bodyType = RigidbodyType2D.Dynamic;
            BallRb2D.velocity += vel;

            /* Invoke("BallVelDecreasment", time);*/
        }


    }
    
    void BallVelDecreasment()
    {
//         PhysMat.friction = 5;
//         PhysMat.bounciness = 0;
        /*Debug.Log("Slowed down");*/
    }
    
      private void OnTriggerEnter2D(Collider2D collision)
      {
        
      }
//      private void OnTriggerExit2D(Collider2D collision)
//      {
//          if (collision.gameObject == PlayerLaAction.gameObject)
//          {
//              CanFire = false;
//              /*Debug.Log("Player NOT detected");*/
//          }
//      }
    
//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (EnHitBehaviour != null && (collision.gameObject == EnHitBehaviour.gameObject))
//         {
//             /*Debug.Log("Enemy Hit");*/
//             EnHitBehaviour.isHit = true;
//             EnHitBehaviour.timeDown = EnHitBehaviour.resetTime;
//         }
//     } 
    
     private void OnGUI()
     {
         GUI.Label(new Rect(5f, 5f, 200f, 200f), ("Velocity: " + BallRb2D.velocity.ToString()));
     }
}
