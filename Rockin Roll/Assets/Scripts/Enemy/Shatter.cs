﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{
    public int moveSpeed;

    public EnemyStats enemyStats;

    void Awake()
    {
        enemyStats = GameObject.Find("GameManager").GetComponent<EnemyStats>();
    }

    // Use this for initialization
    void Start()
    {
        moveSpeed = enemyStats.enemyMoveSpeed;
        moveSpeed = moveSpeed * 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * moveSpeed));
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Shatter.cs: Shatter hit Player!");
        }

        if (other.gameObject.CompareTag("Shatter"))
        {
            Destroy(gameObject);
        }
    }
}