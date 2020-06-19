using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    //inventory variable
    private GameObject inventory_system;
    private bool inventory_action;
    //dialogue variable
    private GameObject dialogue_system;
    //[HideInInspector] public bool escape;


    // Start is called before the first frame update
    void Start()
    {
        //initialize the inventory system
        inventory_system = GameObject.Find("Inventory");
        inventory_system.SetActive(false);
        inventory_action = false;

        //initialize the dialogue system
        dialogue_system = GameObject.Find("DialogueBar");


    }

    // Update is called once per frame Inventory
    void Update()
    {

        if(dialogue_system.activeSelf ||inventory_system.activeSelf)
        {
            Globalvariable.Dialogue_Open = true;
        }
        else
        {
            Globalvariable.Dialogue_Open = false;
        }
        Open_Inventory_system();
    }

    protected void Open_Inventory_system()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inventory_action = !inventory_action;
            if (inventory_action)
            {
                inventory_system.SetActive(true);               
            }
            else
            {
                inventory_system.SetActive(false);
            }
        }
    }
}
