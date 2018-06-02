using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int moveSpeed;

    public EnemyStats enemyStats;

    public int rotationAngle;

    public Vector3 enemyHitLocation;

    public GameObject explosionPrefab, shatterPrefab;

    public int deathChoice;

    public Vector3 startPos;
    public bool buggyX, buggyZ, isBugging, bugFlash;
    public Material[] enemyMats;
    public Renderer rend;
    public float startSpeed, testSpeed;

    void Awake()
    {
        enemyStats = GameObject.Find("GameManager").GetComponent<EnemyStats>();
    }

    // Use this for initialization
    void Start()
    {
        moveSpeed = enemyStats.enemyMoveSpeed;
        rotationAngle = enemyStats.enemyRotation;

        transform.Rotate(new Vector3(0,rotationAngle,0));

        deathChoice = 0;

        startPos = transform.localPosition;
        buggyX = false;
        buggyZ = false;
        isBugging = false;
        rend = gameObject.GetComponent<MeshRenderer>();
        bugFlash = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * moveSpeed));

        //BuggyFunction();
    }

    #region Buggy
    void BuggyFunction()
    {
        // Start Z is Moving, keep eye on X
        if (startPos.z != transform.localPosition.z && buggyX == false)
        {
            // Z-axis is Good
            buggyZ = true;

            if (startPos.x != transform.localPosition.x && buggyX == false && buggyZ == true)
            {
                isBugging = true;
            }
        }

        if (startPos.x != transform.localPosition.x && buggyZ == false)
        {
            buggyX = true;

            if (startPos.z != transform.localPosition.z && buggyZ == false && buggyX == true)
            {
                isBugging = true;
            }
        }

        if (buggyZ == true && isBugging == true)
        {
            Vector3 curPos = transform.position;
            curPos.x = startPos.x;
        }
    }
    #endregion

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                // Do Nothing
                break;

            case "Enemy":
                if (deathChoice == 0 && other.gameObject.GetComponent<Enemy>().deathChoice == 0)
                {
                    Instantiate(shatterPrefab, transform.position, transform.rotation);
                }

                if (deathChoice == 1 && other.gameObject.GetComponent<Enemy>().deathChoice == 0)
                {
                    Instantiate(shatterPrefab, transform.position, transform.rotation);
                }

                if (deathChoice == 0 && other.gameObject.GetComponent<Enemy>().deathChoice == 1)
                {
                    Instantiate(shatterPrefab, transform.position, transform.rotation);
                }

                if (deathChoice == 1 && other.gameObject.GetComponent<Enemy>().deathChoice == 1)
                {
                    Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                }

                Destroy(gameObject);
                break;

            case "Blue Enemy":
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);

                Destroy(gameObject);
                break;

            case "Bomb Enemy":
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);

                Destroy(gameObject);
                break;

            case "Wall":
                Destroy(gameObject);
                break;

            case "Explosion":
                Destroy(gameObject);
                break;

            case "Big Explosion":
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);

                Destroy(gameObject);
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyHeadOn"))
        {
            deathChoice = 1;
        }
    }
}
