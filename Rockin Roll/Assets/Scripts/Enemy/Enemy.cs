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

    public int randomDeath;

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

        randomDeath = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * moveSpeed));
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy.cs: Enemy hit Player!");
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyHitLocation = new Vector3(other.contacts[0].point.x, 1, other.contacts[0].point.z);

            //Debug.Log(enemyHitLocation);

            if (randomDeath == 0)
            {
                Instantiate(explosionPrefab, enemyHitLocation, transform.rotation);
            }

            if (randomDeath == 1)
            {
                Instantiate(shatterPrefab, enemyHitLocation, Quaternion.identity);
            }

            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Explosion"))
        {
            Destroy(gameObject);
        }
    }
}
