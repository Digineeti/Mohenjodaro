using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class AttackActionHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button button;                        //declaring Attack Ui panel variable   
    Color present;
  
    public void OnPointerEnter(PointerEventData eventData)
    {         
        button.image.color = new Color(1,.6f,1,.20f);
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        button.image.color = new Color(1, 1, 1, .224f);
    }
    void Start()
    {
        present = button.image.color;
    }
}
