using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Vector3[] transformDirection = new Vector3[] { Vector3.forward, Vector3.right, Vector3.back, Vector3.left };

    public float speed = 2;

    int index = 0;
    Rigidbody rb;
    bool reverseDirection = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!reverseDirection)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                index++;
                if (index >= transformDirection.Length)
                {
                    index = 0;
                }
            }
            if (Input.GetKey(KeyCode.Space))
            {
                transform.Translate(transformDirection[index] * speed * Time.deltaTime);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                reverseDirection = !reverseDirection;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                index++;
                if (index >= transformDirection.Length)
                {
                    index = 0;
                }
            }
            if (Input.GetKey(KeyCode.Space))
            {
                transform.Translate(transformDirection[index] * speed * Time.deltaTime);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                reverseDirection = !reverseDirection;
            }
        }
    }
}

