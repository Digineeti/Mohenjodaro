using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AllEnemyAction : MonoBehaviour
{

    public GameObject[] Playerlist;
    private string Name;
    private int activevalue;

    public GameObject[] ButtonPanel;
    Button[] buttonsInPanel1;
    Button[] buttonsInPanel2;
    Button[] buttonsInPanel3;
    //Button[] buttonsInPanel4;

    // Start is called before the first frame update
    void Start()
    {
        buttonsInPanel1 = ButtonPanel[0].GetComponentsInChildren<Button>();
        buttonsInPanel2 = ButtonPanel[1].GetComponentsInChildren<Button>();
        buttonsInPanel3 = ButtonPanel[2].GetComponentsInChildren<Button>();
        //buttonsInPanel4 = ButtonPanel[3].GetComponentsInChildren<Button>();

        
    }

    // Update is called once per frame
    void Update()
    {
        //int value = GameObject.FindGameObjectsWithTag("Players").Length;
        //Playerlist = new GameObject[value];
        Playerlist = GameObject.FindGameObjectsWithTag("Player");
        //Debug.Log(Playerlist[2].GetComponent<IndraAction>().EActiveAction);
        for (int i=0;i<Playerlist.Length;i++)
        {
            try
            {
                if (Playerlist[i].GetComponent<PA>().state.ToString() == "waitingforinput")
                {
                    Name = Playerlist[i].gameObject.name;
                    activevalue = i;
                    ActivatePanel();
                }
            }
            catch (System.Exception)
            {
                
            }
            
        }
    }
    //set the button value and text
    void ActivatePanel()
    {
        for (int i = 0; i < ButtonPanel.Length; i++)
        {
            ButtonPanel[i].SetActive(false);
        }
        if (Name == "Agni")
        {
            for (int i = 0; i < Playerlist[activevalue].gameObject.GetComponent<AgniAction>().EActiveAction; i++)
            {
                ButtonPanel[Playerlist[activevalue].gameObject.GetComponent<AgniAction>().EActiveAction - 1].SetActive(true);
                int value = Playerlist[activevalue].GetComponent<AgniAction>().Eaction[i];
                string Name = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value];               

                for (int j = 0; j < Playerlist[activevalue].GetComponent<AgniAction>().specialActioncount; j++)
                {
                    if (Playerlist[activevalue].GetComponent<AgniAction>().SpAction[j, 0] == value)
                    {
                        if (Playerlist[activevalue].GetComponent<AgniAction>().SpAction[j, 1] <= PlayerPrefs.GetFloat(Playerlist[activevalue].name + "_SPValue"))
                        {

                            if (Playerlist[activevalue].gameObject.GetComponent<AgniAction>().EActiveAction == 1)
                            {
                                buttonsInPanel1[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel1[i].interactable = true;
                                buttonsInPanel1[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<AgniAction>().SpAction[j, 1];
                            }
                            if (Playerlist[activevalue].gameObject.GetComponent<AgniAction>().EActiveAction == 2)
                            {
                                buttonsInPanel2[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel2[i].interactable = true;
                                buttonsInPanel2[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<AgniAction>().SpAction[j, 1];
                            }
                            if (Playerlist[activevalue].gameObject.GetComponent<AgniAction>().EActiveAction == 3)
                            {
                                buttonsInPanel3[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel3[i].interactable = true;
                                buttonsInPanel3[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<AgniAction>().SpAction[j, 1];
                            }
                        }
                        else
                        {

                            if (Playerlist[activevalue].gameObject.GetComponent<AgniAction>().EActiveAction == 1)
                            {
                                buttonsInPanel1[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel1[i].interactable = false;
                                buttonsInPanel1[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<AgniAction>().SpAction[j, 1];
                            }
                            if (Playerlist[activevalue].gameObject.GetComponent<AgniAction>().EActiveAction == 2)
                            {
                                buttonsInPanel2[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel2[i].interactable = false;
                                buttonsInPanel2[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<AgniAction>().SpAction[j, 1];
                            }
                            if (Playerlist[activevalue].gameObject.GetComponent<AgniAction>().EActiveAction == 3)
                            {
                                buttonsInPanel3[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel3[i].interactable = false;
                                buttonsInPanel3[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<AgniAction>().SpAction[j, 1];
                            }
                        }
                    }
                }
            }            
        }
        if (Name == "Dyaus")
        {
            for (int i = 0; i < Playerlist[activevalue].gameObject.GetComponent<DyausAction>().EActiveAction; i++)
            {
                ButtonPanel[Playerlist[activevalue].gameObject.GetComponent<DyausAction>().EActiveAction - 1].SetActive(true);
                int value = Playerlist[activevalue].GetComponent<DyausAction>().Eaction[i];
                string Name = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value];

                for (int j = 0; j < Playerlist[activevalue].GetComponent<DyausAction>().specialActioncount; j++)
                {
                    if (Playerlist[activevalue].GetComponent<DyausAction>().SpAction[j, 0] == value)
                    {
                        if (Playerlist[activevalue].GetComponent<DyausAction>().SpAction[j, 1] <= PlayerPrefs.GetFloat(Playerlist[activevalue].name + "_SPValue"))
                        {

                            if (Playerlist[activevalue].gameObject.GetComponent<DyausAction>().EActiveAction == 1)
                            {
                                buttonsInPanel1[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel1[i].interactable = true;
                                buttonsInPanel1[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<DyausAction>().SpAction[j, 1];
                            }
                            if (Playerlist[activevalue].gameObject.GetComponent<DyausAction>().EActiveAction == 2)
                            {
                                buttonsInPanel2[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel2[i].interactable = true;
                                buttonsInPanel2[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<DyausAction>().SpAction[j, 1];
                            }
                            if (Playerlist[activevalue].gameObject.GetComponent<DyausAction>().EActiveAction == 3)
                            {
                                buttonsInPanel3[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel3[i].interactable = true;
                                buttonsInPanel3[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<DyausAction>().SpAction[j, 1];
                            }
                        }
                        else
                        {
                            if (Playerlist[activevalue].gameObject.GetComponent<DyausAction>().EActiveAction == 1)
                            {
                                buttonsInPanel1[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel1[i].interactable = false;
                                buttonsInPanel1[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<DyausAction>().SpAction[j, 1];
                            }
                            if (Playerlist[activevalue].gameObject.GetComponent<DyausAction>().EActiveAction == 2)
                            {
                                buttonsInPanel2[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel2[i].interactable = false;
                                buttonsInPanel2[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<DyausAction>().SpAction[j, 1];
                            }
                            if (Playerlist[activevalue].gameObject.GetComponent<DyausAction>().EActiveAction == 3)
                            {
                                buttonsInPanel3[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel3[i].interactable = false;
                                buttonsInPanel3[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<DyausAction>().SpAction[j, 1];
                            }
                        }
                    }
                }
            }           
        }
        if (Name == "Indra")
        {

            for (int i = 0; i < Playerlist[activevalue].gameObject.GetComponent<IndraAction>().EActiveAction; i++)
            {
                ButtonPanel[Playerlist[activevalue].gameObject.GetComponent<IndraAction>().EActiveAction - 1].SetActive(true);
                int value = Playerlist[activevalue].GetComponent<IndraAction>().Eaction[i];
                string Name = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value];

                //if (Playerlist[activevalue].gameObject.GetComponent<IndraAction>().EActiveAction == 1)
                //{
                //    buttonsInPanel1[i].GetComponentInChildren<TMP_Text>().text = Name;
                //}                   
                //if (Playerlist[activevalue].gameObject.GetComponent<IndraAction>().EActiveAction == 2)
                //{
                //    buttonsInPanel2[i].GetComponentInChildren<TMP_Text>().text = Name;
                //}                   
                //if (Playerlist[activevalue].gameObject.GetComponent<IndraAction>().EActiveAction == 3)
                //{
                //    buttonsInPanel3[i].GetComponentInChildren<TMP_Text>().text = Name;
                //}

                for (int j = 0; j < Playerlist[activevalue].GetComponent<IndraAction>().specialActioncount; j++)
                {
                    if (Playerlist[activevalue].GetComponent<IndraAction>().SpAction[j, 0] == value)
                    {
                        if (Playerlist[activevalue].GetComponent<IndraAction>().SpAction[j, 1] <= PlayerPrefs.GetFloat(Playerlist[activevalue].name + "_SPValue"))
                        {

                            if (Playerlist[activevalue].gameObject.GetComponent<IndraAction>().EActiveAction == 1)
                            {
                                buttonsInPanel1[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel1[i].interactable = true;
                                buttonsInPanel1[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<IndraAction>().SpAction[j, 1];
                            }
                            if (Playerlist[activevalue].gameObject.GetComponent<IndraAction>().EActiveAction == 2)
                            {
                                buttonsInPanel2[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel2[i].interactable = true;
                                buttonsInPanel2[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<IndraAction>().SpAction[j, 1];
                            }
                            if (Playerlist[activevalue].gameObject.GetComponent<IndraAction>().EActiveAction == 3)
                            {
                                buttonsInPanel3[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel3[i].interactable = true;
                                buttonsInPanel3[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<IndraAction>().SpAction[j, 1];
                            }

                            
                        }
                        else
                        {

                            if (Playerlist[activevalue].gameObject.GetComponent<IndraAction>().EActiveAction == 1)
                            {
                                buttonsInPanel1[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel1[i].interactable = false;
                                buttonsInPanel1[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<IndraAction>().SpAction[j, 1];
                            }
                            if (Playerlist[activevalue].gameObject.GetComponent<IndraAction>().EActiveAction == 2)
                            {
                                buttonsInPanel2[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel2[i].interactable = false;
                                buttonsInPanel2[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<IndraAction>().SpAction[j, 1];
                            }
                            if (Playerlist[activevalue].gameObject.GetComponent<IndraAction>().EActiveAction == 3)
                            {
                                buttonsInPanel3[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel3[i].interactable = false;
                                buttonsInPanel3[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<IndraAction>().SpAction[j, 1];
                            }

                           
                            //buttonsInPanel3[i].image.color = new Color(0, 0f, 1f, .60f);
                        }
                           
                    }
                     
                }
            }
            //if (Playerlist[activevalue].gameObject.GetComponent<IndraAction>().EActiveAction == 1)
            //{
            //    ButtonPanel[0].SetActive(true);
            //    int value1 = Playerlist[activevalue].GetComponent<IndraAction>().Eaction[0]; string Name1 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value1];
            //    buttonsInPanel1[0].GetComponentInChildren<TMP_Text>().text = Name1;
            //}
            //if (Playerlist[activevalue].GetComponent<IndraAction>().EActiveAction == 2)
            //{
            //    ButtonPanel[1].SetActive(true);
            //    int value1 = Playerlist[activevalue].GetComponent<IndraAction>().Eaction[0]; string Name1 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value1];
            //    int value2 = Playerlist[activevalue].GetComponent<IndraAction>().Eaction[1]; string Name2 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value2];
            //    buttonsInPanel2[0].GetComponentInChildren<TMP_Text>().text = Name1;
            //    buttonsInPanel2[1].GetComponentInChildren<TMP_Text>().text = Name2;
            //}
            //if (Playerlist[activevalue].GetComponent<IndraAction>().EActiveAction == 3)
            //{
            //    ButtonPanel[2].SetActive(true);
            //    int value1 = Playerlist[activevalue].GetComponent<IndraAction>().Eaction[0]; string Name1 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value1];
            //    int value2 = Playerlist[activevalue].GetComponent<IndraAction>().Eaction[1]; string Name2 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value2];
            //    int value3 = Playerlist[activevalue].GetComponent<IndraAction>().Eaction[2]; string Name3 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value3];
            //    //now this action is active ....testing here first...
            //    buttonsInPanel3[0].GetComponentInChildren<TMP_Text>().text = Name1;
            //    buttonsInPanel3[1].GetComponentInChildren<TMP_Text>().text = Name2;
            //    buttonsInPanel3[2].GetComponentInChildren<TMP_Text>().text = Name3;
            //}
        }
        if (Name == "Prithvi")
        {
            for (int i = 0; i < Playerlist[activevalue].gameObject.GetComponent<PrithviAction>().EActiveAction; i++)
            {
                ButtonPanel[Playerlist[activevalue].gameObject.GetComponent<PrithviAction>().EActiveAction - 1].SetActive(true);
                int value = Playerlist[activevalue].GetComponent<PrithviAction>().Eaction[i];
                string Name = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value];

                for (int j = 0; j < Playerlist[activevalue].GetComponent<PrithviAction>().specialActioncount; j++)
                {
                    if (Playerlist[activevalue].GetComponent<PrithviAction>().SpAction[j, 0] == value)
                    {
                        if (Playerlist[activevalue].GetComponent<PrithviAction>().SpAction[j, 1] <= PlayerPrefs.GetFloat(Playerlist[activevalue].name + "_SPValue"))
                        {

                            if (Playerlist[activevalue].gameObject.GetComponent<PrithviAction>().EActiveAction == 1)
                            {
                                buttonsInPanel1[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel1[i].interactable = true;
                                buttonsInPanel1[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<PrithviAction>().SpAction[j, 1];
                            }
                            if (Playerlist[activevalue].gameObject.GetComponent<PrithviAction>().EActiveAction == 2)
                            {
                                buttonsInPanel2[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel2[i].interactable = true;
                                buttonsInPanel2[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<PrithviAction>().SpAction[j, 1];
                            }
                            if (Playerlist[activevalue].gameObject.GetComponent<PrithviAction>().EActiveAction == 3)
                            {
                                buttonsInPanel3[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel3[i].interactable = true;
                                buttonsInPanel3[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<PrithviAction>().SpAction[j, 1];
                            }
                        }
                        else
                        {
                            if (Playerlist[activevalue].gameObject.GetComponent<PrithviAction>().EActiveAction == 1)
                            {
                                buttonsInPanel1[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel1[i].interactable = false;
                                buttonsInPanel1[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<PrithviAction>().SpAction[j, 1];
                            }
                            if (Playerlist[activevalue].gameObject.GetComponent<PrithviAction>().EActiveAction == 2)
                            {
                                buttonsInPanel2[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel2[i].interactable = false;
                                buttonsInPanel2[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<PrithviAction>().SpAction[j, 1];
                            }
                            if (Playerlist[activevalue].gameObject.GetComponent<PrithviAction>().EActiveAction == 3)
                            {
                                buttonsInPanel3[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel3[i].interactable = false;
                                buttonsInPanel3[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<PrithviAction>().SpAction[j, 1];
                            }
                        }
                    }
                }
            }            
        }
        if (Name == "Sachi")
        {
            for (int i = 0; i < Playerlist[activevalue].gameObject.GetComponent<SachiAction>().EActiveAction; i++)
            {
                ButtonPanel[Playerlist[activevalue].gameObject.GetComponent<SachiAction>().EActiveAction - 1].SetActive(true);
                int value = Playerlist[activevalue].GetComponent<SachiAction>().Eaction[i];
                string Name = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value];

                for (int j = 0; j < Playerlist[activevalue].GetComponent<SachiAction>().specialActioncount; j++)
                {
                    if (Playerlist[activevalue].GetComponent<SachiAction>().SpAction[j, 0] == value)
                    {
                        if (Playerlist[activevalue].GetComponent<SachiAction>().SpAction[j, 1] <= PlayerPrefs.GetFloat(Playerlist[activevalue].name + "_SPValue"))
                        {

                            if (Playerlist[activevalue].gameObject.GetComponent<SachiAction>().EActiveAction == 1)
                            {
                                buttonsInPanel1[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel1[i].interactable = true;
                                buttonsInPanel1[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<SachiAction>().SpAction[j, 1];
                            }
                            if (Playerlist[activevalue].gameObject.GetComponent<SachiAction>().EActiveAction == 2)
                            {
                                buttonsInPanel2[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel2[i].interactable = true;
                                buttonsInPanel2[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<SachiAction>().SpAction[j, 1];
                            }
                            if (Playerlist[activevalue].gameObject.GetComponent<SachiAction>().EActiveAction == 3)
                            {
                                buttonsInPanel3[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel3[i].interactable = true;
                                buttonsInPanel3[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<SachiAction>().SpAction[j, 1];
                            }
                        }
                        else
                        {
                            if (Playerlist[activevalue].gameObject.GetComponent<SachiAction>().EActiveAction == 1)
                            {
                                buttonsInPanel1[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel1[i].interactable = false;
                                buttonsInPanel1[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<SachiAction>().SpAction[j, 1];
                            }
                            if (Playerlist[activevalue].gameObject.GetComponent<SachiAction>().EActiveAction == 2)
                            {
                                buttonsInPanel2[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel2[i].interactable = false;
                                buttonsInPanel2[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<SachiAction>().SpAction[j, 1];
                            }
                            if (Playerlist[activevalue].gameObject.GetComponent<SachiAction>().EActiveAction == 3)
                            {
                                buttonsInPanel3[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel3[i].interactable = false;
                                buttonsInPanel3[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<SachiAction>().SpAction[j, 1];
                            }
                        }
                    }
                }
            }
        }
        if (Name == "Vayu")
        {
            for (int i = 0; i < Playerlist[activevalue].gameObject.GetComponent<VayuAction>().EActiveAction; i++)
            {
                ButtonPanel[Playerlist[activevalue].gameObject.GetComponent<VayuAction>().EActiveAction - 1].SetActive(true);
                int value = Playerlist[activevalue].GetComponent<VayuAction>().Eaction[i];
                string Name = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value];

                for (int j = 0; j < Playerlist[activevalue].GetComponent<VayuAction>().specialActioncount; j++)
                {
                    if (Playerlist[activevalue].GetComponent<VayuAction>().SpAction[j, 0] == value)
                    {
                        if (Playerlist[activevalue].GetComponent<VayuAction>().SpAction[j, 1] <= PlayerPrefs.GetFloat(Playerlist[activevalue].name + "_SPValue"))
                        {

                            if (Playerlist[activevalue].gameObject.GetComponent<VayuAction>().EActiveAction == 1)
                            {
                                buttonsInPanel1[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel1[i].interactable = true;
                                buttonsInPanel1[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<VayuAction>().SpAction[j, 1];
                            }
                            if (Playerlist[activevalue].gameObject.GetComponent<VayuAction>().EActiveAction == 2)
                            {
                                buttonsInPanel2[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel2[i].interactable = true;
                                buttonsInPanel2[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<VayuAction>().SpAction[j, 1];
                            }
                            if (Playerlist[activevalue].gameObject.GetComponent<VayuAction>().EActiveAction == 3)
                            {
                                buttonsInPanel3[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel3[i].interactable = true;
                                buttonsInPanel3[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<VayuAction>().SpAction[j, 1];
                            }
                        }
                        else
                        {
                            if (Playerlist[activevalue].gameObject.GetComponent<VayuAction>().EActiveAction == 1)
                            {
                                buttonsInPanel1[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel1[i].interactable = false;
                                buttonsInPanel1[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<VayuAction>().SpAction[j, 1];
                            }
                            if (Playerlist[activevalue].gameObject.GetComponent<VayuAction>().EActiveAction == 2)
                            {
                                buttonsInPanel2[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel2[i].interactable = false;
                                buttonsInPanel2[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<VayuAction>().SpAction[j, 1];
                            }
                            if (Playerlist[activevalue].gameObject.GetComponent<VayuAction>().EActiveAction == 3)
                            {
                                buttonsInPanel3[i].GetComponentInChildren<TMP_Text>().text = Name;
                                buttonsInPanel3[i].interactable = false;
                                buttonsInPanel3[i].GetComponentInChildren<TMP_Text>().text += " " + Playerlist[activevalue].GetComponent<VayuAction>().SpAction[j, 1];
                            }
                        }
                    }
                }
            }            
        }
    }
}
