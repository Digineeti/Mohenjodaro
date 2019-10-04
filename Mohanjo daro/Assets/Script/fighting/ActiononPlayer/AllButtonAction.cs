using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using TMPro;

public class AllButtonAction : MonoBehaviour
{
    public GameObject[] Players;
    bool startup= true;

    float PlayerAttackPower;
    float EnemyDefenceValue;
    string name;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(startup==true)
        {
            
            startup = false;
        }
    }

    public void Fight_Button_Action_Event()
    {
        //Players=GetComponent<Turn_Management>().spawanHero;
        name = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TMP_Text>().text;
        GameObject Button_Click_On_Player = gameObject.transform.parent.parent.parent.parent.parent.gameObject;
        //Debug.Log(Button_Click_On_Player.name);
        //Hero Ation
        if (name == "Defence")
        {
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (name == "Item")
        {
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (name == "RunAway")
        {
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (name == "Heal")
        {
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (name == "HealAll")
        {
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (name == "DefenceBoost")
        {
            //testing first for vayu
            //this set for action activate in the active player 
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";

            //this section for current player activity and animation that start after active player animation over 
            //or start current player animation with the delay time..

        }
        if (name == "DefenceAllBoost")
        {
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (name == "AttackBoost")
        {
            //testing first for vayu
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";

        }
        if (name == "AttackAllBoost")
        {
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (name == "Revive")
        {
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (name == "Protect")
        {
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }      

        //enemy action

        if (name == "Attack")
        {
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";

            //Extract ata on the click game object value
            EnemyDefenceValue = Button_Click_On_Player.GetComponent<En_Callingscriptableobject>().Attribute.DEF;
            PlayerAttackPower=ActivePlayer_Attack_Attribute();
            //calculating attackpower using the formula
            float  damaged = (PlayerAttackPower*PlayerAttackPower) / (PlayerAttackPower+EnemyDefenceValue);

            GameObject damagepanel = Button_Click_On_Player.transform.GetChild(1).gameObject;
            damagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(damaged).ToString();
            damagepanel.SetActive(true);
            //the enemy current Hp value 
            //float currentHp = Button_Click_On_Player.GetComponent<En_Callingscriptableobject>().Attribute.HPMax- damaged;
            //Button_Click_On_Player.GetComponent<En_Callingscriptableobject>().Attribute.HPMax = Button_Click_On_Player.GetComponent<En_Callingscriptableobject>().Attribute.HPMax- Mathf.RoundToInt(damaged);
            PlayerPrefs.SetFloat(Button_Click_On_Player.name + "_HPValue", PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") - Mathf.RoundToInt(damaged));


        }
        if (name == "LightingAttack")
        {
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (name == "ThunderStrom")
        {
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (name == "LightBoom")
        {
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (name == "AirAttack")
        {

            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (name == "FireBall")
        {
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (name == "Inferno")
        {
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (name == "QuickEnd")
        {
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (name == "EarthQuake")
        {
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (name == "Wind")
        {
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (name == "FireBlast")
        {
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (name == "HeavenlyWorth")
        {
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (name == "HeavenlyWorth")
        {
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
       if(name== "Strom")
        {
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
    }

    public float  ActivePlayer_Attack_Attribute()
    {
        float value = -1;
        //for(int i=0;i<Players.Length;i++)
        //{
        GameObject Button_Click_On_Player = gameObject.transform.parent.parent.parent.parent.parent.gameObject;
        try
        {
            if (Button_Click_On_Player.GetComponent<PA>().state.ToString() == "waitingforinput")
            {
                value = Button_Click_On_Player.GetComponent<Callingscriptableobject>().Attribute.ATK;
            }
        }
        catch (System.Exception)
        {
            //if (Players[i].GetComponent<EnemyAction>().state.ToString() == "Action")
            //{
            //    value = Players[i].GetComponent<En_Callingscriptableobject>().Attribute.ATK;
            //}
        }
        if (value < 0)
        {
            for (int i = 0; i < Players.Length; i++)
            {
                try
                {
                    if (Players[i].GetComponent<PA>().state.ToString() == "waitingforinput")
                    {
                        value = Players[i].GetComponent<Callingscriptableobject>().Attribute.ATK;
                    }
                }
                catch (System.Exception)
                {
                    //if (Players[i].GetComponent<EnemyAction>().state.ToString() == "Action")
                    //{
                    //    value = Players[i].GetComponent<En_Callingscriptableobject>().Attribute.ATK;
                    //}
                }
            }
        }


        //}
        return value;
    }

    
}
