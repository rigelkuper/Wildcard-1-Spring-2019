using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonQuit : MonoBehaviour
{
    public void quitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
