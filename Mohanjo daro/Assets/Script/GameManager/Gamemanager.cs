using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    bool Active_Dialogue;
    bool Active_Inventory;

    public int dialogue_StartLine;
    public int dialogue_EndLine;
    //dialogue variable

    // Start is called before the first frame update
    private void Awake()
    {
        StartCoroutine(Load_Dialogue());
    }
    void Start()
    {
        if (Active_Dialogue)
        {
            Active_Dialogue = false;
            try
            {
                GameObject dialoguebar = GameObject.Find("MainDialogueSystem");
                //GameObject cam = GameObject.Find();
                //gameObject.GetComponent<RPGTalkArea>().rpgtalkTarget = dialoguebar.GetComponent<RPGTalk>();
                //GameObject player_Position = GameObject.Find("Indra 1");
                // dialoguebar.transform.position = player_Position.transform.position;

                dialoguebar.GetComponent<RPGTalk>().lineToStart = dialogue_StartLine.ToString();
                dialoguebar.GetComponent<RPGTalk>().lineToBreak = dialogue_EndLine.ToString();
                dialoguebar.GetComponent<RPGTalk>().NewTalk();
                Destroy(gameObject);
                //RPGTalk.NewTalk();

            }
            catch (System.Exception)
            {

            }

        }
    }

    // Update is called once per frame Inventory
    void Update()
    {



        //try
        //{
       
            Open_Inventory_system();
        //    if (dialogue_system.activeSelf || Action_Inventory.activeSelf)
        //    {
        //        Globalvariable.Dialogue_Open = true;
        //    }
        //    else
        //    {
        //        Globalvariable.Dialogue_Open = false;
        //    }

        //    GameObject leader = GameObject.Find("Leader");

        if (GameObject.Find("Leader") == null && Globalvariable.Dialogue_Open == false)
        {
            Scene_Transition();
        }
        
        //}
        //catch (System.Exception)
        //{


        //}

    }

    protected void Open_Inventory_system()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Active_Inventory = !Active_Inventory;
            if (Active_Inventory)
            {
                //inventory_system.SetActive(true);      
                StartCoroutine(Load_Inventory());
                Globalvariable.Dialogue_Open = true;
            }
            else
            {
                Globalvariable.Dialogue_Open = true;
                SceneManager.UnloadSceneAsync("Inventory");

                //inventory_system.SetActive(false);


                //for (int i = 0; i < inventory_system.transform.childCount; i++)
                //{
                //    if(i==0)
                //    {
                //        inventory_system.transform.GetChild(i).gameObject.SetActive(true);
                //    }
                //    else
                //    {
                //        inventory_system.transform.GetChild(i).gameObject.SetActive(false);
                //    }

                //}
            }
        }
    }

    protected void Scene_Transition()
    {        
        StartPointGlobalData.Scene = null;
        StartPointGlobalData.Scene = "SurkotadaEnter";
        StartCoroutine(Load_FristScene());

    }

    IEnumerator Load_FristScene()
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("Surkotada");
    }


    //awake funtion load the dialogue scene for loading starting dialogue.
   
   IEnumerator Load_Dialogue()
    {
        //yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Dialogue", LoadSceneMode.Additive);
        Globalvariable.Dialogue_Open = true;
        yield return new WaitForEndOfFrame();
       
        Active_Dialogue = true;

    }
    IEnumerator Load_Inventory()
    {
        SceneManager.LoadScene("Inventory", LoadSceneMode.Additive);
        //Globalvariable.Dialogue_Open = true;
        yield return new WaitForEndOfFrame();
       
    }
}
