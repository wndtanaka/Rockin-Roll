using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawn")]
    public GameObject[] enemies;
    public GameObject[] friends;
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
            if (Difficulty.bonusSpawned == false /*&& Difficulty.wave5On == true*/)
            {
                Instantiate(friends[0], transform.position, transform.rotation);

                Difficulty.bonusSpawned = true;

                hasSpawned = true;

                return;
            }

            int randomChoice = Random.Range(0,50);

            if (randomChoice >= 0 && randomChoice <= 38)
            {
                Instantiate(enemies[0], transform.position, transform.rotation);

                hasSpawned = true;
            }

            if (randomChoice >= 39 && randomChoice <= 43)
            {
                Instantiate(enemies[1], transform.position, transform.rotation);

                hasSpawned = true;
            }

            if (randomChoice >= 44 && randomChoice <= 48)
            {
                Instantiate(enemies[2], transform.position, transform.rotation);

                hasSpawned = true;
            }

            if (randomChoice == 49)
            {
                Instantiate(enemies[3], transform.position, transform.rotation);

                hasSpawned = true;
            }

            //Instantiate(enemies[Random.Range(0,2)], transform.position, transform.rotation);

            //hasSpawned = true;
        }
    }
}
