using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class HouseExit : MonoBehaviour
{
    public Tilemap ExteriorHouse;
    public Tilemap ExteriorProps;

    public Tilemap InteriorHouse;
    public Tilemap InteriorProps;
    private Animator transition;

    public GameObject Entry;
    public GameObject Exit;


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

        if (Exit.gameObject.activeSelf)
        {
            Exit.SetActive(false);
            Entry.SetActive(true);
            ExteriorHouse.gameObject.SetActive(true);
            ExteriorProps.gameObject.SetActive(true);
            InteriorHouse.gameObject.SetActive(false);
            InteriorProps.gameObject.SetActive(false);
        }

    }
}
