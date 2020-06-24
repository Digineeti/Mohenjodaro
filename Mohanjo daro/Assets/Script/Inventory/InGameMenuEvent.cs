using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuEvent : MonoBehaviour
{
    public GameObject In_Game_Menu;
    public GameObject Exit_Panel;
    public GameObject Quest_Panel;
    public GameObject Status_Panel;
    public GameObject Item_Panel;
    public GameObject Option_Panel;
    public GameObject Load_Panel;




    private void Start()
    {
        Exit_Panel.SetActive(false);
        Quest_Panel.SetActive(false);
        Status_Panel.SetActive(false);
        Item_Panel.SetActive(false);
        Option_Panel.SetActive(false);
        Load_Panel.SetActive(false);
    }
    public void In_Game_Menu_Exit_button_Click()
    {
        In_Game_Menu.SetActive(false);
        Exit_Panel.SetActive(true);

    }

    public void In_Game_Menu_ExitPanel_Cancel_button_Click()
    {
        In_Game_Menu.SetActive(true);
        Exit_Panel.SetActive(false);

    }
}
