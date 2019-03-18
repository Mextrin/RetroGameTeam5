using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBehaviour : MonoBehaviour
{

    bool isFrozen;
    [HideInInspector]
    public float timeDown;
    public float resetTime = 3;

    Rigidbody2D rigidbody;

    private void Awakdw()
    {
        timeDown = resetTime;
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HasBeenHit(bool bHit)
    {
        Debug.Log("FREEZE");
        isFrozen = true;
        Invoke("FreezeTime", timeDown);
    }

//     void FreezeTime()
//     {
//         Debug.Log("FREE");
//         isFrozen = false;   
//         rigidbody.bodyType = RigidbodyType2D.Dynamic;
//     }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        LocalPlayer localPlayer = collision.gameObject.GetComponent<LocalPlayer>();
        if (localPlayer && localPlayer.onGround == false && isFrozen == true)
        {
            Debug.Log("Hit by player");
        }
        
    }
}
