using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionDoneSeconds;

    // Use this for initialization
    void Start()
    {
        explosionDoneSeconds = 1f;

        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Explosion.cs: Explosion hit Player!");
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("WallCollider"))
        {
            Physics.IgnoreCollision(other.gameObject.GetComponent<BoxCollider>(), gameObject.GetComponent<BoxCollider>());
        }
    }
}
