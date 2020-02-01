using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    //public string SceneToLoad;
    public int SceneIndex;
    public Animator transition;
    

    private void Start()
    {
       
    }
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
        //gameObject.GetComponent<AudioSource>().Play();

        //GameObject Cinemachine = GameObject.Find("CM vcam1");
        transition.SetTrigger("end");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneIndex);
        //Cinemachine.GetComponent<Animator>().SetTrigger("start");
        transition.SetTrigger("start");
    }

    //AsyncOperation operation = SceneManager.LoadSceneAsync(Sceneindex);
    //while (!operation.isDone)
    //{
    //    transition.SetTrigger("Start");
    //    yield return null;
    //    //SceneManager.LoadScene(Sceneindex);
    //}
}
