﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prologuescenetransition : MonoBehaviour
{
    public GameObject player;
    public GameObject enterposition;
    public Animator tranmisionamin;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ScenePlayer")
        {
           
            StartCoroutine(loadScene());
        }
    }
    IEnumerator loadScene()
    {
        player = GameObject.FindGameObjectWithTag("ScenePlayer");
        tranmisionamin.SetBool("Start", true);
        yield return new WaitForSeconds(.5f);
        player.transform.position = new Vector3(enterposition.transform.position.x, enterposition.transform.position.y, 0f);
        StartCoroutine(Transition_end());
       
    }
    IEnumerator Transition_end()
    {
        yield return new WaitForSeconds(.5f);
        tranmisionamin.SetBool("Start", false);
    }

}
