using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int enemyMoveSpeed;

    public int enemyRotation;

    public bool randomRotationOn;

    public int[] randomRotationChoice;

    // Use this for initialization
    void Start()
    {
        enemyMoveSpeed = 4;
        randomRotationOn = false;
        enemyRotation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (randomRotationOn == true)
        {
            RandomRotateFunction();
        }
    }

    void RandomRotateFunction()
    {
        int currentRandom = Random.Range(0, randomRotationChoice.Length);

        enemyRotation = randomRotationChoice[currentRandom];
    }
}
