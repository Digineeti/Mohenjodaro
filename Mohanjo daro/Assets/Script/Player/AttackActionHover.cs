using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class AttackActionHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button button;                        //declaring Attack Ui panel variable   
    Color present;
    public GameObject[] spawanHero; 


    public void OnPointerEnter(PointerEventData eventData)
    {         
        button.image.color = new Color(1,.6f,1,.20f);
        //make all player action 
        if(button.GetComponentInChildren<TMP_Text>().text== "RunAway")
        {
            Globalvariable.All_Player_Hoverbutton = true;
            for (int i = 0; i < spawanHero.Length; i++)
            {
                try
                {
                    if (spawanHero[i].GetComponent<PA>().state.ToString() == "busy")
                        spawanHero[i].transform.GetChild(7).gameObject.SetActive(true);
                }
                catch (System.Exception)
                {
                }

            }
        }
        if (button.GetComponentInChildren<TMP_Text>().text == "ThunderStrom" || button.GetComponentInChildren<TMP_Text>().text == "Strom" || button.GetComponentInChildren<TMP_Text>().text == "FireBlast" || button.GetComponentInChildren<TMP_Text>().text == "EarthQuake" || button.GetComponentInChildren<TMP_Text>().text == "HeavenlyWorth")
        {
            Globalvariable.All_Enemy_Hoverbutton = true;
            for (int i = 0; i < spawanHero.Length; i++)
            {
                try
                {
                    if (spawanHero[i].GetComponent<EnemyAction>().state.ToString() == "busy")
                        spawanHero[i].transform.GetChild(5).gameObject.SetActive(true);
                }
                catch (System.Exception)
                {                    
                       
                }

            }
        }

       
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        button.image.color = new Color(1, 1, 1, .224f);
        Globalvariable.All_Player_Hoverbutton = false;
        Globalvariable.All_Enemy_Hoverbutton = false;
        
    }
    void Start()
    {
        spawanHero = GameObject.FindGameObjectsWithTag("Player");
        present = button.image.color;
      
    }

 
   
}
