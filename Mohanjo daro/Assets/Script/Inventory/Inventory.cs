using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] IsFull;
    public GameObject[] Slots;

    private bool open_inventory;
    public GameObject inventory_system;
    //image of the player 



    private static bool inventory_system_Exists;
    // Start is called before the first frame update
    void Start()
    {
        open_inventory = false;
        inventory_system.SetActive(false);
        DontDestroyOnLoad(inventory_system.transform.gameObject);
        if (!inventory_system_Exists)
        {
            inventory_system_Exists = true;
            DontDestroyOnLoad(inventory_system.transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            open_inventory = !open_inventory;
            if(open_inventory)
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
