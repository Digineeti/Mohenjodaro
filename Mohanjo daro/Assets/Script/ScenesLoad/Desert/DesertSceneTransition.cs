using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DesertSceneTransition : MonoBehaviour
{
    public string TransitionScene;           //transition scene name.
    private Animator transition;         //camera transition effect.
    

    private void Start()
    {}
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
        transition = GameObject.Find("CinemachineCamera").GetComponent<Animator>();
        transition.SetTrigger("end");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(TransitionScene);
        transition.SetTrigger("start");
    }   
}
