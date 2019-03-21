using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBehaviour : MonoBehaviour
{

    bool isFrozen;
    [HideInInspector]
    public float timeDown;
    public float resetTime = 3;
    public float speed = 3;

    LocalPlayer localPlayer;
    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;
    public Sprite notFrozen, frozen;

    private void Awake()
    {
        timeDown = resetTime;
        localPlayer = GameObject.FindObjectOfType<LocalPlayer>()?.GetComponent<LocalPlayer>();
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (localPlayer)
        {
            if (!isFrozen && ((Vector2.Distance(transform.position, localPlayer.transform.position) > 1)))
            {
                this.transform.position = Vector2.MoveTowards(this.transform.position, localPlayer.transform.position, speed * Time.deltaTime);
            }
        }
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
        LocalPlayer newLocalPlayer = collision.gameObject.GetComponent<LocalPlayer>();
        if (newLocalPlayer)
        {
            localPlayer = newLocalPlayer;
            HealthComponent damage = collision.gameObject.GetComponent<HealthComponent>();

            if (localPlayer && localPlayer.onGround == false && isFrozen == true)
            {
                Debug.Log("Hit by player");
                Camera.shake
                Destroy(gameObject);
            }
            else if (!isFrozen && localPlayer)
            {
                damage.Damage(1);
            }
        }
    }
}
