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
            if (Playerlist[activevalue].GetComponent<AgniAction>().EActiveAction == 1)
            {
                ButtonPanel[0].SetActive(true);
                int value1 = Playerlist[activevalue].GetComponent<AgniAction>().Eaction[0]; string Name1 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value1];

                buttonsInPanel1[0].GetComponentInChildren<TMP_Text>().text = Name1;
            }
            if (Playerlist[activevalue].GetComponent<AgniAction>().EActiveAction == 2)
            {
                ButtonPanel[1].SetActive(true);
                int value1 = Playerlist[activevalue].GetComponent<AgniAction>().Eaction[0]; string Name1 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value1];
                int value2 = Playerlist[activevalue].GetComponent<AgniAction>().Eaction[1]; string Name2 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value2];

                buttonsInPanel2[0].GetComponentInChildren<TMP_Text>().text = Name1;
                buttonsInPanel2[1].GetComponentInChildren<TMP_Text>().text = Name2;
            }
            if (Playerlist[activevalue].GetComponent<AgniAction>().EActiveAction == 3)
            {
                ButtonPanel[2].SetActive(true);
                int value1 = Playerlist[activevalue].GetComponent<AgniAction>().Eaction[0]; string Name1 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value1];
                int value2 = Playerlist[activevalue].GetComponent<AgniAction>().Eaction[1]; string Name2 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value2];
                int value3 = Playerlist[activevalue].GetComponent<AgniAction>().Eaction[2]; string Name3 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value3];

                buttonsInPanel3[0].GetComponentInChildren<TMP_Text>().text = Name1;
                buttonsInPanel3[1].GetComponentInChildren<TMP_Text>().text = Name2;
                buttonsInPanel3[2].GetComponentInChildren<TMP_Text>().text = Name3;
            }
           
        }
        if (Name == "Dyaus")
        {
            if (Playerlist[activevalue].GetComponent<DyausAction>().EActiveAction == 1)
            {
                ButtonPanel[0].SetActive(true);
                int value1 = Playerlist[activevalue].GetComponent<DyausAction>().Eaction[0]; string Name1 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value1];

                buttonsInPanel1[0].GetComponentInChildren<TMP_Text>().text = Name1;
            }
            if (Playerlist[activevalue].GetComponent<DyausAction>().EActiveAction == 2)
            {
                ButtonPanel[1].SetActive(true);
                int value1 = Playerlist[activevalue].GetComponent<DyausAction>().Eaction[0]; string Name1 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value1];
                int value2 = Playerlist[activevalue].GetComponent<DyausAction>().Eaction[1]; string Name2 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value2];

                buttonsInPanel2[0].GetComponentInChildren<TMP_Text>().text = Name1;
                buttonsInPanel2[1].GetComponentInChildren<TMP_Text>().text = Name2;
            }
            if (Playerlist[activevalue].GetComponent<DyausAction>().EActiveAction == 3)
            {
                ButtonPanel[2].SetActive(true);
                int value1 = Playerlist[activevalue].GetComponent<DyausAction>().Eaction[0]; string Name1 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value1];
                int value2 = Playerlist[activevalue].GetComponent<DyausAction>().Eaction[1]; string Name2 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value2];
                int value3 = Playerlist[activevalue].GetComponent<DyausAction>().Eaction[2]; string Name3 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value3];

                buttonsInPanel3[0].GetComponentInChildren<TMP_Text>().text = Name1;
                buttonsInPanel3[1].GetComponentInChildren<TMP_Text>().text = Name2;
                buttonsInPanel3[2].GetComponentInChildren<TMP_Text>().text = Name3;
            }
        }
        if (Name == "Indra")
        {
            if (Playerlist[activevalue].gameObject.GetComponent<IndraAction>().EActiveAction == 1)
            {
                ButtonPanel[0].SetActive(true);
                int value1 = Playerlist[activevalue].GetComponent<IndraAction>().Eaction[0]; string Name1 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value1];

                buttonsInPanel1[0].GetComponentInChildren<TMP_Text>().text = Name1;
            }
            if (Playerlist[activevalue].GetComponent<IndraAction>().EActiveAction == 2)
            {
                ButtonPanel[1].SetActive(true);
                int value1 = Playerlist[activevalue].GetComponent<IndraAction>().Eaction[0]; string Name1 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value1];
                int value2 = Playerlist[activevalue].GetComponent<IndraAction>().Eaction[1]; string Name2 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value2];

                buttonsInPanel2[0].GetComponentInChildren<TMP_Text>().text = Name1;
                buttonsInPanel2[1].GetComponentInChildren<TMP_Text>().text = Name2;
            }
            if (Playerlist[activevalue].GetComponent<IndraAction>().EActiveAction == 3)
            {
                ButtonPanel[2].SetActive(true);
                int value1 = Playerlist[activevalue].GetComponent<IndraAction>().Eaction[0]; string Name1 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value1];
                int value2 = Playerlist[activevalue].GetComponent<IndraAction>().Eaction[1]; string Name2 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value2];
                int value3 = Playerlist[activevalue].GetComponent<IndraAction>().Eaction[2]; string Name3 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value3];

                buttonsInPanel3[0].GetComponentInChildren<TMP_Text>().text = Name1;
                buttonsInPanel3[1].GetComponentInChildren<TMP_Text>().text = Name2;
                buttonsInPanel3[2].GetComponentInChildren<TMP_Text>().text = Name3;
            }
        }
        if (Name == "Prithvi")
        {
            if (Playerlist[activevalue].GetComponent<PrithviAction>().EActiveAction == 1)
            {
                ButtonPanel[0].SetActive(true);
                int value1 = Playerlist[activevalue].GetComponent<PrithviAction>().Eaction[0]; string Name1 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value1];

                buttonsInPanel1[0].GetComponentInChildren<TMP_Text>().text = Name1;
            }
            if (Playerlist[activevalue].GetComponent<PrithviAction>().EActiveAction == 2)
            {
                ButtonPanel[1].SetActive(true);
                int value1 = Playerlist[activevalue].GetComponent<PrithviAction>().Eaction[0]; string Name1 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value1];
                int value2 = Playerlist[activevalue].GetComponent<PrithviAction>().Eaction[1]; string Name2 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value2];

                buttonsInPanel2[0].GetComponentInChildren<TMP_Text>().text = Name1;
                buttonsInPanel2[1].GetComponentInChildren<TMP_Text>().text = Name2;
            }
            if (Playerlist[activevalue].GetComponent<PrithviAction>().EActiveAction == 3)
            {
                ButtonPanel[2].SetActive(true);
                int value1 = Playerlist[activevalue].GetComponent<PrithviAction>().Eaction[0]; string Name1 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value1];
                int value2 = Playerlist[activevalue].GetComponent<PrithviAction>().Eaction[1]; string Name2 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value2];
                int value3 = Playerlist[activevalue].GetComponent<PrithviAction>().Eaction[2]; string Name3 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value3];

                buttonsInPanel3[0].GetComponentInChildren<TMP_Text>().text = Name1;
                buttonsInPanel3[1].GetComponentInChildren<TMP_Text>().text = Name2;
                buttonsInPanel3[2].GetComponentInChildren<TMP_Text>().text = Name3;
            }
        }
        if (Name == "Sachi")
        {
            if (Playerlist[activevalue].GetComponent<SachiAction>().EActiveAction == 1)
            {
                ButtonPanel[0].SetActive(true);
                int value1 = Playerlist[activevalue].GetComponent<SachiAction>().Eaction[0]; string Name1 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value1];

                buttonsInPanel1[0].GetComponentInChildren<TMP_Text>().text = Name1;
            }
            if (Playerlist[activevalue].GetComponent<SachiAction>().EActiveAction == 2)
            {
                ButtonPanel[1].SetActive(true);
                int value1 = Playerlist[activevalue].GetComponent<SachiAction>().Eaction[0]; string Name1 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value1];
                int value2 = Playerlist[activevalue].GetComponent<SachiAction>().Eaction[1]; string Name2 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value2];

                buttonsInPanel2[0].GetComponentInChildren<TMP_Text>().text = Name1;
                buttonsInPanel2[1].GetComponentInChildren<TMP_Text>().text = Name2;
            }
            if (Playerlist[activevalue].GetComponent<SachiAction>().EActiveAction == 3)
            {
                ButtonPanel[2].SetActive(true);
                int value1 = Playerlist[activevalue].GetComponent<SachiAction>().Eaction[0]; string Name1 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value1];
                int value2 = Playerlist[activevalue].GetComponent<SachiAction>().Eaction[1]; string Name2 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value2];
                int value3 = Playerlist[activevalue].GetComponent<SachiAction>().Eaction[2]; string Name3 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value3];

                buttonsInPanel3[0].GetComponentInChildren<TMP_Text>().text = Name1;
                buttonsInPanel3[1].GetComponentInChildren<TMP_Text>().text = Name2;
                buttonsInPanel3[2].GetComponentInChildren<TMP_Text>().text = Name3;
            }
        }
        if (Name == "Vayu")
        {
            if (Playerlist[activevalue].GetComponent<VayuAction>().EActiveAction == 1)
            {
                ButtonPanel[0].SetActive(true);
                int value1 = Playerlist[activevalue].GetComponent<VayuAction>().Eaction[0]; string Name1 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value1];

                buttonsInPanel1[0].GetComponentInChildren<TMP_Text>().text = Name1;
            }
            if (Playerlist[activevalue].GetComponent<VayuAction>().EActiveAction == 2)
            {
                ButtonPanel[1].SetActive(true);
                int value1 = Playerlist[activevalue].GetComponent<VayuAction>().Eaction[0]; string Name1 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value1];
                int value2 = Playerlist[activevalue].GetComponent<VayuAction>().Eaction[1]; string Name2 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value2];

                buttonsInPanel2[0].GetComponentInChildren<TMP_Text>().text = Name1;
                buttonsInPanel2[1].GetComponentInChildren<TMP_Text>().text = Name2;
            }
            if (Playerlist[activevalue].GetComponent<VayuAction>().EActiveAction == 3)
            {
                ButtonPanel[2].SetActive(true);
                int value1 = Playerlist[activevalue].GetComponent<VayuAction>().Eaction[0]; string Name1 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value1];
                int value2 = Playerlist[activevalue].GetComponent<VayuAction>().Eaction[1]; string Name2 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value2];
                int value3 = Playerlist[activevalue].GetComponent<VayuAction>().Eaction[2]; string Name3 = Playerlist[activevalue].GetComponent<ActionList>().EnemyActionsList[value3];

                buttonsInPanel3[0].GetComponentInChildren<TMP_Text>().text = Name1;
                buttonsInPanel3[1].GetComponentInChildren<TMP_Text>().text = Name2;
                buttonsInPanel3[2].GetComponentInChildren<TMP_Text>().text = Name3;
            }
        }
    }

}
