using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_rc : MonoBehaviour
{
    private void OnGUI()
    {
        Event e = Event.current;
        if (e.button == 0 && e.isMouse)
        {
            Debug.Log("Left Click");
        }
        else if (e.button == 1)
        {
            Debug.Log("Right Click");
        }
        else if (e.button == 2)
        {
            Debug.Log("Middle Click");
        }
        else if (e.button > 2)
        {
            Debug.Log("Another button in the mouse clicked");
        }
    }
}
