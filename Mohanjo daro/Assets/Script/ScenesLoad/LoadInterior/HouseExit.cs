﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class HouseExit : MonoBehaviour
{
    //public Tilemap ExteriorHouse;
    //public Tilemap ExteriorProps;

    //public Tilemap InteriorHouse;
    //public Tilemap InteriorProps;

    public Tilemap Exterior;
    public Tilemap Roof;
   
    public GameObject Interiror;
    private Animator transition;

    public GameObject Entry;
    public GameObject Exit;

    public GameObject Entry2;
    public GameObject Exit2;

    public Animator ExteriorDoor;
    public Animator ExteriorDoor2;

    public GameObject Exterior_Door1;
    public GameObject Exterior_Door2;
    //bool check;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ScenePlayer")
        {
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene()
    {      
        transition = GameObject.Find("TransitionCanvas").GetComponentInChildren<Image>().GetComponent<Animator>();       
        yield return new WaitForSeconds(0.3f);
        GameObject player = GameObject.FindGameObjectWithTag("ScenePlayer").gameObject;


        if (Exit.gameObject.activeSelf)
        {
            Exit.SetActive(false);
            Entry.SetActive(true);

            Exit2.SetActive(false);
            Entry2.SetActive(true);

            GameObject Main_Light = GameObject.Find("GlobalLight");
            Main_Light.GetComponent<Light2D>().intensity = 0.8f;

            ExteriorDoor.SetTrigger("end");
            ExteriorDoor2.SetTrigger("end");

            ExteriorDoor.GetComponent<SpriteRenderer>().sortingLayerName ="Props";
            ExteriorDoor.GetComponent<SpriteRenderer>().sortingOrder = 0;

            ExteriorDoor2.GetComponent<SpriteRenderer>().sortingLayerName = "Props";
            ExteriorDoor2.GetComponent<SpriteRenderer>().sortingOrder = 0;

           
            Interiror.SetActive(false);

            Exterior.GetComponent<CompositeCollider2D>().isTrigger = false;
            //Roof.GetComponent<TilemapCollider2D>().isTrigger = true;
            Exterior.color = new Color(1f, 1f, 1f, 1f);
            Roof.color = new Color(1f, 1f, 1f, 1f);

            
            Exterior_Door1.SetActive(true);
            Exterior_Door2.SetActive(true);
        }

    }
}
