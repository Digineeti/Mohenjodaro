using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSHowUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        //enable the playerUi on hover the status button 
        Globalvariable.PlayerUi = true;        
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //disable the playerUi on unhover the status button
        Globalvariable.PlayerUi = false;
    }
}
