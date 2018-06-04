using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPlayer : MonoBehaviour
{
    public float rotation;
    private void Start()
    {
        InvokeRepeating("Rotate",1,1);
    }
    void Rotate()
    {
        transform.Rotate(0, rotation, 0);
    }
}
