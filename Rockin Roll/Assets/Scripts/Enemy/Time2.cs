﻿using System.Collections;
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

        blowUp = false;
        blowUpStarted = false;

        playerDetected = false;
        moveStopBool = false;

        bonusPoints = 10f;

        Destroy(gameObject, 60);

        //StartCoroutine(MoveStop());
    }

    void Update()
    {
        if (playerDetected == false && moveStopBool == false)
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * moveSpeed));
        }

        /*if (blowUp == true && blowUpStarted == false)
        {
            StartCoroutine(TriggerExplosions());
        }

        if (playerDetected == true || moveStopBool == true)
        {
            transform.position = stopTransform;
        }*/
    }

    IEnumerator TriggerExplosions()
    {
        blowUpStarted = true;

        detectObject.SetActive(false);

        anim.SetTrigger("Explode");

        yield return new WaitForSeconds(3f);

        Instantiate(explosionPrefab, transform.position, transform.rotation);

        //Score.playerScore = Score.playerScore + bonusPoints;

        Destroy(gameObject);
    }

    IEnumerator MoveStop()
    {


        yield return new WaitForSeconds(Random.Range(1f, 2f));

        moveStopBool = true;

        stopTransform = transform.position;
    }

    void OnCollisionEnter(Collision other)
    {
        /*switch (other.gameObject.tag)
        {
            case "Enemy":
                Physics.IgnoreCollision(gameObject.GetComponent<BoxCollider>(), other.gameObject.GetComponent<BoxCollider>());
                break;

            case "Blue Enemy":
                Physics.IgnoreCollision(gameObject.GetComponent<BoxCollider>(), other.gameObject.GetComponent<BoxCollider>());
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
        }*/
    }

    /*void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            
        }
    }*/

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().speed = enemyStats.enemyMoveSpeed / 2;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().speed = 20f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}
