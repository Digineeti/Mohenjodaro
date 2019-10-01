using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Globalvariable.AttackUi)
            PanelToShow.SetActive(true);
        else
            PanelToShow.SetActive(false);
       
    }  
}
