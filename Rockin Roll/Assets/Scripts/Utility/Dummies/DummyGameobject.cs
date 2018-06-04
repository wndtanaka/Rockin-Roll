using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DummyType
{
    ENEMY_DISPLAY,
    BONUS_DISPLAY,
    DUMMY_ROTATION,
    DUMMY_EXPLOSION,
    DUMMY_SHATTER,
}
public class DummyGameobject : MonoBehaviour
{
    public DummyType dummyType;
    public Transform body;

    public int moveSpeed;
    public GameObject explosionPrefab, shatterPrefab;

    Vector3 originPos;

    private void Start()
    {
        originPos = transform.position;
    }
    private void Update()
    {
        transform.Translate(transform.TransformDirection(transform.right) * moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        switch (dummyType)
        {
            case DummyType.ENEMY_DISPLAY:
                break;
            case DummyType.BONUS_DISPLAY:
                break;
            case DummyType.DUMMY_ROTATION:
                break;
            case DummyType.DUMMY_EXPLOSION:
                StartCoroutine(Explode());
                break;
            case DummyType.DUMMY_SHATTER:
                StartCoroutine(Shatter());
                break;
            default:
                break;
        }
    }

    IEnumerator Explode()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        body.gameObject.SetActive(false);
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(2);
        transform.position = originPos;
        body.gameObject.SetActive(true);
        gameObject.GetComponent<Collider>().enabled = true;
    }

    IEnumerator Shatter()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        body.gameObject.SetActive(false);
        GameObject go = Instantiate(shatterPrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(2);
        Destroy(go.gameObject);
        transform.position = originPos;
        body.gameObject.SetActive(true);
        gameObject.GetComponent<Collider>().enabled = true;
    }
}
