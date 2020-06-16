using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{

    public GameObject loader;
    public GameObject Intro;

    // Start is called before the first frame update
    void Start()
    {
        Intro.SetActive(false);
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
        loader.SetActive(false);
        Intro.SetActive(true);
        yield return new WaitForSeconds(5f);
        loader.SetActive(true);
        Intro.SetActive(false);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(10);


    }
}
