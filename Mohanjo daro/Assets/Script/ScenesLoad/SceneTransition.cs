using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    //public string SceneToLoad;
    public int SceneIndex;
    public Animator transition;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ScenePlayer")
        {          
            //SceneManager.LoadScene(SceneIndex);
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene()
    {
        transition.SetTrigger("end");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneIndex);
    }

    //AsyncOperation operation = SceneManager.LoadSceneAsync(Sceneindex);
    //while (!operation.isDone)
    //{
    //    transition.SetTrigger("Start");
    //    yield return null;
    //    //SceneManager.LoadScene(Sceneindex);
    //}
}
