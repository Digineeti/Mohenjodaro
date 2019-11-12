using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PrithviCallAction : MonoBehaviour
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

    TMP_Text[] TwoTextInButton1;
    TMP_Text[] TwoTextInButton2;
    TMP_Text[] TwoTextInButton3;
    TMP_Text[] TwoTextInButton4;

    TMP_Text[] TwoTextInButtonInActivePlayer;
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

            for (int i = 0; i < GetComponent<PrithviAction>().ActiveAction; i++)
            {
                ButtonPanel[GetComponent<PrithviAction>().ActiveAction - 1].SetActive(true);
                int value = GetComponent<PrithviAction>().Action[i];
                string Name = ActionList.ActivePlayerActionsList[value];
                if (GetComponent<PrithviAction>().ActiveAction == 1)
                {
                    TwoTextInButton1 = buttonsInPanel1[i].GetComponentsInChildren<TMP_Text>();
                    TwoTextInButton1[0].text = Name;
                }
                if (GetComponent<PrithviAction>().ActiveAction == 2)
                {
                    TwoTextInButton2 = buttonsInPanel2[i].GetComponentsInChildren<TMP_Text>();
                    TwoTextInButton2[0].text = Name;
                }
                if (GetComponent<PrithviAction>().ActiveAction == 3)
                {
                    TwoTextInButton3 = buttonsInPanel3[i].GetComponentsInChildren<TMP_Text>();
                    TwoTextInButton3[0].text = Name;
                }
                if (GetComponent<PrithviAction>().ActiveAction == 4)
                {
                    TwoTextInButton4 = buttonsInPanel4[i].GetComponentsInChildren<TMP_Text>();
                    TwoTextInButton4[0].text = Name;
                }
                for (int j = 0; j < GetComponent<PrithviAction>().specialPActioncount; j++)
                {
                    if (GetComponent<PrithviAction>().SpPAction[j, 0] == Name)
                    {
                        if (int.Parse(GetComponent<PrithviAction>().SpPAction[j, 1]) <= PlayerPrefs.GetFloat(gameObject.name + "_SPValue"))
                        {
                            if (GetComponent<PrithviAction>().ActiveAction == 1)
                            {
                                buttonsInPanel1[i].interactable = true;
                                TwoTextInButton1[1].text = GetComponent<PrithviAction>().SpPAction[j, 1];
                            }
                            else if (GetComponent<PrithviAction>().ActiveAction == 2)
                            {
                                buttonsInPanel2[i].interactable = true;
                                TwoTextInButton2[1].text = GetComponent<PrithviAction>().SpPAction[j, 1];
                            }
                            else if (GetComponent<PrithviAction>().ActiveAction == 3)
                            {
                                buttonsInPanel3[i].interactable = true;
                                TwoTextInButton3[1].text = GetComponent<PrithviAction>().SpPAction[j, 1];
                            }
                            else if (GetComponent<PrithviAction>().ActiveAction == 4)
                            {
                                buttonsInPanel4[i].interactable = true;
                                TwoTextInButton4[1].text = GetComponent<PrithviAction>().SpPAction[j, 1];
                            }
                        }
                        else
                        {
                            if (GetComponent<PrithviAction>().ActiveAction == 1)
                            {
                                buttonsInPanel1[i].interactable = false;
                                TwoTextInButton1[1].text = GetComponent<PrithviAction>().SpPAction[j, 1];
                            }
                            else if (GetComponent<PrithviAction>().ActiveAction == 2)
                            {
                                buttonsInPanel2[i].interactable = false;
                                TwoTextInButton2[1].text = GetComponent<PrithviAction>().SpPAction[j, 1];
                            }
                            else if (GetComponent<PrithviAction>().ActiveAction == 3)
                            {
                                buttonsInPanel3[i].interactable = false;
                                TwoTextInButton3[1].text = GetComponent<PrithviAction>().SpPAction[j, 1];
                            }
                            else if (GetComponent<PrithviAction>().ActiveAction == 4)
                            {
                                buttonsInPanel4[i].interactable = false;
                                TwoTextInButton4[1].text = GetComponent<PrithviAction>().SpPAction[j, 1];
                            }
                        }
                    }

                }
            }
            #endregion
            #region InActivePlayersetup
            PlayerList = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < PlayerList.Length; i++)
            {
                //InActivePlayerPanel
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

                        //Inactive Player action using for loop..
                        InActivebuttonsInPanel = PlayerList[i].transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(4 - GetComponent<PrithviAction>().InActiveAction).GetComponentsInChildren<Button>();

                        for (int z = 0; z < GetComponent<PrithviAction>().InActiveAction; z++)
                        {
                            if (GetComponent<PrithviAction>().InActiveAction == 1)
                            {
                                InActivePlayerPanel1.SetActive(true);
                            }
                            if (GetComponent<PrithviAction>().InActiveAction == 2)
                            {
                                InActivePlayerPanel2.SetActive(true);
                            }
                            if (GetComponent<PrithviAction>().InActiveAction == 3)
                            {
                                InActivePlayerPanel3.SetActive(true);
                            }
                            if (GetComponent<PrithviAction>().InActiveAction == 4)
                            {
                                InActivePlayerPanel4.SetActive(true);
                            }
                            int value = GetComponent<PrithviAction>().InActive[z]; string Name = ActionList.InActivePlayerActionList[value];

                            TwoTextInButtonInActivePlayer = InActivebuttonsInPanel[z].GetComponentsInChildren<TMP_Text>();
                            TwoTextInButtonInActivePlayer[0].text = Name;
                            //action active & inactive depending the player sp value.....
                            for (int j = 0; j < GetComponent<PrithviAction>().specialPActioncount; j++)
                            {
                                if (GetComponent<PrithviAction>().SpPAction[j, 0] == Name)
                                {
                                    if (int.Parse(GetComponent<PrithviAction>().SpPAction[j, 1]) <= PlayerPrefs.GetFloat(gameObject.name + "_SPValue"))
                                    {
                                        InActivebuttonsInPanel[z].interactable = true;
                                        TwoTextInButtonInActivePlayer[1].text = GetComponent<PrithviAction>().SpPAction[j, 1];
                                    }
                                    else
                                    {
                                        InActivebuttonsInPanel[z].interactable = false;
                                        TwoTextInButtonInActivePlayer[1].text = GetComponent<PrithviAction>().SpPAction[j, 1];
                                    }
                                }
                            }
                        }
                    }
                }
                catch (System.Exception)
                {
                }
            }
            #endregion
        }
    }
}
