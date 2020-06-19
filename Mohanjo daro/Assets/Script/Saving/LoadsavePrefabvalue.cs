using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadsavePrefabvalue : MonoBehaviour
{
    public TMP_Text level;
    public TMP_Text gold;
    public TMP_Text date;
    public string file_Name;

    public void Load_ButtonClick()
    {
        //SceneManager.LoadScene(NewGameScene);
        StartCoroutine(Load_Scene(int.Parse(level.text)));
        //SceneManager.LoadScene(1);
    }

    IEnumerator Load_Scene(int Index)
    {
        Globalvariable.LoadGameOpen = true;
        Globalvariable.LoadfileOpen = file_Name;

        yield return new WaitForSeconds(.5f);
        //yield return null;

        SceneManager.LoadScene(Index);


    }
}
