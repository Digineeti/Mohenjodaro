using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class Savemanager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Application.persistentDataPath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Save()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath+"/"+ "SaveData.dat",FileMode.Create);

            SaveData data = new SaveData();
            SavePlayer(data);
            bf.Serialize(file, data);
            file.Close();


        }
        catch (System.Exception)
        {

            //this for erro handle
        }
    }

    private void SavePlayer(SaveData data)
    {
       //data.MyPlayerData = new PlayerData(PlayerMovement.MyLevel, PlayerMovement.MyInstance.transform.position);
       
    }

    private void Load()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + "SaveData.dat", FileMode.Open);

            SaveData data = (SaveData)bf.Deserialize(file);
            
            file.Close();
            LoadPlayer(data);
        }
        catch (System.Exception)
        {
            //this for erro handle
        }
    }


    private void LoadPlayer(SaveData data)
    {
        //PlayerMovement.MyLevel = data.MyPlayerData.MyLevel;
        //PlayerMovement.MyInstance.transform.position = new Vector2(data.MyPlayerData.Myx,data.MyPlayerData.Myy);
    }
}
