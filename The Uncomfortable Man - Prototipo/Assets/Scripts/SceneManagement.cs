using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public string nextScene;
    
    private void Update()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void SetScene(string _nextScene)
    {
        nextScene = _nextScene;
    }
}
