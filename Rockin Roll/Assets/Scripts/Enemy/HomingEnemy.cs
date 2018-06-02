using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemy : MonoBehaviour
{
    public int moveSpeed;

    public EnemyStats enemyStats;

    public int rotationAngle;

    public Vector3 enemyHitLocation;

    public GameObject explosionPrefab, shatterPrefab;

    public int deathChoice;

    Transform target;

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

        if (target == null && UIManager.isDead)
        {
            return;
        }
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * moveSpeed));

        if (target == null)
        {
            return;
        }
        transform.LookAt(target);
    }

    private void LateUpdate()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

        }

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

        if (other.gameObject.CompareTag("Bomb Enemy"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyHeadOn"))
        {
            deathChoice = 1;
        }
    }
}
