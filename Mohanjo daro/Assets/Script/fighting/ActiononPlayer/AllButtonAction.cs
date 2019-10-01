using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using TMPro;

public class AllButtonAction : MonoBehaviour
{
    public GameObject[] Players;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fight_Button_Action_Event()
    {
        string name = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TMP_Text>().text;
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
       
    }
}
