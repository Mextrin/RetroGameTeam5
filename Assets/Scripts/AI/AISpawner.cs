using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AISpawner : MonoBehaviour
{
    [SerializeField] int maxEnemyCount;
    [SerializeField] GameObject[] Prefab;

    int activeEnemies;
    [HideInInspector] public List<Vector2> SpawnPoints = new List<Vector2>();

    [Header("CoolDown")]
    [SerializeField] float spawnCooldown;
    float remainingTime;

    void Start()
    {
    }

    void Update()
    {
        if (Application.isPlaying)
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime <= 0)
            {
                remainingTime = spawnCooldown;
                activeEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

                if (activeEnemies < maxEnemyCount)
                {
                    int spawnIndex = Random.Range(0, SpawnPoints.Count);

                    Instantiate(Prefab[0], SpawnPoints[spawnIndex], Quaternion.identity);
                }
            }

        }
    }
}
