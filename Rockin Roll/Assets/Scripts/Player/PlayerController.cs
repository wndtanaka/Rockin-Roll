using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3[] transformDirection = new Vector3[] { Vector3.forward, Vector3.right, Vector3.back, Vector3.left };

    public float speed = 20;

    public GameObject playerDeath;

    int index = 0;
    public static bool changeDirection = false;
    public static bool reverseDirection = false;

    InputController inputController;

    // creating delegate function to handle reverse array
    public event OnReverseDirection onReverseDirection;

    private void Start()
    {
        inputController = GameManager.Instance.InputController;
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        //space key down
        if (inputController.MoveIndex)
        {
            index++;
            if (index >= transformDirection.Length)
            {
                index = 0;
            }
        }
        if (inputController.Move)
        {
            transform.Translate(transformDirection[index] * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Enemy":
                Instantiate(playerDeath, transform.position, Quaternion.identity);
                UIManager.isDead = true;
                Destroy(gameObject);
                break;
            case "Explosion":
                Instantiate(playerDeath, transform.position, Quaternion.identity);
                UIManager.isDead = true;
                Destroy(gameObject);
                break;
            case "Shatter":
                Instantiate(playerDeath, transform.position, Quaternion.identity);
                Destroy(other.gameObject);
                StartCoroutine(ReverseDirection());
                break;
            case "Blue Enemy":
                Instantiate(playerDeath, transform.position, Quaternion.identity);
                UIManager.isDead = true;
                Destroy(gameObject);
                break;
            case "Big Explosion":
                Instantiate(playerDeath, transform.position, Quaternion.identity);
                UIManager.isDead = true;
                Destroy(gameObject);
                break;
        }
    }

    IEnumerator ReverseDirection()
    {
        yield return new WaitUntil(() => inputController.ChangeDirection);
        // call the subscribed function
        onReverseDirection.Invoke();
        // reverse array
        System.Array.Reverse(transformDirection);
    }
}