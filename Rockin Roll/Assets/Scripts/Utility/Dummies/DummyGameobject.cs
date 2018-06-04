using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DummyType
{
    ENEMY_DISPLAY,
    BONUS_DISPLAY,
    DUMMY_PLAYER,
    DUMMY_ROTATION,
    DUMMY_EXPLOSION,
    DUMMY_SHATTER,
    DUMMY_CHASING,
    DUMMY_TRIGGER_EXPLOSION,
    DUMMY_EXPLOSION_PLAYER,
    DUMMY_BIG_BOMB,
    DUMMY_TIME
}
public class DummyGameobject : MonoBehaviour
{
    public DummyType dummyType;
    public Transform body;

    public int moveSpeed;

    [Header("Display")]
    Vector3 originPos;
    public GameObject explosionPrefab, shatterPrefab;

    [Header("Chasing")]
    [SerializeField]
    Transform[] patrolPoints;
    int currentPoint;
    Transform target;

    [Header("Bomb")]
    public GameObject detectObject;
    bool blowUp = false;
    public static bool hasBlowUp = false;
    Animator anim;

    [Header("Time")]
    public GameObject timeEnemy;

    private void Start()
    {
        switch (dummyType)
        {
            case DummyType.ENEMY_DISPLAY:
                break;
            case DummyType.BONUS_DISPLAY:
                break;
            case DummyType.DUMMY_ROTATION:
                break;
            case DummyType.DUMMY_PLAYER:
                transform.position = patrolPoints[0].position;
                currentPoint = 0;
                break;
            case DummyType.DUMMY_EXPLOSION:
                originPos = transform.position;
                break;
            case DummyType.DUMMY_SHATTER:
                originPos = transform.position;
                break;
            case DummyType.DUMMY_CHASING:
                target = GameObject.Find("DummyPlayerChased").transform;
                break;
            case DummyType.DUMMY_TRIGGER_EXPLOSION:
                anim = GetComponentInChildren<Animator>();
                originPos = transform.position;
                break;
            case DummyType.DUMMY_EXPLOSION_PLAYER:
                originPos = transform.position;
                break;
            case DummyType.DUMMY_BIG_BOMB:
                break;
            case DummyType.DUMMY_TIME:
                transform.position = patrolPoints[0].position;
                currentPoint = 0;
                originPos = timeEnemy.transform.position;
                break;
            default:
                break;
        }
    }
    private void Update()
    {
        switch (dummyType)
        {
            case DummyType.ENEMY_DISPLAY:
                break;
            case DummyType.BONUS_DISPLAY:
                break;
            case DummyType.DUMMY_ROTATION:
                break;
            case DummyType.DUMMY_PLAYER:
                if (transform.position == patrolPoints[currentPoint].position)
                {
                    transform.Rotate(0, 90, 0);
                    currentPoint++;

                    if (currentPoint >= patrolPoints.Length)
                    {
                        currentPoint = 0;
                    }
                }
                transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
                break;
            case DummyType.DUMMY_EXPLOSION:
                transform.Translate(transform.TransformDirection(transform.right) * moveSpeed * Time.deltaTime);
                break;
            case DummyType.DUMMY_SHATTER:
                transform.Translate(transform.TransformDirection(transform.right) * moveSpeed * Time.deltaTime);
                break;
            case DummyType.DUMMY_CHASING:
                transform.Translate(Vector3.forward * (Time.deltaTime * moveSpeed));
                if (target == null)
                {
                    return;
                }
                transform.LookAt(target);
                break;
            case DummyType.DUMMY_TRIGGER_EXPLOSION:
                if (blowUp == true)
                {
                    StartCoroutine(TriggerExplosions());
                }

                break;
            case DummyType.DUMMY_EXPLOSION_PLAYER:
                if (hasBlowUp == true)
                {
                    transform.position = originPos;
                    hasBlowUp = false;
                    return;
                }
                transform.Translate(transform.TransformDirection(transform.right) * moveSpeed * Time.deltaTime);
                break;
            case DummyType.DUMMY_TIME:
                if (transform.position == patrolPoints[currentPoint].position)
                {
                    transform.Rotate(0, 90, 0);
                    currentPoint++;

                    if (currentPoint >= patrolPoints.Length)
                    {
                        currentPoint = 0;
                    }
                }
                transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
                if (transform.position == patrolPoints[0].position)
                {
                    timeEnemy.transform.position = originPos;
                }
                break;
            default:
                break;
        }
        //transform.Translate(transform.TransformDirection(transform.right) * moveSpeed * Time.deltaTime);
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
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            blowUp = true;
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

    IEnumerator TriggerExplosions()
    {
        detectObject.SetActive(false);
        anim.SetTrigger("Explode");
        gameObject.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(3f);
        body.gameObject.SetActive(false);
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(1f);
        transform.position = originPos;
        body.gameObject.SetActive(true);
        gameObject.GetComponent<Collider>().enabled = true;
        detectObject.SetActive(true);
        blowUp = false;
        hasBlowUp = true;
    }


}
