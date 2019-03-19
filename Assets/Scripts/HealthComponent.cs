using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int StartingHealth = 3;
    public int CurrentHealth;

    public GameObject healthMeat1, healthMeat2, healthMeat3;

    private void Awake()
    {
        CurrentHealth = StartingHealth;
        healthMeat1.gameObject.SetActive(true);
        healthMeat2.gameObject.SetActive(true);
        healthMeat3.gameObject.SetActive(true);
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
