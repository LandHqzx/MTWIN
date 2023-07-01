using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAdditionalScenes : MonoBehaviour
{
    public List<string> sceneNames;

    void Start()
    {
        foreach (string sceneName in sceneNames)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
    }

    void OnDestroy()
    {
        foreach (string sceneName in sceneNames)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }
}
