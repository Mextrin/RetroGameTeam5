using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int Health;
    public int Damage;

    void DamageTaken()
    {
        Damage -= Health;
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
