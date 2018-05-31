using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyRotation : MonoBehaviour
{
    [SerializeField]
    float xRot;
    [SerializeField]
    float yRot;
    [SerializeField]
    float zRot;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(xRot, yRot, zRot) * Time.deltaTime);
    }
}
