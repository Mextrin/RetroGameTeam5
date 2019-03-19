using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int StartingHealth = 3;
    int CurrentHealth;

    private void Awake()
    {
        CurrentHealth = StartingHealth;
    }

    public void Damage(int damage)
    {
        CurrentHealth -= damage;
        Debug.Log(CurrentHealth.ToString());
    }

    void Death()
    {
        if (StartingHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
