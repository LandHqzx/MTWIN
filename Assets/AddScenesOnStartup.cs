using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddScenesOnStartup : MonoBehaviour
{
    public List<string> sceneNames;

    void Start()
    {
        foreach (string sceneName in sceneNames)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
    }
}
