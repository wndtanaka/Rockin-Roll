using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    [Header("Scripts")]
    public SpawnManager spawnManager;
    public EnemyStats enemyStats;

    [Header("Difficulty-Timer")]
    public float diffTimer;

    [Header("Bonus Check")]
    public static bool bonusSpawned;

    [Header("Wave 2")]
    public float wave2Time;
    public bool wave2On;
    public int wave2Spawner;

    [Header("Wave 3")]
    public float wave3Time;
    public bool wave3On;
    public int wave3EnemySpeed;

    [Header("Wave 4")]
    public float wave4Time;
    public bool wave4On;
    public int wave4SpawnInterval;

    [Header("Wave 5")]
    public float wave5Time;
    public static bool wave5On;
    public int wave5Spawner;

    [Header("Wave 6")]
    public float wave6Time;
    public bool wave6On;
    public int wave6EnemySpeed;

    [Header("Wave 7")]
    public float wave7Time;
    public static bool wave7On;
    public int wave7SpawnInterval;

    [Header("Wave 8")]
    public float wave8Time;
    public bool wave8On;
    public int wave8Spawner;

    [Header("Wave 9")]
    public float wave9Time;
    public bool wave9On;
    public int wave9EnemySpeed;

    [Header("Wave 10")]
    public float wave10Time;
    public bool wave10On;
    public int wave10SpawnInterval;

    [Header("Wave 11")]
    public float wave11Time;
    public bool wave11On;
    public int wave11Spawner;

    [Header("Wave 12")]
    public float wave12Time;
    public bool wave12On;
    public int wave12EnemySpeed;

    // Use this for initialization
    void Start()
    {
        StartConditions();
    }

    // Update is called once per frame
    void Update()
    {
        TimerCount();

        Waves();
    }

    void StartConditions()
    {
        diffTimer = 0f;

        wave2On = false;
        wave2Time = 10f;
        wave2Spawner = 6;

        wave3On = false;
        wave3Time = 20f;
        wave3EnemySpeed = 5;

        wave4On = false;
        wave4Time = 30f;
        wave4SpawnInterval = 3;

        wave5On = false;
        wave5Time = 40f;
        wave5Spawner = 8;

        wave6On = false;
        wave6Time = 50f;
        wave6EnemySpeed = 6;

        wave7On = false;
        wave7Time = 60f;
        wave7SpawnInterval = 2;

        wave8On = false;
        wave8Time = 66f;
        wave8Spawner = 10;

        wave9On = false;
        wave9Time = 72f;
        wave9EnemySpeed = 7;

        wave10On = false;
        wave10Time = 78f;
        wave10SpawnInterval = 1;

        wave11On = false;
        wave11Time = 84f;
        wave11Spawner = 12;

        wave12On = false;
        wave12Time = 90f;
        wave12EnemySpeed = 8;

        bonusSpawned = false;
    }

    void TimerCount()
    {
        if (UIManager.isDead != true && UIManager.isPaused != true)
        {
            diffTimer = diffTimer + 1 * Time.deltaTime;
        }
    }

    void Waves()
    {
        if (diffTimer >= wave2Time && wave2On == false)
        {
            spawnManager.spawnerAmount = wave2Spawner;

            wave2On = true;

            //Debug.Log("spawnerAmount = " + spawnManager.spawnerAmount);
        }

        if (diffTimer >= wave3Time && wave3On == false)
        {
            enemyStats.enemyMoveSpeed = wave3EnemySpeed;

            wave3On = true;

            //Debug.Log("enemyMoveSpeed = " + enemyStats.enemyMoveSpeed);
        }

        if (diffTimer >= wave4Time && wave4On == false)
        {
            spawnManager.spawnManagerInterval = wave4SpawnInterval;

            wave4On = true;

            //Debug.Log("spawnManagerInterval = " + spawnManager.spawnManagerInterval);
        }

        if (diffTimer >= wave5Time && wave5On == false)
        {
            spawnManager.spawnerAmount = wave5Spawner;

            wave5On = true;

            //Debug.Log("spawnerAmount = " + spawnManager.spawnerAmount);
        }

        if (diffTimer >= wave6Time && wave6On == false)
        {
            enemyStats.enemyMoveSpeed = wave6EnemySpeed;

            wave6On = true;

            //Debug.Log("enemyMoveSpeed = " + enemyStats.enemyMoveSpeed);
        }

        if (diffTimer >= wave7Time && wave7On == false)
        {
            spawnManager.spawnManagerInterval = wave7SpawnInterval;

            wave7On = true;

            //Debug.Log("spawnManagerInterval = " + spawnManager.spawnManagerInterval);
        }

        if (diffTimer >= wave8Time && wave8On == false)
        {
            spawnManager.spawnerAmount = wave8Spawner;

            wave8On = true;

            //Debug.Log("spawnerAmount = " + spawnManager.spawnerAmount);
        }

        if (diffTimer >= wave9Time && wave9On == false)
        {
            enemyStats.enemyMoveSpeed = wave9EnemySpeed;

            wave9On = true;

            //Debug.Log("enemyMoveSpeed = " + enemyStats.enemyMoveSpeed);
        }

        if (diffTimer >= wave10Time && wave10On == false)
        {
            spawnManager.spawnManagerInterval = wave10SpawnInterval;

            wave10On = true;

            //Debug.Log("spawnManagerInterval = " + spawnManager.spawnManagerInterval);
        }

        if (diffTimer >= wave11Time && wave11On == false)
        {
            spawnManager.spawnerAmount = wave11Spawner;

            wave11On = true;

            //Debug.Log("spawnerAmount = " + spawnManager.spawnerAmount);
        }

        if (diffTimer >= wave12Time && wave12On == false)
        {
            enemyStats.enemyMoveSpeed = wave12EnemySpeed;

            wave12On = true;

            //Debug.Log("enemyMoveSpeed = " + enemyStats.enemyMoveSpeed);
        }
    }
}
