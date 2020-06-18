using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class Savemanager : MonoBehaviour
{

    private const string SAVE_SAPARATOR = "#SAVE-VALUE#";
    [SerializeField]
    private GameObject unitGameObject;
    private SaveData unit;

    // Start is called before the first frame update
    void Start()
    {
        unit = unitGameObject.GetComponent<SaveData>();
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
    }

    private void Save()
    {
        try
        {

            //save
            //Vector2 player_position = unit.Position();

        }
        catch (System.Exception)
        {

            
        }
    }    

    private void Load()
    {
        try
        {

        }
        catch (System.Exception)
        {

            throw;
        }
    }


   
}
