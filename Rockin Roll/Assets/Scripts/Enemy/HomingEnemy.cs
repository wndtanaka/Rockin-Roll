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
        switch (other.gameObject.tag)
        {
            case "Player":
                // Do Nothing
                break;

            case "Enemy":
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);

                Destroy(gameObject);
                break;

            case "Blue Enemy":
                Instantiate(shatterPrefab, transform.position, Quaternion.identity);

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
            
        }
    }
}
