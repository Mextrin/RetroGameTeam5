using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBall : MonoBehaviour
{
    #region Variabels
    [HideInInspector]
    public bool CanFire;

    [SerializeField] bool hasLaunched;
    [SerializeField] private float LaunchForce;

    Rigidbody2D BallRb2D;
    #endregion Variabels
    
    
    private void Awake()
    {
        BallRb2D = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector3 targetPosition)
    {
        Vector2 vel = Vector3.Normalize(transform.position - targetPosition) * LaunchForce;
        float distance = Vector3.Distance(targetPosition, transform.position);

        if (distance <= 1)
        {
            Debug.Log("LAUNCH!");
/*          BallRb2D.gravityScale = 1;*/
            BallRb2D.bodyType = RigidbodyType2D.Dynamic;
            BallRb2D.velocity += vel;
        }
    }
    
     private void OnCollisionEnter2D(Collision2D collision)
     {
        HitBehaviour hitBehaviour;
        collision.gameObject.GetComponent<HitBehaviour>()?.HasBeenHit(true);
     } 
    
//      private void OnGUI()
//      {
//          GUI.Label(new Rect(5f, 5f, 200f, 200f), ("Velocity: " + BallRb2D.velocity.ToString()));
//      }
}
