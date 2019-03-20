using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    List<LocalPlayer> players = new List<LocalPlayer>();
    // Start is called before the first frame update
    void Awake()
    {
        var playerObjects = FindObjectsOfType<LocalPlayer>();
        for (int i = 0; i < playerObjects.Length; i++)
        {
            players.Add(playerObjects[i].GetComponent<LocalPlayer>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (players.Count > 0)
        {   
            //Any player alive
            for (int i = 0; i < players.Count; i++)
            {
                HealthComponent playerHealth = players[i].GetComponent<HealthComponent>();

                if (playerHealth.CurrentHealth <= 0)
                {
                    players.RemoveAt(i);
                }
            }
        }
        else
        {
            //Both players dead
        }
    }
}
