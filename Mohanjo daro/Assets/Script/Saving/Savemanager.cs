using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Savemanager : MonoBehaviour
{

    [SerializeField]
    private GameObject unitGameObject;
    private IUnit unit;
  
    // Start is called before the first frame update

    private void Awake()
    {
        unit = unitGameObject.GetComponent<IUnit>();
        SaveSystem.Init();
        
        //SaveObject saveobject = new SaveObject
        //{
        //    level = SceneManager.GetActiveScene().buildIndex,
        //};
        //string json=JsonUtility.ToJson(saveobject);
        //Debug.Log(json);

        //SaveObject loadedsaveobject = JsonUtility.FromJson<SaveObject>(json);
        //Debug.Log(loadedsaveobject.level);
        
    }    

    // Update is called once per frame
    void Update()
    {
        //for save the game stat..
        if(Input.GetKeyDown(KeyCode.K))
        {
            Save();
        }
        //for load the game stat...
        if(Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
        if(Globalvariable.LoadGameOpen==true)
        {
            Globalvariable.LoadGameOpen = false;
            Load_game();
            
        }
    }

    private void Save()
    {
        try
        {

            //save
            Vector2 playerposition = unit.GetPosition();
            int level = unit.GetLevel();
            int gold = unit.GetGold();
            string Date = unit.GetDate();
            SaveObject saveobject = new SaveObject()
            {
                level = level,
                playerPosition = playerposition,
                Date = Date,
                gold = gold,

            };
            string json = JsonUtility.ToJson(saveobject);
            SaveSystem.save(json);
            Debug.Log("data save");
           
        }
        catch (System.Exception)
        {

            
        }
    }    

    private void Load()
    {
        try
        {
            string savestring = SaveSystem.load();
            if (savestring != null)
            {
                Debug.Log(savestring);
                SaveObject saveobject = JsonUtility.FromJson<SaveObject>(savestring);
                unit.SetPosition(saveobject.playerPosition);
                unit.SetLevel(saveobject.level);
                unit.SetDate(saveobject.Date);
                //new section for testing
                
            }
            else
            { Debug.Log("nothing is save"); }

        }
        catch (System.Exception)
        {

           
        }
    }


    private void Load_game()
    {
        try
        {
            string savestring = SaveSystem.game_load(Globalvariable.LoadfileOpen);
            if (savestring != null)
            {
                Debug.Log(savestring);
                SaveObject saveobject = JsonUtility.FromJson<SaveObject>(savestring);
                unit.SetPosition(saveobject.playerPosition);
                unit.SetLevel(saveobject.level);
                unit.SetDate(saveobject.Date);
                //new section for testing

            }
            else
            { Debug.Log("nothing is save"); }

        }
        catch (System.Exception)
        {


        }
    }

    private class SaveObject
    {
        public int level;
        public Vector2 playerPosition;
        public int gold;
        public string Date;
    }

    //string[] chest = { "box1", "box2", "box3", "box4", "box4" };
   

}
