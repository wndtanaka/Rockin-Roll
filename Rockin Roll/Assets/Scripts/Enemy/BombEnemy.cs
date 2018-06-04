using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : MonoBehaviour
{
    public int moveSpeed;

    public EnemyStats enemyStats;

    public int rotationAngle;

    public Vector3 enemyHitLocation;

    public GameObject explosionPrefab, shatterPrefab;

    public int deathChoice;

    public float triggerRadius = 15;
    float distance;

    Transform target;
    Animator anim;

    void Awake()
    {
        enemyStats = GameObject.Find("GameManager").GetComponent<EnemyStats>();
    }

    void Start()
    {
        moveSpeed = enemyStats.enemyMoveSpeed;
        rotationAngle = enemyStats.enemyRotation;
        anim = GetComponent<Animator>();

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
        distance = Vector3.Distance(transform.position, target.position);
        if (distance <= triggerRadius)
        {
            StartCoroutine(TriggerExplosions());
        }
    }

    IEnumerator TriggerExplosions()
    {
        anim.SetTrigger("Explode");
        yield return new WaitForSeconds(3);
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        if (distance <= triggerRadius)
        {
            Destroy(target.gameObject);
            UIManager.isDead = true;
        }
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            /*Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);*/
        }

        if (other.gameObject.CompareTag("Blue Enemy"))
        {
            /*Instantiate(shatterPrefab, transform.position, transform.rotation);

            Destroy(gameObject);*/
        }

        if (other.gameObject.CompareTag("Bomb Enemy"))
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);

            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Explosion"))
        {
            Physics.IgnoreCollision(gameObject.GetComponent<BoxCollider>(), other.gameObject.GetComponent<SphereCollider>());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyHeadOn"))
        {
            deathChoice = 1;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}
