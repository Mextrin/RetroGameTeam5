using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int Health;

    public void DamageTaken(int damage)
    {
        Health -= damage;
        Debug.Log(Health.ToString());
    }

    void Death()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
