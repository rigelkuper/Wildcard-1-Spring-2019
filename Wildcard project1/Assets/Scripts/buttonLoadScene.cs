using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonLoadScene : MonoBehaviour
{
    //public string sceneName;

    public void loadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
