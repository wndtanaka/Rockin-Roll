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

    public float chaseRadius;
    public Transform target;
    public bool isChasing = false;

    void Awake()
    {
        enemyStats = GameObject.Find("GameManager").GetComponent<EnemyStats>();
    }

    // Use this for initialization
    void Start()
    {
        moveSpeed = enemyStats.enemyMoveSpeed;
        rotationAngle = enemyStats.enemyRotation;

        transform.Rotate(new Vector3(0, rotationAngle, 0));

        deathChoice = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * moveSpeed));

        if (target == null)
        {
            return;
        }
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= chaseRadius && !isChasing)
        {
            isChasing = !isChasing;
            transform.LookAt(target);
            Debug.Log("Got you");
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

        }

        if (other.gameObject.CompareTag("Enemy"))
        {

            if (deathChoice == 0 && other.gameObject.GetComponent<HomingEnemy>().deathChoice == 0)
            {
                Instantiate(shatterPrefab, transform.position, transform.rotation);
            }

            if (deathChoice == 1 && other.gameObject.GetComponent<HomingEnemy>().deathChoice == 0)
            {
                Instantiate(shatterPrefab, transform.position, transform.rotation);
            }

            if (deathChoice == 0 && other.gameObject.GetComponent<HomingEnemy>().deathChoice == 1)
            {
                Instantiate(shatterPrefab, transform.position, transform.rotation);
            }

            if (deathChoice == 1 && other.gameObject.GetComponent<HomingEnemy>().deathChoice == 1)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
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

        //if (other.gameObject.CompareTag("WallCollider"))
        //{
        //    Physics.IgnoreCollision(gameObject.GetComponent<BoxCollider>(), other.gameObject.GetComponent<BoxCollider>());
        //}
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
