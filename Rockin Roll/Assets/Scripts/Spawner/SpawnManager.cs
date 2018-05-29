using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawners;

    public int randomSpawnerInt;

    public float spawnManagerInterval;

    public bool spawnManagerHasActivatedSpawner;

    // Use this for initialization
    void Start()
    {
        spawnManagerInterval = 1f;
        spawnManagerHasActivatedSpawner = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnManagerHasActivatedSpawner == false)
        {
            StartCoroutine(RandomSpawnerIenumerator());
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
