using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public bool explosionDone;

    public float explosionDoneSeconds;

    // Use this for initialization
    void Start()
    {
        explosionDone = false;

        explosionDoneSeconds = 1f;

        StartCoroutine(ExplosionFinished());
    }

    // Update is called once per frame
    void Update()
    {
        if (explosionDone == true)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ExplosionFinished()
    {
        // wait for timer

        yield return new WaitForSeconds(explosionDoneSeconds);

        explosionDone = true;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Explosion.cs: Explosion hit Player!");
        }
    }
}
