using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int[] angle;
    public int currentAngle;

    // Use this for initialization
    void Start()
    {
        currentAngle = 0;

        transform.rotation = Quaternion.Euler(0, angle[currentAngle], 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
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
