using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionExit : MonoBehaviour
{
    //public string SceneToLoad;
    public string SceneIndex;
    public string CurrentScene;
    public Animator transition;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ScenePlayer")
        {
            //SceneManager.LoadScene(SceneIndex);
            StartPointGlobalData.Scene = CurrentScene + "Exit";
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene()
    {
        //gameObject.GetComponent<AudioSource>().Play();
        transition = GameObject.Find("CinemachineCamera").GetComponent<Animator>();
        //GameObject Cinemachine = GameObject.Find("CM vcam1");
        transition.SetTrigger("end");
        yield return new WaitForSeconds(0.5f);
        //StartPointGlobalData.Scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(SceneIndex);
        //Cinemachine.GetComponent<Animator>().SetTrigger("start");
        transition.SetTrigger("start");
    }
}
