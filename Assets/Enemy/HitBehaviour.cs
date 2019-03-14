using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBehaviour : MonoBehaviour
{
    [HideInInspector]
    public bool isHit;
    [HideInInspector]
    public float timeDown;
    public float resetTime = 3;
    public int damage;
    private bool HasBeenDone;

    PlayerMovement pm;
    public HealthComponent hc;

    private void Awake()
    {
        pm = GameObject.FindObjectOfType<PlayerMovement>()?.GetComponent<PlayerMovement>();
        hc = GetComponent<HealthComponent>();
        timeDown = resetTime;   
    }

    // Update is called once per frame
    void Update()
    {
        hasBeenHit();
    }

    void hasBeenHit()
    {
        if (isHit == true && !HasBeenDone)
        {
           // Debug.Log("FREEZE");
            timeDown -= Time.deltaTime;

            if (timeDown <= 0)
            {
                Debug.Log("FREE");
                isHit = false;
                HasBeenDone = false;
            }
        }
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject == pm.gameObject) && (pm.onGround == false) && (isHit == true))
        {
           hc.DamageTaken(damage);
        }
    }
    */
}
