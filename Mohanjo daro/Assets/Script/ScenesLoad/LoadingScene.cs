﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Load_Scene());
    }

    IEnumerator Load_Scene()
    {
       
        yield return new WaitForSeconds(5f);
        //yield return null;

        SceneManager.LoadScene(10);


    }
}
