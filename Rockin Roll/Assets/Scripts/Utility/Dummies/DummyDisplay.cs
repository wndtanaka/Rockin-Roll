using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyDisplay : MonoBehaviour
{
    public GameObject[] enemiesPrefab;

    float timer;

    private void Start()
    {
        enemiesPrefab[0].SetActive(true);
        StartCoroutine(ChangeDisplay(0));
    }

    IEnumerator ChangeDisplay(int i)
    {
        yield return new WaitForSeconds(2);
        enemiesPrefab[i].SetActive(false);
        enemiesPrefab[i + 1].SetActive(true);
        yield return new WaitForSeconds(2);
        enemiesPrefab[i + 1].SetActive(false);
        enemiesPrefab[i + 2].SetActive(true);
        yield return new WaitForSeconds(2);
        enemiesPrefab[i + 2].SetActive(false);
        enemiesPrefab[i + 3].SetActive(true);
        yield return new WaitForSeconds(2);
        enemiesPrefab[i + 3].SetActive(false);
        enemiesPrefab[i].SetActive(true);
        StartCoroutine(ChangeDisplay(i));
    }
}
