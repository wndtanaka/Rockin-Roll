using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawn")]
    public GameObject[] enemies;
    public bool hasSpawned;
    public float spawnInterval;
    public int spawnAmount;

    // Use this for initialization
    void Start()
    {
        hasSpawned = true;
        spawnAmount = 1;
        spawnInterval = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasSpawned == false)
        {
            SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            if (Difficulty.bonusSpawned == false && Difficulty.wave5On == true)
            {
                Instantiate(enemies[1], transform.position, transform.rotation);

                Difficulty.bonusSpawned = true;

                return;
            }

            Instantiate(enemies[0], transform.position, transform.rotation);

            hasSpawned = true;
        }
    }
}
