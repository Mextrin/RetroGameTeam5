﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int StartingHealth = 3;
    public int CurrentHealth;

    public GameObject healthMeat1, healthMeat2, healthMeat3;

    GameManager gameManager;
    LocalPlayer localPlayer;

    private void Awake()
    {
        localPlayer = GetComponent<LocalPlayer>();

        CurrentHealth = StartingHealth;
        healthMeat1.gameObject.SetActive(true);
        healthMeat2.gameObject.SetActive(true);
        healthMeat3.gameObject.SetActive(true);
    }

    public void Damage(int damage)
    {
        CurrentHealth -= damage;

        switch (CurrentHealth)
        {
            case 3:
                healthMeat1.gameObject.SetActive(true);
                healthMeat2.gameObject.SetActive(true);
                healthMeat3.gameObject.SetActive(true);
                break;
            case 2:
                healthMeat1.gameObject.SetActive(true);
                healthMeat2.gameObject.SetActive(true);
                healthMeat3.gameObject.SetActive(false);
                break;
            case 1:
                healthMeat1.gameObject.SetActive(true);
                healthMeat2.gameObject.SetActive(false);
                healthMeat3.gameObject.SetActive(false);
                break;
            case 0:
                healthMeat1.gameObject.SetActive(false);
                healthMeat2.gameObject.SetActive(false);
                healthMeat3.gameObject.SetActive(false);
                Death();
                break;
        }
    }

    void Death()
    {
        if (CurrentHealth <= 0)
        {
            /*Destroy(localPlayer.gameObject);*/
            FindObjectOfType<GameManager>()?.GetComponent<GameManager>()?.PlayerDead(GetComponent<LocalPlayer>());
            Destroy(gameObject);
        }
    }
}
