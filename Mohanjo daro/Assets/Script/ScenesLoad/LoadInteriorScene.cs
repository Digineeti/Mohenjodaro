using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadInteriorScene : MonoBehaviour
{
    public string SceneToLoad;
    //public GameObject TentEntryPoint;
    //public GameObject TentExitPoint;

    //public GameObject TentInteriorStartPoint;
    //public GameObject TentInteriorExitPoint;

    public Animator tranmisionamin;

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
      if(collision.gameObject.name== "Player")
        {
            StartCoroutine(loadScene());
            //SceneManager.LoadScene(SceneToLoad);
            //if (SceneToLoad == "TentInside")
            //    gameObject.transform.position = new Vector3(-3.46f,-19.92f,-981.3555f);
            //if (SceneToLoad == "Desert")
            //    gameObject.transform.position = new Vector3(-10.798f, 1.336f, -977.3366f);
        }
    }

    IEnumerator loadScene()
    {
        //tranmisionamin.SetFloat("transition", 1);
        tranmisionamin.SetBool("Start",true);
        yield return new WaitForSeconds(.8f);
        tranmisionamin.SetBool("Start", false);
        SceneManager.LoadScene(SceneToLoad);
        //tranmisionamin.SetBool("Start", true);
    }
}
