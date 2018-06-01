using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeEnemy : MonoBehaviour
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

    void Start()
    {
        moveSpeed = enemyStats.enemyMoveSpeed;
        rotationAngle = enemyStats.enemyRotation;

        transform.Rotate(new Vector3(0, rotationAngle, 0));

        deathChoice = 0;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * moveSpeed));
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Blue Enemy"))
        {
            Instantiate(shatterPrefab, transform.position, transform.rotation);

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Slow");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Not Slow");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(25,25,25));
    }
}
