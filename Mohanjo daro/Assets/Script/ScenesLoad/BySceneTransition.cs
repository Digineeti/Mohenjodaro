using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BySceneTransition : MonoBehaviour
{

    public int SceneIndex;
    public Animator transition;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(LoadAsynchronously(SceneIndex));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadAsynchronously(int Sceneindex)
    {       
        AsyncOperation operation = SceneManager.LoadSceneAsync(Sceneindex);
        while (!operation.isDone)
        {
            transition.SetTrigger("Start");
            yield return null;
            //SceneManager.LoadScene(Sceneindex);
        }
        //yield return new WaitForSeconds(.2f);
       

    }
}
