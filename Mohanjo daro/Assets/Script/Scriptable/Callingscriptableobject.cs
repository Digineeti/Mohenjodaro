using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Callingscriptableobject : MonoBehaviour
{
    #region variable
   
    public ScriptableUI Attribute;
    public TMP_Text Name;
    //player health Panel
    public Slider HPHealthBar;
    //player PlayerUI
    public Slider HPValue;
    public GameObject[] SPValue;
    public TMP_Text Level;
    public TMP_Text EXP;
    public TMP_Text DEF;
    public TMP_Text MAT;
    public TMP_Text MDF;
    public TMP_Text AGI;
    public TMP_Text LUK;
    public TMP_Text ATK; 
    //player TurnAction
    public Slider TAHPValue;
    public GameObject[] TASPValue;
    //PlayerTurnInfo
    public Slider TIHPValue;
    public GameObject[] TISPValue;

    #endregion
    //private void OnEnable()
    //{
    //    if (PlayerPrefs.GetString(gameObject.name) == "")
    //    {
    //        Name.text = Attribute.name;

    //        HPHealthBar.maxValue = Attribute.HPMax;
    //        HPHealthBar.value = Attribute.HPMax;         //after call the current value here from playerpreref.
    //        //player PlayerUI
    //        HPValue.maxValue = Attribute.HPMax;
    //        HPValue.value = Attribute.HPMax;            //after call the current value here from playerpreref.
    //        //Player TurnAction
    //        TAHPValue.maxValue = Attribute.HPMax;
    //        TAHPValue.value = Attribute.HPMax;
    //        //Player TurnInfo
    //        TIHPValue.maxValue = Attribute.HPMax;
    //        TIHPValue.value = Attribute.HPMax;
    //        //player PlayerUI
    //        //SPValue.maxValue = Attribute.SPMax;
    //        //SPValue.value = 2;            //after call the current value here from playerpreref.
    //        //Player TurnAction
    //        //TASPValue.maxValue = Attribute.SPMax;
    //        //TASPValue.value = 2;
    //        //Player TurnInfo
    //        //TISPValue.maxValue = Attribute.SPMax;
    //        //TISPValue.value = 2;
    //        float value = 0;
    //        for (int i=0;i< 5; i++)
    //        {
    //            if(i< Attribute.SPMax)
    //            {
    //                SPValue[i].SetActive(true);
    //                TASPValue[i].SetActive(true);
    //                TISPValue[i].SetActive(true);
                    
    //                if (gameObject.name == "Sachi")
    //                    value = 4;
    //                else
    //                    value = 2;
    //                if (i<value)
    //                {
    //                    SPValue[i].GetComponent<SpriteRenderer>().color = Color.red;
    //                    TASPValue[i].GetComponent<SpriteRenderer>().color = Color.red;
    //                    TISPValue[i].GetComponent<SpriteRenderer>().color = Color.red;
    //                }
    //                else
    //                {
    //                    SPValue[i].GetComponent<SpriteRenderer>().color = Color.black;
    //                    TASPValue[i].GetComponent<SpriteRenderer>().color = Color.black;
    //                    TISPValue[i].GetComponent<SpriteRenderer>().color = Color.black;
    //                }
                   
    //            }
    //            else
    //            {
    //                SPValue[i].SetActive(false);
    //                TASPValue[i].SetActive(false);
    //                TISPValue[i].SetActive(false);
    //            }
    //        }
    //        Level.text = Attribute.Level.ToString();
    //        EXP.text = Attribute.Exp.ToString();
    //        DEF.text = Attribute.DEF.ToString();
    //        MAT.text = Attribute.MAT.ToString();
    //        MDF.text = Attribute.MDF.ToString();
    //        AGI.text = Attribute.AGI.ToString();
    //        LUK.text = Attribute.Luk.ToString();
    //        ATK.text = Attribute.ATK.ToString();
    //        PlayerPrefs.SetString(gameObject.name, Attribute.name);
    //        PlayerPrefs.SetFloat(gameObject.name + "_HPMax", Attribute.HPMax);
    //        PlayerPrefs.SetFloat(gameObject.name + "_HPValue", Attribute.HPMax);

    //        PlayerPrefs.SetFloat(gameObject.name + "_HPNormalValue", Attribute.HPMax);

    //        PlayerPrefs.SetFloat(gameObject.name + "_SPMax", Attribute.SPMax);
    //        PlayerPrefs.SetFloat(gameObject.name + "_SPValue", value);
    //        PlayerPrefs.SetFloat(gameObject.name + "_Level", float.Parse(Attribute.Level));
    //        PlayerPrefs.SetFloat(gameObject.name + "_Exp", Attribute.Exp);
    //        PlayerPrefs.SetFloat(gameObject.name + "_DEF", Attribute.DEF);
    //        PlayerPrefs.SetFloat(gameObject.name + "_MAT", Attribute.MAT);
    //        PlayerPrefs.SetFloat(gameObject.name + "_MDF", Attribute.MDF);
    //        PlayerPrefs.SetFloat(gameObject.name + "_AGI", Attribute.AGI);
    //        PlayerPrefs.SetFloat(gameObject.name + "_Luk", Attribute.Luk);
    //        PlayerPrefs.SetFloat(gameObject.name + "_ATK", Attribute.Luk);
    //    }
    //    else
    //    {
    //        Name.text = PlayerPrefs.GetString(gameObject.name);

    //        HPHealthBar.maxValue = PlayerPrefs.GetFloat(gameObject.name + "_HPMax");
    //        HPHealthBar.value = PlayerPrefs.GetFloat(gameObject.name + "_HPValue");
    //        //Player PlayerUI
    //        HPValue.maxValue = PlayerPrefs.GetFloat(gameObject.name + "_HPMax");
    //        HPValue.value = PlayerPrefs.GetFloat(gameObject.name + "_HPValue");
    //        //Player TurnAction
    //        TAHPValue.maxValue = PlayerPrefs.GetFloat(gameObject.name + "_HPMax");
    //        TAHPValue.value = PlayerPrefs.GetFloat(gameObject.name + "_HPValue");
    //        //Player TurnInfo
    //        TIHPValue.maxValue = PlayerPrefs.GetFloat(gameObject.name + "_HPMax");
    //        TIHPValue.value = PlayerPrefs.GetFloat(gameObject.name + "_HPValue");
    //        //player PlayerUi
    //        //SPValue.maxValue = PlayerPrefs.GetFloat(gameObject.name + "_SPMax");
    //        //SPValue.value = PlayerPrefs.GetFloat(gameObject.name + "_SPValue");
    //        //TASPValue.maxValue = PlayerPrefs.GetFloat(gameObject.name + "_SPMax");
    //        //TASPValue.value = PlayerPrefs.GetFloat(gameObject.name + "_SPValue");
    //        //Player TurnInfo
    //        ///TISPValue.maxValue = PlayerPrefs.GetFloat(gameObject.name + "_SPMax");
    //        //TISPValue.value = PlayerPrefs.GetFloat(gameObject.name + "_SPValue");

    //        for (int i = 0; i < 5; i++)
    //        {
    //            if (i < PlayerPrefs.GetFloat(gameObject.name + "_SPMax"))
    //            {
    //                SPValue[i].SetActive(true);
    //                TASPValue[i].SetActive(true);
    //                TISPValue[i].SetActive(true);
    //                if (i< PlayerPrefs.GetFloat(gameObject.name + "_SPValue"))
    //                {
    //                    SPValue[i].GetComponent<SpriteRenderer>().color = Color.red;
    //                    TASPValue[i].GetComponent<SpriteRenderer>().color = Color.red;
    //                    TISPValue[i].GetComponent<SpriteRenderer>().color = Color.red;
    //                }
    //                else
    //                {
    //                    SPValue[i].GetComponent<SpriteRenderer>().color=Color.black;
    //                    TASPValue[i].GetComponent<SpriteRenderer>().color = Color.black;
    //                    TISPValue[i].GetComponent<SpriteRenderer>().color = Color.black;
    //                }
                   
    //            }
    //            else
    //            {
    //                SPValue[i].SetActive(false);
    //                TASPValue[i].SetActive(false);
    //                TISPValue[i].SetActive(false);
    //            }
    //        }


    //        Level.text = PlayerPrefs.GetFloat(gameObject.name + "_Level").ToString();
    //        EXP.text = PlayerPrefs.GetFloat(gameObject.name + "_Exp").ToString();
    //        DEF.text = PlayerPrefs.GetFloat(gameObject.name + "_DEF").ToString();
    //        MAT.text = PlayerPrefs.GetFloat(gameObject.name + "_MAT").ToString();
    //        MDF.text = PlayerPrefs.GetFloat(gameObject.name + "_MDF").ToString();
    //        AGI.text = PlayerPrefs.GetFloat(gameObject.name + "_AGI").ToString();
    //        LUK.text = PlayerPrefs.GetFloat(gameObject.name + "_Luk").ToString();
    //        ATK.text = PlayerPrefs.GetFloat(gameObject.name + "_ATK").ToString();
    //    }

    //}
    private void Start()
    {
        if (PlayerPrefs.GetString(gameObject.name) == "")
        {
            Name.text = Attribute.name;

            HPHealthBar.maxValue = Attribute.HPMax;
            HPHealthBar.value = Attribute.HPMax;         //after call the current value here from playerpreref.
            //player PlayerUI
            HPValue.maxValue = Attribute.HPMax;
            HPValue.value = Attribute.HPMax;            //after call the current value here from playerpreref.
            //Player TurnAction
            TAHPValue.maxValue = Attribute.HPMax;
            TAHPValue.value = Attribute.HPMax;
            //Player TurnInfo
            TIHPValue.maxValue = Attribute.HPMax;
            TIHPValue.value = Attribute.HPMax;
            float value = 0;
            for (int i = 0; i < 5; i++)
            {
                if (i < Attribute.SPMax)
                {
                    SPValue[i].SetActive(true);
                    TASPValue[i].SetActive(true);
                    TISPValue[i].SetActive(true);
                    if (gameObject.name == "Sachi")
                        value = 4;
                    else
                        value = 2;
                    if (i < value)
                    {
                        SPValue[i].GetComponent<SpriteRenderer>().color = Color.red;
                        TASPValue[i].GetComponent<SpriteRenderer>().color = Color.red;
                        TISPValue[i].GetComponent<SpriteRenderer>().color = Color.red;
                    }
                    else
                    {
                        SPValue[i].GetComponent<SpriteRenderer>().color = Color.black;
                        TASPValue[i].GetComponent<SpriteRenderer>().color = Color.black;
                        TISPValue[i].GetComponent<SpriteRenderer>().color = Color.black;
                    }

                }
                else
                {
                    SPValue[i].SetActive(false);
                    TASPValue[i].SetActive(false);
                    TISPValue[i].SetActive(false);
                }
            }
            Level.text = Attribute.Level.ToString();
            EXP.text = Attribute.Exp.ToString();
            DEF.text = Attribute.DEF.ToString();
            MAT.text = Attribute.MAT.ToString();
            MDF.text = Attribute.MDF.ToString();
            AGI.text = Attribute.AGI.ToString();
            LUK.text = Attribute.Luk.ToString();
            ATK.text = Attribute.ATK.ToString();
            PlayerPrefs.SetString(gameObject.name, Attribute.name);
            PlayerPrefs.SetFloat(gameObject.name + "_HPMax", Attribute.HPMax);
            PlayerPrefs.SetFloat(gameObject.name + "_HPValue", Attribute.HPMax);

            PlayerPrefs.SetFloat(gameObject.name + "_HPNormalValue", Attribute.HPMax);

            PlayerPrefs.SetFloat(gameObject.name + "_SPMax", Attribute.SPMax);
            PlayerPrefs.SetFloat(gameObject.name + "_SPValue", value);
            PlayerPrefs.SetFloat(gameObject.name + "_Level", float.Parse(Attribute.Level));
            PlayerPrefs.SetFloat(gameObject.name + "_Exp", Attribute.Exp);
            PlayerPrefs.SetFloat(gameObject.name + "_DEF", Attribute.DEF);
            PlayerPrefs.SetFloat(gameObject.name + "_MAT", Attribute.MAT);
            PlayerPrefs.SetFloat(gameObject.name + "_MDF", Attribute.MDF);
            PlayerPrefs.SetFloat(gameObject.name + "_AGI", Attribute.AGI);
            PlayerPrefs.SetFloat(gameObject.name + "_Luk", Attribute.Luk);
            PlayerPrefs.SetFloat(gameObject.name + "_ATK", Attribute.Luk);
        }
        else
        {
            Name.text = PlayerPrefs.GetString(gameObject.name);

            HPHealthBar.maxValue = PlayerPrefs.GetFloat(gameObject.name + "_HPMax");
            HPHealthBar.value = PlayerPrefs.GetFloat(gameObject.name + "_HPValue");
            //Player PlayerUI
            HPValue.maxValue = PlayerPrefs.GetFloat(gameObject.name + "_HPMax");
            HPValue.value = PlayerPrefs.GetFloat(gameObject.name + "_HPValue");
            //Player TurnAction
            TAHPValue.maxValue = PlayerPrefs.GetFloat(gameObject.name + "_HPMax");
            TAHPValue.value = PlayerPrefs.GetFloat(gameObject.name + "_HPValue");
            //Player TurnInfo
            TIHPValue.maxValue = PlayerPrefs.GetFloat(gameObject.name + "_HPMax");
            TIHPValue.value = PlayerPrefs.GetFloat(gameObject.name + "_HPValue");
            for (int i = 0; i < 5; i++)
            {
                if (i < PlayerPrefs.GetFloat(gameObject.name + "_SPMax"))
                {
                    SPValue[i].SetActive(true);
                    TASPValue[i].SetActive(true);
                    TISPValue[i].SetActive(true);
                    if (i < PlayerPrefs.GetFloat(gameObject.name + "_SPValue"))
                    {
                        SPValue[i].GetComponent<SpriteRenderer>().color = Color.red;
                        TASPValue[i].GetComponent<SpriteRenderer>().color = Color.red;
                        TISPValue[i].GetComponent<SpriteRenderer>().color = Color.red;
                    }
                    else
                    {
                        SPValue[i].GetComponent<SpriteRenderer>().color = Color.black;
                        TASPValue[i].GetComponent<SpriteRenderer>().color = Color.black;
                        TISPValue[i].GetComponent<SpriteRenderer>().color = Color.black;
                    }

                }
                else
                {
                    SPValue[i].SetActive(false);
                    TASPValue[i].SetActive(false);
                    TISPValue[i].SetActive(false);
                }
            }

            Level.text = PlayerPrefs.GetFloat(gameObject.name + "_Level").ToString();
            EXP.text = PlayerPrefs.GetFloat(gameObject.name + "_Exp").ToString();
            DEF.text = PlayerPrefs.GetFloat(gameObject.name + "_DEF").ToString();
            MAT.text = PlayerPrefs.GetFloat(gameObject.name + "_MAT").ToString();
            MDF.text = PlayerPrefs.GetFloat(gameObject.name + "_MDF").ToString();
            AGI.text = PlayerPrefs.GetFloat(gameObject.name + "_AGI").ToString();
            LUK.text = PlayerPrefs.GetFloat(gameObject.name + "_Luk").ToString();
            ATK.text = PlayerPrefs.GetFloat(gameObject.name + "_ATK").ToString();
        }




    }

    private void Awake()
    {
        PlayerPrefs.DeleteAll();
        
    }
    private void LateUpdate()
    {
        if (PlayerPrefs.GetString(gameObject.name) == "")
        {
            Name.text = Attribute.name;

            HPHealthBar.maxValue = Attribute.HPMax;
            HPHealthBar.value = Attribute.HPMax;         //after call the current value here from playerpreref.
            //player PlayerUI
            HPValue.maxValue = Attribute.HPMax;
            HPValue.value = Attribute.HPMax;            //after call the current value here from playerpreref.
            //Player TurnAction
            TAHPValue.maxValue = Attribute.HPMax;
            TAHPValue.value = Attribute.HPMax;
            //Player TurnInfo
            TIHPValue.maxValue = Attribute.HPMax;
            TIHPValue.value = Attribute.HPMax;
           
            float value = 0;
            for (int i = 0; i < 5; i++)
            {
                if (i < Attribute.SPMax)
                {
                    SPValue[i].SetActive(true);
                    TASPValue[i].SetActive(true);
                    TISPValue[i].SetActive(true);
                    if (gameObject.name == "Sachi")
                        value = 4;
                    else
                        value = 2;
                    if (i < value)
                    {
                        SPValue[i].GetComponent<SpriteRenderer>().color = Color.red;
                        TASPValue[i].GetComponent<SpriteRenderer>().color = Color.red;
                        TISPValue[i].GetComponent<SpriteRenderer>().color = Color.red;
                    }
                    else
                    {
                        SPValue[i].GetComponent<SpriteRenderer>().color = Color.black;
                        TASPValue[i].GetComponent<SpriteRenderer>().color = Color.black;
                        TISPValue[i].GetComponent<SpriteRenderer>().color = Color.black;
                    }

                }
                else
                {
                    SPValue[i].SetActive(false);
                    TASPValue[i].SetActive(false);
                    TISPValue[i].SetActive(false);
                }
            }
            Level.text = Attribute.Level.ToString();
            EXP.text = Attribute.Exp.ToString();
            DEF.text = Attribute.DEF.ToString();
            MAT.text = Attribute.MAT.ToString();
            MDF.text = Attribute.MDF.ToString();
            AGI.text = Attribute.AGI.ToString();
            LUK.text = Attribute.Luk.ToString();
            ATK.text = Attribute.ATK.ToString();
            PlayerPrefs.SetString(gameObject.name, Attribute.name);
            PlayerPrefs.SetFloat(gameObject.name + "_HPMax", Attribute.HPMax);
            PlayerPrefs.SetFloat(gameObject.name + "_HPValue", Attribute.HPMax);

            PlayerPrefs.SetFloat(gameObject.name + "_HPNormalValue", Attribute.HPMax);

            PlayerPrefs.SetFloat(gameObject.name + "_SPMax", Attribute.SPMax);
            PlayerPrefs.SetFloat(gameObject.name + "_SPValue", value);
            PlayerPrefs.SetFloat(gameObject.name + "_Level", float.Parse(Attribute.Level));
            PlayerPrefs.SetFloat(gameObject.name + "_Exp", Attribute.Exp);
            PlayerPrefs.SetFloat(gameObject.name + "_DEF", Attribute.DEF);
            PlayerPrefs.SetFloat(gameObject.name + "_MAT", Attribute.MAT);
            PlayerPrefs.SetFloat(gameObject.name + "_MDF", Attribute.MDF);
            PlayerPrefs.SetFloat(gameObject.name + "_AGI", Attribute.AGI);
            PlayerPrefs.SetFloat(gameObject.name + "_Luk", Attribute.Luk);
            PlayerPrefs.SetFloat(gameObject.name + "_ATK", Attribute.Luk);
        }
        else
        {
            Name.text = PlayerPrefs.GetString(gameObject.name);

            HPHealthBar.maxValue = PlayerPrefs.GetFloat(gameObject.name + "_HPMax");
            HPHealthBar.value = PlayerPrefs.GetFloat(gameObject.name + "_HPValue");
            //Player PlayerUI
            HPValue.maxValue = PlayerPrefs.GetFloat(gameObject.name + "_HPMax");
            HPValue.value = PlayerPrefs.GetFloat(gameObject.name + "_HPValue");
            //Player TurnAction
            TAHPValue.maxValue = PlayerPrefs.GetFloat(gameObject.name + "_HPMax");
            TAHPValue.value = PlayerPrefs.GetFloat(gameObject.name + "_HPValue");
            //Player TurnInfo
            TIHPValue.maxValue = PlayerPrefs.GetFloat(gameObject.name + "_HPMax");
            TIHPValue.value = PlayerPrefs.GetFloat(gameObject.name + "_HPValue");           
            for (int i = 0; i < 5; i++)
            {
                if (i < PlayerPrefs.GetFloat(gameObject.name + "_SPMax"))
                {
                    SPValue[i].SetActive(true);
                    TASPValue[i].SetActive(true);
                    TISPValue[i].SetActive(true);
                    if (i < PlayerPrefs.GetFloat(gameObject.name + "_SPValue"))
                    {
                        SPValue[i].GetComponent<SpriteRenderer>().color = Color.red;
                        TASPValue[i].GetComponent<SpriteRenderer>().color = Color.red;
                        TISPValue[i].GetComponent<SpriteRenderer>().color = Color.red;
                    }
                    else
                    {
                        SPValue[i].GetComponent<SpriteRenderer>().color = Color.black;
                        TASPValue[i].GetComponent<SpriteRenderer>().color = Color.black;
                        TISPValue[i].GetComponent<SpriteRenderer>().color = Color.black;
                    }

                }
                else
                {
                    SPValue[i].SetActive(false);
                    TASPValue[i].SetActive(false);
                    TISPValue[i].SetActive(false);
                }
            }

            Level.text = PlayerPrefs.GetFloat(gameObject.name + "_Level").ToString();
            EXP.text = PlayerPrefs.GetFloat(gameObject.name + "_Exp").ToString();
            DEF.text = PlayerPrefs.GetFloat(gameObject.name + "_DEF").ToString();
            MAT.text = PlayerPrefs.GetFloat(gameObject.name + "_MAT").ToString();
            MDF.text = PlayerPrefs.GetFloat(gameObject.name + "_MDF").ToString();
            AGI.text = PlayerPrefs.GetFloat(gameObject.name + "_AGI").ToString();
            LUK.text = PlayerPrefs.GetFloat(gameObject.name + "_Luk").ToString();
            ATK.text = PlayerPrefs.GetFloat(gameObject.name + "_ATK").ToString();
        }



    }

}
