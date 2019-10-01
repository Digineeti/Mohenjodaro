using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //public LoadHeros LH;
    //public LoadEnemy LE;
    //public Button TurnButton;
    //public PA Show_PlayerUI;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Button Hover");
        //Show_PlayerUI.GetComponent<PA>().ShowUI = true;
        //LH.Turn_Appear();
        //LE.Turn_Appear();
        //TurnButton.image.color=Color.yellow;
        //do stuff
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
       
        //TurnButton.image.color = Color.white;
        //LH.Turn_Disappear();
        //LE.Turn_Disappear();
    }
}
