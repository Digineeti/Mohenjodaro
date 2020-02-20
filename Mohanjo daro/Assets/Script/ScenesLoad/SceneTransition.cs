﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    //public string SceneToLoad;
    public string SceneIndex;
    //public string CurrentScene;
    public Animator transition;
    

    private void Start()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ScenePlayer")
        {
            //SceneManager.LoadScene(SceneIndex);
            StartPointGlobalData.Scene = null;
            StartPointGlobalData.Scene = SceneIndex + "Enter";
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene()
    {
        //gameObject.GetComponent<AudioSource>().Play();
        transition = GameObject.Find("CM vcam1").GetComponent<Animator>();
        //GameObject Cinemachine = GameObject.Find("CM vcam1");
        transition.SetTrigger("end");
        yield return new WaitForSeconds(0.5f);
        //StartPointGlobalData.Scene = SceneManager.GetActiveScene().name;
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
