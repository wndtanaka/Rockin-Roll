using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb2 : MonoBehaviour
{
    public int moveSpeed;

    public EnemyStats enemyStats;

    public int rotationAngle;

    public Vector3 enemyHitLocation;

    public GameObject explosionPrefab, shatterPrefab, detectObject;

    public Animator anim;

    public Material[] enemyMats;

    public bool blowUp, blowUpStarted, playerDetected;

    public Renderer rend;

    void Awake()
    {
        enemyStats = GameObject.Find("GameManager").GetComponent<EnemyStats>();
        rend = gameObject.GetComponent<MeshRenderer>();
    }

    void Start()
    {
        moveSpeed = enemyStats.enemyMoveSpeed;
        rotationAngle = enemyStats.enemyRotation;
        anim = GetComponent<Animator>();

        transform.Rotate(new Vector3(0, rotationAngle, 0));

        blowUp = false;
        blowUpStarted = false;

        playerDetected = false;
    }

    void Update()
    {
        if (playerDetected == false)
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * moveSpeed));
        }

        if (blowUp == true && blowUpStarted == false)
        {
            StartCoroutine(TriggerExplosions());
        }
    }

    IEnumerator TriggerExplosions()
    {
        blowUpStarted = true;

        detectObject.SetActive(false);

        anim.SetTrigger("Explode");

        yield return new WaitForSeconds(3f);

        Instantiate(explosionPrefab, transform.position, transform.rotation);

        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Enemy":
                // Do Nothing
                break;

            case "Blue Enemy":
                // Do Nothing
                break;

            case "Bomb Enemy":
                Instantiate(shatterPrefab, transform.position, transform.rotation);

                Destroy(gameObject);
                break;

            case "Wall":
                Destroy(gameObject);
                break;

            case "Explosion":
                Physics.IgnoreCollision(gameObject.GetComponent<BoxCollider>(), other.gameObject.GetComponent<SphereCollider>());
                break;

            case "Big Explosion":
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);

                Destroy(gameObject);
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerDetected = true;
            blowUp = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}
