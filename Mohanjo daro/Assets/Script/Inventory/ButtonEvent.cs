using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionMenu;
    public AudioManager AM;


    public void Main_Menu_option_button_Click()
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
        AM.play("buttonClick");
    } public void Main_Menu_NewGame_button_Click()
    {       
        AM.play("buttonClick");
    } public void Main_Menu_LoadGame_button_Click()
    {     
        AM.play("buttonClick");
    } public void Main_Menu_Exit_button_Click()
    {     
        AM.play("buttonClick");
    }



    public void option_Menu_Back_buttton()
    {
        mainMenu.SetActive(true);
        optionMenu.SetActive(false);
        AM.play("buttonClick");
    }
    public void option_Menu_Reset_buttton()
    {        
        AM.play("buttonClick");
    }


    //new Option Menu event start form here ...

    public GameObject MusicPanel;
    public GameObject DisplayPanel;
    public GameObject gameplayPanel;
    //public GameObject MusicPanel;

    public void New_Option_Music_Event()
    {
        MusicPanel.SetActive(true);
        DisplayPanel.SetActive(false);
    }
    public void New_Option_Display_Event()
    {
        DisplayPanel.SetActive(true);
        MusicPanel.SetActive(false);
    }
    public void New_Option_GamePlay_Event()
    {
        DisplayPanel.SetActive(false);
        MusicPanel.SetActive(false);
    }

}
