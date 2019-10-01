using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoad : MonoBehaviour
{
    public Animator tranmisionamin;
    public string SceneToLoad;
    public int BackgroundImage;  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(loadScene());
        }
    }

    IEnumerator loadScene()
    {
        //tranmisionamin.SetFloat("transition", 1);
        tranmisionamin.SetBool("Start", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneToLoad);
        tranmisionamin.SetBool("Start", false);
        PlayerPrefs.SetInt("CurrentScene", BackgroundImage);
        PlayerPrefs.Save();
        //tranmisionamin.SetBool("Start", true);
    }
}
