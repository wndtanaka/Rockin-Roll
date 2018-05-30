using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject rightCircle, leftCircle;

    public int[] angle;
    public int currentAngle;

    PlayerController playerController;



    void Start()
    {
        // getting PlayerController in parent
        playerController = GetComponentInParent<PlayerController>();
        // subscribe to this delegate
        playerController.onReverseDirection += OnReverseDirection;
        currentAngle = 0;

        transform.rotation = Quaternion.Euler(0, angle[currentAngle], 0);
    }

    void LateUpdate()
    {
        if (GameManager.Instance.InputController.ChangeDirection)
        {
            if (currentAngle >= angle.Length - 1)
            {
                currentAngle -= angle.Length - 1;
            }
            else
            {
                currentAngle = currentAngle + 1;
            }

            transform.rotation = Quaternion.Euler(0, angle[currentAngle], 0);
        }
    }

    void OnReverseDirection()
    {      
        // reverse array
        System.Array.Reverse(angle);
        currentAngle += 2;

        if (rightCircle.activeSelf == true)
        {
            leftCircle.SetActive(true);
            rightCircle.SetActive(false);
        }

        else
        {
            leftCircle.SetActive(false);
            rightCircle.SetActive(true);
        }
    }

}
