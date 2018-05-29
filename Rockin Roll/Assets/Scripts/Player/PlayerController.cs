using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3[] transformDirection = new Vector3[] { Vector3.forward, Vector3.right, Vector3.back, Vector3.left };

    public float speed = 20;

    int index = 0;
    bool changeDirection = false;

    void Update()
    {
        #region Player Controller
        if (!changeDirection)
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
                changeDirection = !changeDirection;
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
                changeDirection = !changeDirection;
            }
        }
        #endregion

    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Enemy":
                UIManager.isDead = true;
                Destroy(gameObject);
                break;
            case "Explosion":
                UIManager.isDead = true;
                Destroy(gameObject);
                break;
            case "Shatter":
                UIManager.isDead = true;
                Destroy(gameObject);
                break;
        }
    }
}