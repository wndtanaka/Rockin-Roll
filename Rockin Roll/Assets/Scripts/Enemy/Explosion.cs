using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionDoneSeconds;

    public Material[] exMats;

    public int randomMat;

    // Use this for initialization
    void Start()
    {
        randomMat = Random.Range(0, 3);

        gameObject.GetComponent<MeshRenderer>().material = exMats[randomMat];

        explosionDoneSeconds = Random.Range(.25f, .75f);

        if (CameraShake.exShake == false)
        {
            CameraShake.exShake = true;
        }

        Destroy(gameObject, explosionDoneSeconds);
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