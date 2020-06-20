using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class MainMenuEvent : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject LoadMenu;
    public AudioManager AM;
    public string NewGameScene;
    #region MainMenu buttton

    //Scene Transition
    public int SceneIndex;
    public Animator transition;
    public float transitionTime;

    //
    public GameObject load_game_prefab;
    public GameObject parent;
   
   
    public void Main_Menu_NewGame_button_Click()
    {       
        AM.play("buttonClick");

        //SceneManager.LoadScene(NewGameScene);
        StartCoroutine(Load_Scene(SceneIndex));
        //SceneManager.LoadScene(1);

    }   
    public void Main_Menu_LoadGame_button_Click()
    {
        mainMenu.SetActive(false);
        LoadMenu.SetActive(true);
        load();
        AM.play("buttonClick");

    }

    public void Main_Menu_LoadGame_Panel_Back_Click()
    {
       
        mainMenu.SetActive(true);
        LoadMenu.SetActive(false);
       
        AM.play("buttonClick");
    }
    public void Main_Menu_option_button_Click()
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
        AM.play("buttonClick");

    }
    public void Main_Menu_Exit_button_Click()
    {     
        AM.play("buttonClick");
        Application.Quit();
    }



  


    #endregion
    //#region Option Menu button
    //public void option_Menu_Back_buttton()
    //{
    //    mainMenu.SetActive(true);
    //    optionMenu.SetActive(false);
    //    AM.play("buttonClick");
    //}
    //public void option_Menu_Reset_buttton()
    //{        
    //    AM.play("buttonClick");
    //}
    //#endregion

    ////new Option Menu event start form here ...

    //public GameObject MusicPanel;
    //public GameObject DisplayPanel;
    //public GameObject gameplayPanel;
    ////public GameObject MusicPanel;

    //public void New_Option_Music_Event()
    //{
    //    MusicPanel.SetActive(true);
    //    DisplayPanel.SetActive(false);
    //}
    //public void New_Option_Display_Event()
    //{
    //    DisplayPanel.SetActive(true);
    //    MusicPanel.SetActive(false);
    //}
    //public void New_Option_GamePlay_Event()
    //{
    //    DisplayPanel.SetActive(false);
    //    MusicPanel.SetActive(false);
    //}

    IEnumerator LoadScene(int Sceneindex)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(Sceneindex);

        //AsyncOperation operation = SceneManager.LoadSceneAsync(Sceneindex);
        //while (!operation.isDone)
        //{
        //    transition.SetTrigger("Start");
        //    yield return null;           
        //}

    }
    IEnumerator Load_Scene(int Index)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(.5f);
        //yield return null;

        SceneManager.LoadScene(Index);


    }

    public void  load()
    {

        DirectoryInfo directoryInfo = new DirectoryInfo(Application.dataPath + "/save/");
        FileInfo[] savefile = directoryInfo.GetFiles();
        FileInfo mostrecentfile = null;
        foreach (FileInfo files in savefile)
        {
            //spwan the prefab
            try
            {
                string savestring = File.ReadAllText(files.FullName);
                SaveObject saveobject = JsonUtility.FromJson<SaveObject>(savestring);

                GameObject myBrick = Instantiate(load_game_prefab, parent.transform.position, Quaternion.identity) as GameObject;
                myBrick.transform.SetParent(parent.transform, true);
                myBrick.transform.localScale = new Vector3(1, 1, 0);



                myBrick.GetComponent<LoadsavePrefabvalue>().level.text = saveobject.level.ToString();
                myBrick.GetComponent<LoadsavePrefabvalue>().gold.text = saveobject.level.ToString();
                myBrick.GetComponent<LoadsavePrefabvalue>().date.text = saveobject.Date.ToString();
                myBrick.GetComponent<LoadsavePrefabvalue>().file_Name = files.FullName;
            }
            catch (System.Exception)
            {

                
            }
           

            //string savestring = File.ReadAllText(mostrecentfile.FullName);

        }

        //if (mostrecentfile != null)
        //{
        //    string savestring = File.ReadAllText(mostrecentfile.FullName);
        //    return savestring;
        //}
        //else { return null; }

      
    }

    private class SaveObject
    {
        public int level;
        public Vector2 playerPosition;
        public string Date;
    }

}
