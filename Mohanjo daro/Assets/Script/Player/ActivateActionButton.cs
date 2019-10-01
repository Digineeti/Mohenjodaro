using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ActivateActionButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Activebutton;
    public bool HealingPower;
    //public GameObject Healbutton;
    public Callingscriptableobject Attributes;
    public int activeButton;
    void Start()
    {

        for (int i = 0; i < Activebutton.Length; i++)
        {
            Activebutton[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.GetComponent<PA>().state.ToString() == "waitingforinput")
        {
            //for(int i=0;i<Activebutton.Length;i++)
            //{

            if (int.Parse(Attributes.Attribute.Level) <= 10)
            {
                Activebutton[0].SetActive(true);               
                Activebutton[1].SetActive(false);
                Activebutton[2].SetActive(false);
                Activebutton[3].SetActive( false);
            }
            else if (int.Parse(Attributes.Attribute.Level) > 10 && int.Parse(Attributes.Attribute.Level) <= 25)
            {
                Activebutton[0].SetActive(false);
                Activebutton[1].SetActive(true);
                Activebutton[2].SetActive(false);
                Activebutton[3].SetActive(false);
            }
            else if(int.Parse(Attributes.Attribute.Level) > 25 && int.Parse(Attributes.Attribute.Level) <= 50)
            {
                Activebutton[0].SetActive(false);
                Activebutton[1].SetActive(false);
                Activebutton[2].SetActive(true);
                Activebutton[3].SetActive(false);
            }
            else 
            {
                Activebutton[0].SetActive(false);
                Activebutton[1].SetActive(false);
                Activebutton[2].SetActive(false);
                Activebutton[3].SetActive(true);
            }
            //Healbutton.gameObject.SetActive(false);
            //Activebutton[i].gameObject.SetActive(true) ;

            //if (Activebutton[i].GetComponentInChildren<TextMeshProUGUI>().text == "Healling")
            //{ }
            if (HealingPower == true)
                Globalvariable.Heal = 1;
            else
                Globalvariable.Heal = 0;
            
            //}
            
            //Activebutton[Activebutton.Length - 1].gameObject.SetActive(false);
        }
        else
        {

            //if (Globalvariable.Heal > 0)
            //    Healbutton.gameObject.SetActive(true);
            //else            
            //    Healbutton.gameObject.SetActive(false);


            //Activebutton[counter].gameObject.SetActive(true);
            //Activebutton[counter].GetComponent<RectTransform>().sizeDelta = new Vector2();

        }

    }
}
