using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public bool Move;
    public bool ChangeDirection;
    public bool MoveIndex;
    public bool Pause;

    private void Update()
    {
        Move = Input.GetKey(KeyCode.Space);
        ChangeDirection = Input.GetKeyUp(KeyCode.Space);
        MoveIndex = Input.GetKeyDown(KeyCode.Space);
        Pause = Input.GetKeyDown(KeyCode.Escape);
    }
}
