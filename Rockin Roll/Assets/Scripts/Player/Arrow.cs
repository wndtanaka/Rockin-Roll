using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int[] angle;
    public int currentAngle;

    void Start()
    {
        currentAngle = 0;

        transform.rotation = Quaternion.Euler(0, angle[currentAngle], 0);
    }

    void LateUpdate()
    {
        if (GameManager.Instance.InputController.ChangeDirection)
        {
            if (currentAngle == 3)
            {
                currentAngle = 0;
            }
            else
            {
                currentAngle = currentAngle + 1;
            }

            transform.rotation = Quaternion.Euler(0,angle[currentAngle],0);
        }
    }
}
