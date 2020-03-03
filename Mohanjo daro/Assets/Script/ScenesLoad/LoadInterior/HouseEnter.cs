using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class HouseEnter : MonoBehaviour
{

    public Tilemap ExteriorHouse;
    public Tilemap ExteriorProps;

    public Tilemap InteriorHouse;
    public Tilemap InteriorProps;
    private Animator transition;         //camera transition effect.
    bool check;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
        transition = GameObject.Find("CinemachineCamera").GetComponent<Animator>();
        transition.SetTrigger("end");

        //SceneManager.LoadScene(TransitionScene);
        yield return new WaitForSeconds(0.5f);
        check = !check;
        if (check)
        {
            //collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 200;
            ExteriorHouse.color = new Color(1, 1, 1, 0.1f);
            ExteriorProps.color = new Color(1, 1, 1, 0.1f);
            InteriorHouse.gameObject.SetActive(true);
            InteriorProps.gameObject.SetActive(true);
        }
        else
        {
            //collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 200;
            ExteriorHouse.color = new Color(1, 1, 1, 1f);
            ExteriorProps.color = new Color(1, 1, 1, 1f);
            InteriorHouse.gameObject.SetActive(false);
            InteriorProps.gameObject.SetActive(false);
        }
       
        transition.SetTrigger("start");
    }
}
