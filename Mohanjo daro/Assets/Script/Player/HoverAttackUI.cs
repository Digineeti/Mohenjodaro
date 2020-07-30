using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverAttackUI : MonoBehaviour
{
    public GameObject PanelToShow;
    
    private void Start()
    {
        PanelToShow.SetActive(false);
    }  
    private void OnMouseExit()
    {
        PanelToShow.SetActive(false);       
    }
    void OnMouseOver()
    {
        //if ()
        if (Globalvariable.Active_Player_Animation_Parameter == null && Globalvariable.AttackUi)
            PanelToShow.SetActive(true);
        else
            PanelToShow.SetActive(false);
       
    }  
}
