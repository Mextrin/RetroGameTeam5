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
    SpriteRenderer spriteRenderer;
    public Sprite notFrozen, frozen;

    private void Awake()
    {
        timeDown = resetTime;
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void HasBeenHit(bool bHit)
    {
        if (!isFrozen)
        {
            Debug.Log("FREEZE");
            spriteRenderer.sprite = frozen;
            isFrozen = true;
            rigidbody.bodyType = RigidbodyType2D.Static;
            Invoke("FreezeTime", timeDown);
        }
        
    }

    private void FreezeTime()
    {
        Debug.Log("FREE");
        spriteRenderer.sprite = notFrozen;
        isFrozen = false;   
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        LocalPlayer localPlayer = collision.gameObject.GetComponent<LocalPlayer>();
        HealthComponent healthComponent = GetComponent<HealthComponent>();
        if (localPlayer && localPlayer.onGround == false && isFrozen == true)
        {
            Debug.Log("Hit by player");
            Destroy(gameObject);
        }
//         if (localPlayer && !isFrozen)
//         {
//             healthComponent.Damage(1);
//         }
        
    }
}
