using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionMenu;

    public void Main_Menu_option_button_Click()
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);

    }

    public void option_Menu_Back_buttton()
    {
        mainMenu.SetActive(true);
        optionMenu.SetActive(false);
    }

}
