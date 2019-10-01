using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class VayuCallScript : MonoBehaviour
{
    public GameObject[] ButtonPanel;
    public GameObject[] PlayerList;
   

    public ActionList ActionList;

    Button[] buttonsInPanel1;
    Button[] buttonsInPanel2;
    Button[] buttonsInPanel3;
    Button[] buttonsInPanel4;

    public GameObject InActivePlayerPanel1;
    public GameObject InActivePlayerPanel2;
    public GameObject InActivePlayerPanel3;
    public GameObject InActivePlayerPanel4;
    Button[] InActivebuttonsInPanel;
    bool startup;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        buttonsInPanel1 = ButtonPanel[0].GetComponentsInChildren<Button>();
        buttonsInPanel2 = ButtonPanel[1].GetComponentsInChildren<Button>();
        buttonsInPanel3 = ButtonPanel[2].GetComponentsInChildren<Button>();
        buttonsInPanel4 = ButtonPanel[3].GetComponentsInChildren<Button>();
        anim = GetComponent<Animator>();
        
    }


    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<PA>().state.ToString() == "waitingforinput")
        {

            #region activeplayersetup

            for (int i = 0; i < ButtonPanel.Length; i++)
            {
                ButtonPanel[i].SetActive(false);

            }

            if (GetComponent<VayuAction>().ActiveAction == 1)
            {
                ButtonPanel[0].SetActive(true);
                int value1 = GetComponent<VayuAction>().Action[0]; string Name1 = ActionList.ActivePlayerActionsList[value1];

                buttonsInPanel1[0].GetComponentInChildren<TMP_Text>().text = Name1;
            }
            if (GetComponent<VayuAction>().ActiveAction == 2)
            {
                ButtonPanel[1].SetActive(true);

                int value1 = GetComponent<VayuAction>().Action[0]; string Name1 = ActionList.ActivePlayerActionsList[value1];
                int value2 = GetComponent<VayuAction>().Action[1]; string Name2 = ActionList.ActivePlayerActionsList[value2];


                buttonsInPanel2[0].GetComponentInChildren<TMP_Text>().text = Name1;
                buttonsInPanel2[1].GetComponentInChildren<TMP_Text>().text = Name2;


            }
            if (GetComponent<VayuAction>().ActiveAction == 3)
            {
                ButtonPanel[2].SetActive(true);

                int value1 = GetComponent<VayuAction>().Action[0]; string Name1 = ActionList.ActivePlayerActionsList[value1];
                int value2 = GetComponent<VayuAction>().Action[1]; string Name2 = ActionList.ActivePlayerActionsList[value2];
                int value3 = GetComponent<VayuAction>().Action[2]; string Name3 = ActionList.ActivePlayerActionsList[value3];


                buttonsInPanel3[0].GetComponentInChildren<TMP_Text>().text = Name1;
                buttonsInPanel3[1].GetComponentInChildren<TMP_Text>().text = Name2;
                buttonsInPanel3[2].GetComponentInChildren<TMP_Text>().text = Name3;
            }
            if (GetComponent<VayuAction>().ActiveAction == 4)
            {
                ButtonPanel[3].SetActive(true);

                int value1 = GetComponent<VayuAction>().Action[0]; string Name1 = ActionList.ActivePlayerActionsList[value1];
                int value2 = GetComponent<VayuAction>().Action[1]; string Name2 = ActionList.ActivePlayerActionsList[value2];
                int value3 = GetComponent<VayuAction>().Action[2]; string Name3 = ActionList.ActivePlayerActionsList[value3];
                int value4 = GetComponent<VayuAction>().Action[3]; string Name4 = ActionList.ActivePlayerActionsList[value4];


                buttonsInPanel4[0].GetComponentInChildren<TMP_Text>().text = Name1;
                buttonsInPanel4[1].GetComponentInChildren<TMP_Text>().text = Name2;
                buttonsInPanel4[2].GetComponentInChildren<TMP_Text>().text = Name3;
                buttonsInPanel4[3].GetComponentInChildren<TMP_Text>().text = Name4;
            }


            //animation and action here 
            // the global variable for activate the action 
            //Globalvariable.currentTime += Time.deltaTime;
            //if (Globalvariable.Active_Player_Action)
            //{               
            //    Globalvariable.nextTime = Globalvariable.currentTime + 1f;
            //    anim.SetBool(Globalvariable.Active_Player_Animation_Parameter,true);
            //    startup = true;
            //    Globalvariable.Active_Player_Action = false;
            //}
            //if(startup==true)
            //{
            //    if(Globalvariable.currentTime> Globalvariable.nextTime)
            //    {
            //        startup = false;
            //        anim.SetBool(Globalvariable.Active_Player_Animation_Parameter, false);
            //        Globalvariable.Index--;
            //        Globalvariable.Active_Player_Animation_Parameter =null;
            //    }

            //}

            #endregion

            PlayerList = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < PlayerList.Length; i++)
            {
                //InActivePlayerPanel
                //if condition number of buton to make active 
                //InActivebuttonsInPanel2 = PlayerList[i].transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).GetComponentsInChildren<Button>();
                //InActivebuttonsInPanel3 = PlayerList[i].transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).GetComponentsInChildren<Button>();
                //InActivebuttonsInPanel4 = PlayerList[i].transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponentsInChildren<Button>();
                try
                {
                    if (PlayerList[i].GetComponent<PA>().state.ToString() == "waitingforinput")
                    {

                    }
                    else
                    {
                        InActivePlayerPanel1 = PlayerList[i].transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject;
                        InActivePlayerPanel1.SetActive(false);

                        InActivePlayerPanel2 = PlayerList[i].transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;
                        InActivePlayerPanel2.SetActive(false);

                        InActivePlayerPanel3 = PlayerList[i].transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                        InActivePlayerPanel3.SetActive(false);

                        InActivePlayerPanel4 = PlayerList[i].transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                        InActivePlayerPanel4.SetActive(false);

                        if (GetComponent<VayuAction>().InActiveAction == 1)
                        {
                            InActivePlayerPanel1.SetActive(true);
                            int value1 = GetComponent<VayuAction>().InActive[0]; string Name1 = ActionList.InActivePlayerActionList[value1];

                            InActivebuttonsInPanel = PlayerList[i].transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).GetComponentsInChildren<Button>();
                            InActivebuttonsInPanel[0].GetComponentInChildren<TMP_Text>().text = Name1;
                        }
                        if (GetComponent<VayuAction>().InActiveAction == 2)
                        {
                            InActivePlayerPanel2.SetActive(true);

                            int value1 = GetComponent<VayuAction>().InActive[0]; string Name1 = ActionList.InActivePlayerActionList[value1];
                            int value2 = GetComponent<VayuAction>().InActive[1]; string Name2 = ActionList.InActivePlayerActionList[value2];

                            InActivebuttonsInPanel = PlayerList[i].transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).GetComponentsInChildren<Button>();
                            InActivebuttonsInPanel[0].GetComponentInChildren<TMP_Text>().text = Name1;
                            InActivebuttonsInPanel[1].GetComponentInChildren<TMP_Text>().text = Name2;
                        }
                        if (GetComponent<VayuAction>().InActiveAction == 3)
                        {
                            InActivePlayerPanel3.SetActive(true);

                            int value1 = GetComponent<VayuAction>().InActive[0]; string Name1 = ActionList.InActivePlayerActionList[value1];
                            int value2 = GetComponent<VayuAction>().InActive[1]; string Name2 = ActionList.InActivePlayerActionList[value2];
                            int value3 = GetComponent<VayuAction>().InActive[2]; string Name3 = ActionList.InActivePlayerActionList[value3];

                            InActivebuttonsInPanel = PlayerList[i].transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).GetComponentsInChildren<Button>();

                            InActivebuttonsInPanel[0].GetComponentInChildren<TMP_Text>().text = Name1;
                            InActivebuttonsInPanel[1].GetComponentInChildren<TMP_Text>().text = Name2;
                            InActivebuttonsInPanel[2].GetComponentInChildren<TMP_Text>().text = Name3;
                        }
                        if (GetComponent<VayuAction>().InActiveAction == 4)
                        {
                            InActivePlayerPanel4.SetActive(true);

                            int value1 = GetComponent<VayuAction>().InActive[0]; string Name1 = ActionList.InActivePlayerActionList[value1];
                            int value2 = GetComponent<VayuAction>().InActive[1]; string Name2 = ActionList.InActivePlayerActionList[value2];
                            int value3 = GetComponent<VayuAction>().InActive[2]; string Name3 = ActionList.InActivePlayerActionList[value3];
                            int value4 = GetComponent<VayuAction>().InActive[3]; string Name4 = ActionList.InActivePlayerActionList[value4];

                            InActivebuttonsInPanel = PlayerList[i].transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).GetComponentsInChildren<Button>();

                            InActivebuttonsInPanel[0].GetComponentInChildren<TMP_Text>().text = Name1;
                            InActivebuttonsInPanel[1].GetComponentInChildren<TMP_Text>().text = Name2;
                            InActivebuttonsInPanel[2].GetComponentInChildren<TMP_Text>().text = Name3;
                            InActivebuttonsInPanel[3].GetComponentInChildren<TMP_Text>().text = Name4;
                        }
                    }
                }
                catch (System.Exception)
                {


                }
            }
        }
       

    }
}
