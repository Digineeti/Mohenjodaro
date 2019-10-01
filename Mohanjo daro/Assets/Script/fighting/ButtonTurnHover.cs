using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTurnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)    {      
        Globalvariable.turnUi = true;
    }
    public void OnPointerExit(PointerEventData pointerEventData)    {     
        Globalvariable.turnUi = false;
    }
}
