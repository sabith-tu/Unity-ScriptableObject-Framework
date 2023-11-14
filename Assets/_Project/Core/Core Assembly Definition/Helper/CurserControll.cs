using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurserControll : MonoBehaviour
{
    public void SetCursorState(bool value)
    {
        switch (value)
        {
            case true:
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                break;
            case false:
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                break;
        }
    }
}