using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrologueExit : MonoBehaviour
{
    public string TransitionScene;   
    public GameObject GlobalData;
    private Animator transition;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ScenePlayer")
        {
            StartPointGlobalData.Scene = GlobalData.name;
            StartCoroutine(LoadScene());
        } 
    }

    IEnumerator LoadScene()
    {
        transition = GameObject.Find("CinemachineCamera").GetComponent<Animator>();
        transition.SetTrigger("end");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(TransitionScene);
        transition.SetTrigger("start");
    }
}
