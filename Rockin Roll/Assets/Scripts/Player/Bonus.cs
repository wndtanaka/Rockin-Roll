using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public ItemType itemType;

    public int moveSpeed;

    public bool startEnemyDestroy;

    public float bonusPoints;

    // Use this for initialization
    void Start()
    {
        //Debug.Log("Bonus here!");

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
            switch (itemType)
            {
                case ItemType.Bonus:
                    Score.playerScore = Score.playerScore + bonusPoints;
                    break;
                case ItemType.Shield:
                    // TODO Give player shield
                    break;
                case ItemType.Invisibility:
                    // TODO Give player invisibility for several seconds
                    break;
                case ItemType.SlowMotion:
                    // TODO Slow enemy movement for several seconds
                    break;
                default:
                    break;
            }

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
        /*if (startEnemyDestroy == true)
        {
            switch (other.gameObject.tag)
            {
                case "Enemy":
                    Destroy(other.gameObject);

                    startEnemyDestroy = false;
                    break;

                case "Blue Enemy":
                    Destroy(other.gameObject);

                    startEnemyDestroy = false;
                    break;

                case "Bomb Enemy":
                    Destroy(other.gameObject);

                    startEnemyDestroy = false;
                    break;
            }
        }*/

        /*if (other.gameObject.CompareTag("Enemy") && startEnemyDestroy == true)
        {
            Destroy(other.gameObject);

            startEnemyDestroy = false;
        }

        if (other.gameObject.CompareTag("Blue Enemy") && startEnemyDestroy == true)
        {
            Destroy(other.gameObject);

            startEnemyDestroy = false;
        }*/
    }
}
