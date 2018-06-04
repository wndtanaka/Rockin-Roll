using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time2 : MonoBehaviour
{
    public int moveSpeed;

    public EnemyStats enemyStats;

    public int rotationAngle;

    public Vector3 enemyHitLocation;

    public GameObject explosionPrefab, shatterPrefab, detectObject;

    public Animator anim;

    public Material[] enemyMats;

    public bool blowUp, blowUpStarted, playerDetected, moveStopBool;

    public Renderer rend;

    public float bonusPoints;

    public Vector3 stopTransform;

    void Awake()
    {
        enemyStats = GameObject.Find("GameManager").GetComponent<EnemyStats>();
        //rend = gameObject.GetComponent<MeshRenderer>();
    }

    void Start()
    {
        //moveSpeed = enemyStats.enemyMoveSpeed;

        moveSpeed = 2;

        rotationAngle = enemyStats.enemyRotation;
        //anim = GetComponent<Animator>();

        transform.Rotate(new Vector3(0, rotationAngle, 0));

        //Destroy(gameObject, 60);

        StartCoroutine(TimeGuyDie());
    }

    void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * moveSpeed));
    }

    IEnumerator TimeGuyDie()
    {


        yield return new WaitForSeconds(60);

        Difficulty.timeGuySpawned = false;

        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player2>().speed = moveSpeed * 2;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().moveSpeed = moveSpeed;
        }

        if (other.gameObject.CompareTag("Blue Enemy"))
        {
            other.gameObject.GetComponent<HomingEnemy>().moveSpeed = moveSpeed;
        }

        if (other.gameObject.CompareTag("Shatter"))
        {
            other.gameObject.GetComponent<Shatter>().moveSpeed = moveSpeed;
        }
        if (other.gameObject.CompareTag("Dummy"))
        {
            other.gameObject.GetComponent<DummyGameobject>().moveSpeed = moveSpeed * 2;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player2>().speed = 20f;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().moveSpeed = enemyStats.enemyMoveSpeed;
        }

        if (other.gameObject.CompareTag("Blue Enemy"))
        {
            other.gameObject.GetComponent<HomingEnemy>().moveSpeed = enemyStats.enemyMoveSpeed;
        }

        if (other.gameObject.CompareTag("Shatter"))
        {
            other.gameObject.GetComponent<Shatter>().moveSpeed = enemyStats.enemyMoveSpeed;
        }
        if (other.gameObject.CompareTag("Dummy"))
        {
            other.gameObject.GetComponent<DummyGameobject>().moveSpeed = 8;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}
