using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;


public class HouseEnter : MonoBehaviour
{

    public Tilemap ExteriorHouse;
    public Tilemap ExteriorProps;

    public Tilemap InteriorHouse;
    public Tilemap InteriorProps;
    private Animator transition;

    public GameObject Entry;
    public GameObject Exit;

    private void Start()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ScenePlayer")
        {
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene()
    {
        //transition = GameObject.Find("TransitionCanvas").GetComponent<Animator>();
        transition = GameObject.Find("TransitionCanvas").GetComponentInChildren<Image>().GetComponent<Animator>();
        //transition.SetTrigger("start");
        //SceneManager.LoadScene(TransitionScene);
        yield return new WaitForSeconds(0.3f);      
        if(Entry.gameObject.activeSelf)
        {
            Exit.SetActive(true);
            Entry.SetActive(false);
            ExteriorHouse.gameObject.SetActive(false);
            ExteriorProps.gameObject.SetActive(false);

            InteriorHouse.gameObject.SetActive(true);
            InteriorProps.gameObject.SetActive(true);
        }
       
        //if (Globalvariable.HouseEnterExit)
        //{
        //    //collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 200;
        //    //ExteriorHouse.color = new Color(1, 1, 1, 0.1f);
        //    //ExteriorProps.color = new Color(1, 1, 1, 0.1f);
           
        //}
        //else
        //{
        //    //collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 200;
        //    //ExteriorHouse.color = new Color(1, 1, 1, 1f);
        //    //ExteriorProps.color = new Color(1, 1, 1, 1f);
          
        //}

        ////transition.SetTrigger("end");
    }
}
