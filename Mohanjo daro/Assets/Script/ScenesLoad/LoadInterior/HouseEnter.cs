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
    private Animator transition;         //camera transition effect.

    public GlobalLight ScenemainLight;

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
        //transition = GameObject.Find("TransitionCanvas").GetComponent<Animator>();
        transition = GameObject.Find("TransitionCanvas").GetComponentInChildren<Image>().GetComponent<Animator>();
        //transition.SetTrigger("start");
        //SceneManager.LoadScene(TransitionScene);
        yield return new WaitForSeconds(0.3f);
        Globalvariable.HouseEnterExit = !Globalvariable.HouseEnterExit;
        if (Globalvariable.HouseEnterExit)
        {
            //collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 200;
            //ExteriorHouse.color = new Color(1, 1, 1, 0.1f);
            //ExteriorProps.color = new Color(1, 1, 1, 0.1f);
            ExteriorHouse.gameObject.SetActive(false);
            ExteriorProps.gameObject.SetActive(false);
            InteriorHouse.gameObject.SetActive(true);
            InteriorProps.gameObject.SetActive(true);
        }
        else
        {
            //collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 200;
            //ExteriorHouse.color = new Color(1, 1, 1, 1f);
            //ExteriorProps.color = new Color(1, 1, 1, 1f);
            ExteriorHouse.gameObject.SetActive(true);
            ExteriorProps.gameObject.SetActive(true);

            InteriorHouse.gameObject.SetActive(false);
            InteriorProps.gameObject.SetActive(false);
        }

        //transition.SetTrigger("end");
    }
}
