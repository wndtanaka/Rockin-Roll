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
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * moveSpeed));
    }

    void OnDeath()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy.cs: Enemy hit Player!");
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            //gameObject.GetComponent<BoxCollider>().enabled = false;

            //enemyHitLocation = new Vector3(other.contacts[0].point.x, 1, other.contacts[0].point.z);
            //Vector3 midpoint = (enemyHitLocation + transform.position) / 2;

            if (deathChoice == 0)
            {
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }

            if (deathChoice == 1 && other.gameObject.GetComponent<Enemy>().deathChoice == 0)
            {
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }

            if (deathChoice == 0 && other.gameObject.GetComponent<Enemy>().deathChoice == 1)
            {
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }

            if (deathChoice == 1 && other.gameObject.GetComponent<Enemy>().deathChoice == 1)
            {
                Instantiate(shatterPrefab, transform.position, transform.rotation);
            }

            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Explosion"))
        {
            //Instantiate(explosionPrefab, transform.position, transform.rotation);

            Destroy(gameObject);
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
