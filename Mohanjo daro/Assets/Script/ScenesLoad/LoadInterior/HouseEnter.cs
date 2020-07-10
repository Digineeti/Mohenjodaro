using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering.Universal;


public class HouseEnter : MonoBehaviour
{

    public GameObject Deactive;
    //public Tilemap Roof;
    //public GameObject Exterior;
    public GameObject Active;

    //public GameObject Entry;
    //public GameObject Exit;
    //public GameObject Entry2;
    //public GameObject Exit2;


    public Animator ExteriorDoor;
    //public Animator ExteriorDoor2;



    private void Start()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ScenePlayer")
        {
            StartCoroutine(EnterIntoHouse());
        }
    }

    

    IEnumerator EnterIntoHouse()
    {

        //GameObject player = GameObject.FindGameObjectWithTag("ScenePlayer").gameObject;
        //GameObject Main_Light = GameObject.Find("GlobalLight");
        //Main_Light.GetComponent<Light2D>().intensity = 0.6f;
        ExteriorDoor.SetTrigger("start");
        yield return new WaitForSeconds(0.15f);
        //if (Entry.gameObject.activeSelf)
        //{
        //    Exit.SetActive(true);
        //    Entry.SetActive(false);

        //    Exit2.SetActive(true);
        //    Entry2.SetActive(false);
        Deactive.SetActive(false);
        Active.SetActive(true);
           
            //ExteriorDoor2.SetTrigger("start");

            //ExteriorDoor.GetComponent<SpriteRenderer>().sortingLayerName = player.GetComponent<SpriteRenderer>().sortingLayerName;
            //ExteriorDoor.GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder + 1000;

            //ExteriorDoor2.GetComponent<SpriteRenderer>().sortingLayerName = player.GetComponent<SpriteRenderer>().sortingLayerName;
            //ExteriorDoor2.GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder + 1000;

           

            
            //Exterior.GetComponent<CompositeCollider2D>().isTrigger = true;
            //Roof.GetComponent<TilemapCollider2D>().isTrigger = true;
            //Exterior.color=new Color(1f,1f,1f,0f);
            //Roof.color = new Color(1f, 1f, 1f, 0f);


        //}
    }
}
