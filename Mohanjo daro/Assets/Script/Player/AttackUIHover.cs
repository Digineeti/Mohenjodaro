using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackUIHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject AttackUIPnale;                        //declaring Attack Ui panel variable   

    public void OnPointerEnter(PointerEventData eventData)
    {
        //enable the playerUi on hover the status button
        if (Globalvariable.AttackUi)
            AttackUIPnale.SetActive(true);
        else
            AttackUIPnale.SetActive(false);

    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //disable the playerUi on unhover the status button       
        AttackUIPnale.SetActive(false);
    }

    void Start ()
    {        
        AttackUIPnale.SetActive(false);
    }


    void FixedUpdate()
    {
        
    }

}
