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
    public GameObject Save_Panel;
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

    public void In_Game_Menu_Quest_button_Click()
    {
        In_Game_Menu.SetActive(false);
        Quest_Panel.SetActive(true);

    }
    public void In_Game_Menu_QuestPanel_Cancel_button_Click()
    {
        In_Game_Menu.SetActive(true);
        Quest_Panel.SetActive(false);

    }

    public void In_Game_Menu_Status_button_Click()
    {
        In_Game_Menu.SetActive(false);
        Status_Panel.SetActive(true);

    }
    public void In_Game_Menu_StatusPanel_Cancel_button_Click()
    {
        In_Game_Menu.SetActive(true);
        Status_Panel.SetActive(false);

    }

    public void In_Game_Menu_Item_button_Click()
    {
        In_Game_Menu.SetActive(false);
        Item_Panel.SetActive(true);

    }
    public void In_Game_Menu_ItemPanel_Cancel_button_Click()
    {
        In_Game_Menu.SetActive(true);
        Item_Panel.SetActive(false);

    }

    public void In_Game_Menu_Save_button_Click()
    {
        In_Game_Menu.SetActive(false);
        Save_Panel.SetActive(true);

    }
    public void In_Game_Menu_SavePanel_Cancel_button_Click()
    {
        In_Game_Menu.SetActive(true);
        Save_Panel.SetActive(false);

    }

    public void In_Game_Menu_Option_button_Click()
    {
        In_Game_Menu.SetActive(false);
        Option_Panel.SetActive(true);

    }
    public void In_Game_Menu_OptionPanel_Cancel_button_Click()
    {
        In_Game_Menu.SetActive(true);
        Option_Panel.SetActive(false);

    }

    public void In_Game_Menu_Load_button_Click()
    {
        In_Game_Menu.SetActive(false);
        Load_Panel.SetActive(true);

    }
    public void In_Game_Menu_LoadPanel_Cancel_button_Click()
    {
        In_Game_Menu.SetActive(true);
        Load_Panel.SetActive(false);

    }

   

}
