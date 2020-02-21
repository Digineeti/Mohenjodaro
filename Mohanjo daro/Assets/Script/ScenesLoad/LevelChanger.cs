using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public string TransitionScene;           //transition scene name. 


    private void Start()
    { }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ScenePlayer")
        {
            StartPointGlobalData.Scene = null;
            StartPointGlobalData.Scene = TransitionScene + "Enter";
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene()
    {   
        yield return new WaitForSeconds(0.01f);
        SceneManager.LoadScene(TransitionScene);
    }
}
