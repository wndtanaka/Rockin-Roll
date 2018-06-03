using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public int[] angles;
    public int currentAngle;

    public float speed = 20;

    public bool reversed;

    public GameObject playerDeath, rightArrow, leftArrow;

    private void Start()
    {
        currentAngle = 0;

        reversed = false;
    }

    void Update()
    {
        PlayerMovement();

        CheckArrow();
    }

    void PlayerMovement()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.Space) && UIManager.isGameStart && !UIManager.isPaused)
        {
            CheckNextAngle();

            transform.localRotation = Quaternion.Euler(transform.rotation.x, angles[currentAngle], transform.rotation.z);

            //CheckNextAngle();
        }
    }

    void CheckNextAngle()
    {
        if (reversed == false)
        {
            if (currentAngle == 3)
            {
                currentAngle = 0;
            }

            else
            {
                currentAngle += 1;
            }
        }

        if (reversed == true)
        {
            if (currentAngle == 0)
            {
                currentAngle = 3;
            }

            else
            {
                currentAngle -= 1;
            }
        }

        Debug.Log(currentAngle);
    }

    void CheckArrow()
    {
        if (reversed == false)
        {
            rightArrow.SetActive(true);
            leftArrow.SetActive(false);
        }
        else
        {
            rightArrow.SetActive(false);
            leftArrow.SetActive(true);
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
                reversed = !reversed;
                Destroy(other.gameObject);
                
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

            case "Bomb Enemy":
                Instantiate(playerDeath, transform.position, Quaternion.identity);
                UIManager.isDead = true;
                Destroy(gameObject);
                break;
        }
    }
}