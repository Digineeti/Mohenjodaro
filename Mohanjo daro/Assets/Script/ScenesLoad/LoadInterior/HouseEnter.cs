using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering.Universal;


public class HouseEnter : MonoBehaviour
{

    public Tilemap Exterior;
    public Tilemap Roof;

    public GameObject ActiveGroundFloor;
    public GameObject Entry;
    public GameObject Exit;
    public GameObject Entry2;
    public GameObject Exit2;


    public Animator ExteriorDoor;
    public Animator ExteriorDoor2;



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

    //IEnumerator LoadScene()
    //{
    //    //transition = GameObject.Find("TransitionCanvas").GetComponent<Animator>();
    //    //transition = GameObject.Find("TransitionCanvas").GetComponentInChildren<Image>().GetComponent<Animator>();
    //    //transition.SetTrigger("start");
    //    //SceneManager.LoadScene(TransitionScene);
    //    GameObject player = GameObject.FindGameObjectWithTag("ScenePlayer").gameObject;

    //    yield return new WaitForSeconds(0.3f);      
    //    if(Entry.gameObject.activeSelf)
    //    {
    //        Exit.SetActive(true);
    //        Entry.SetActive(false);

    //        Exit2.SetActive(true);
    //        Entry2.SetActive(false);


    //        ExteriorDoor.SetTrigger("start");ExteriorDoor2.SetTrigger("start");
    //        ExteriorDoor.GetComponent<SpriteRenderer>().sortingLayerName = player.GetComponent<SpriteRenderer>().sortingLayerName;
    //        ExteriorDoor.GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder+1000;

    //        ExteriorDoor2.GetComponent<SpriteRenderer>().sortingLayerName = player.GetComponent<SpriteRenderer>().sortingLayerName;
    //        ExteriorDoor2.GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder + 1000;

    //        ExteriorHouse.gameObject.SetActive(false);
    //        ExteriorProps.gameObject.SetActive(false);

    //        InteriorHouse.gameObject.SetActive(true);
    //        InteriorProps.gameObject.SetActive(true);
    //    }
       
    //    //if (Globalvariable.HouseEnterExit)
    //    //{
    //    //    //collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 200;
    //    //    //ExteriorHouse.color = new Color(1, 1, 1, 0.1f);
    //    //    //ExteriorProps.color = new Color(1, 1, 1, 0.1f);
           
    //    //}
    //    //else
    //    //{
    //    //    //collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 200;
    //    //    //ExteriorHouse.color = new Color(1, 1, 1, 1f);
    //    //    //ExteriorProps.color = new Color(1, 1, 1, 1f);
          
    //    //}

    //    ////transition.SetTrigger("end");
    //}

    IEnumerator EnterIntoHouse()
    {
       
        GameObject player = GameObject.FindGameObjectWithTag("ScenePlayer").gameObject;
        GameObject Main_Light = GameObject.Find("GlobalLight");
        Main_Light.GetComponent<Light2D>().intensity = 0.2f;
        yield return new WaitForSeconds(0.3f);
        if (Entry.gameObject.activeSelf)
        {
            Exit.SetActive(true);
            Entry.SetActive(false);

            Exit2.SetActive(true);
            Entry2.SetActive(false);
            ActiveGroundFloor.SetActive(true);

            ExteriorDoor.SetTrigger("start");
            ExteriorDoor2.SetTrigger("start");

            ExteriorDoor.GetComponent<SpriteRenderer>().sortingLayerName = player.GetComponent<SpriteRenderer>().sortingLayerName;
            ExteriorDoor.GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder + 1000;

            ExteriorDoor2.GetComponent<SpriteRenderer>().sortingLayerName = player.GetComponent<SpriteRenderer>().sortingLayerName;
            ExteriorDoor2.GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder + 1000;


            Exterior.GetComponent<CompositeCollider2D>().isTrigger = true;
            //Roof.GetComponent<TilemapCollider2D>().isTrigger = true;


            Exterior.color=new Color(1f,1f,1f,0.4f);
            Roof.color = new Color(1f, 1f, 1f, 0.4f);

            //InteriorHouse.gameObject.SetActive(true);
            //InteriorProps.gameObject.SetActive(true);
        }
    }
}
