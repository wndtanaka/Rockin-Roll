using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Vector3 originalPos;

    public static bool exShake, shatterShake;

    public float shakeTime;

    public GameObject exScreen, cam1, cam2;

    // Use this for initialization
    void Start()
    {
        originalPos = transform.position;
        exShake = false;

        shakeTime = .1f;

        shatterShake = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (exShake == true)
        {
            StartCoroutine(CamShake());
        }

        if (shatterShake == true && exShake == false)
        {
            StartCoroutine(ShatShake());
        }
    }

    IEnumerator CamShake()
    {
        exScreen.SetActive(true);

        transform.position = cam1.transform.position;

        yield return new WaitForSeconds(shakeTime);

        transform.position = cam2.transform.position;

        yield return new WaitForSeconds(shakeTime);

        transform.position = cam1.transform.position;

        yield return new WaitForSeconds(shakeTime);

        transform.position = cam2.transform.position;

        yield return new WaitForSeconds(shakeTime);

        transform.position = originalPos;

        exScreen.SetActive(false);

        exShake = false;
    }

    IEnumerator ShatShake()
    {
        transform.position = cam1.transform.position;

        yield return new WaitForSeconds(shakeTime);

        transform.position = cam2.transform.position;

        yield return new WaitForSeconds(shakeTime);

        transform.position = cam1.transform.position;

        yield return new WaitForSeconds(shakeTime);

        transform.position = cam2.transform.position;

        yield return new WaitForSeconds(shakeTime);

        transform.position = originalPos;

        shatterShake = false;
    }
}
