using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTest : MonoBehaviour
{
    public SpawnManager spawnManager;

    public EnemyStats enemyStats;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            switch (spawnManager.spawnerAmount)
            {
                case 1:
                    spawnManager.spawnerAmount = 2;
                    break;
                case 2:
                    spawnManager.spawnerAmount = 3;
                    break;
                case 3:
                    spawnManager.spawnerAmount = 10;
                    break;
                case 10:
                    spawnManager.spawnerAmount = 1;
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            switch (enemyStats.enemyMoveSpeed)
            {
                case 4:
                    enemyStats.enemyMoveSpeed = 8;
                    break;
                case 8:
                    enemyStats.enemyMoveSpeed = 12;
                    break;
                case 12:
                    enemyStats.enemyMoveSpeed = 16;
                    break;
                case 16:
                    enemyStats.enemyMoveSpeed = 4;
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            enemyStats.randomRotationOn = !enemyStats.randomRotationOn;
        }
    }
}
