using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawners;

    public int randomSpawnerInt;

    public float spawnManagerInterval;

    public bool spawnManagerHasActivatedSpawner;

    public int spawnerAmount;

    // Use this for initialization
    void Start()
    {
        spawnManagerInterval = 1f;
        spawnManagerHasActivatedSpawner = false;

        spawnerAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnManagerHasActivatedSpawner == false)
        {
            for (int i = 0; i < spawnerAmount; i++)
            {
                StartCoroutine(RandomSpawnerIenumerator());
            }
        }
    }

    void RandomSpawnerChoice()
    {
        randomSpawnerInt = Random.Range(0,spawners.Length);
    }

    IEnumerator RandomSpawnerIenumerator()
    {
        spawnManagerHasActivatedSpawner = true;

        RandomSpawnerChoice();

        spawners[randomSpawnerInt].GetComponent<Spawner>().hasSpawned = false;

        yield return new WaitForSeconds(spawnManagerInterval);

        spawnManagerHasActivatedSpawner = false;
    }
}
