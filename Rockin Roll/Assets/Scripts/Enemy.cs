using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform startPos, goTo;

    public float moveSpeed;

    // Use this for initialization
    void Start()
    {
        startPos = gameObject.transform;

        moveSpeed = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * moveSpeed));
        transform.Translate(Vector3.right * (Time.deltaTime * moveSpeed/2));
    }
}
