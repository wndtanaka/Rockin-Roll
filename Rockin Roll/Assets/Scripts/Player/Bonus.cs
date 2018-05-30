using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public int moveSpeed;

    public bool startEnemyDestroy;

    public float bonusPoints;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Bonus here!");

        moveSpeed = 4;

        startEnemyDestroy = true;

        bonusPoints = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * moveSpeed));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Bonus.cs: Player gets Extra Points!");

            Score.playerScore = Score.playerScore + bonusPoints;

            Difficulty.bonusSpawned = false;

            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            Difficulty.bonusSpawned = false;

            Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && startEnemyDestroy == true)
        {
            Destroy(other.gameObject);

            startEnemyDestroy = false;
        }
    }
}
