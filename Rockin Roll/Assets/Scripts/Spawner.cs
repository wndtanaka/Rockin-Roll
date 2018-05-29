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
        hasSpawned = false;
        spawnAmount = 1;
        spawnInterval = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasSpawned == false)
        {
            StartCoroutine(SpawnNow());
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Instantiate(enemies[0], transform.position, transform.rotation);
        }
    }

    IEnumerator SpawnNow()
    {
        hasSpawned = true;

        yield return new WaitForSeconds(spawnInterval);

        SpawnEnemies();

        hasSpawned = false;
    }
}
