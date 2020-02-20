using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllMainSceneLoad : MonoBehaviour
{
   public static AllMainSceneLoad Instance { set; get; }

    private void Awake()
    {
        Instance = this;
        Load("Desert");
        Load("DesertToGrassLand1");

    }

    public void Load(string SceneName)
    {
        if (!SceneManager.GetSceneByName(SceneName).isLoaded)
            SceneManager.LoadSceneAsync(SceneName,LoadSceneMode.Additive);
    }

    public void Unload(string SceneName)
    {
        if (SceneManager.GetSceneByName(SceneName).isLoaded)
            SceneManager.UnloadSceneAsync(SceneName); 

    }
}
