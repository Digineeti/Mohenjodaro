using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using TMPro;

public class AllButtonAction : MonoBehaviour
{
    //public GameObject[] Players;
    //public GameObject[] Enemy;
    public GameObject[] spawanHero;
    bool startup= true;

    float PlayerAttackPower;
    float EnemyDefenceValue;
    private string Name;

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
        Name = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TMP_Text>().text;
        GameObject Button_Click_On_Player = gameObject.transform.parent.parent.parent.parent.parent.gameObject;
        spawanHero = GameObject.FindGameObjectsWithTag("Player");
        //Debug.Log(Button_Click_On_Player.name);
        //Hero Ation
        if (Name == "Defence")
        {
            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (Name == "Item")
        {
            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
            //heal all action for enemy 
            for (int i = 0; i < spawanHero.Length; i++)
            {
                try
                {
                    if(spawanHero[i].GetComponent<EnemyAction>().state.ToString()== "busy")
                    {
                        Debug.Log(PlayerPrefs.GetFloat(spawanHero[i].gameObject.name + "_HPValue"));
                        float currentHPvalue = PlayerPrefs.GetFloat(spawanHero[i].gameObject.name + "_HPValue");
                        currentHPvalue -= 40;

                        PlayerPrefs.SetFloat(spawanHero[i].gameObject.name + "_HPValue", currentHPvalue);
                        Debug.Log(PlayerPrefs.GetFloat(spawanHero[i].gameObject.name + "_HPValue"));
                    }
                   
                }
                catch (System.Exception)
                {                   
                }
               
            }
        }
        if (Name == "RunAway")
        {
            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";

            //heal all action for player 

            for(int i=0;i< spawanHero.Length;i++)
            {
                try
                {
                    if (spawanHero[i].GetComponent<PA>().state.ToString() == "busy" || spawanHero[i].GetComponent<PA>().state.ToString() == "waitingforinput")
                    {
                        float currentHPvalue = PlayerPrefs.GetFloat(spawanHero[i].gameObject.name + "_HPValue");
                        currentHPvalue += 400;

                        PlayerPrefs.SetFloat(spawanHero[i].gameObject.name + "_HPValue", currentHPvalue);
                        Debug.Log(PlayerPrefs.GetFloat(spawanHero[i].gameObject.name + "_HPValue"));
                    }
                }
                catch (System.Exception)
                {
                    
                }
              
                   
            }
        }
        if (Name == "Heal")
        {
            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (Name == "HealAll")
        {
            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (Name == "DefenceBoost")
        {
            Globalvariable.After_Death_ReSequence += 1;
            //testing first for vayu
            //this set for action activate in the active player 
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";

            //this section for current player activity and animation that start after active player animation over 
            //or start current player animation with the delay time..

        }
        if (Name == "DefenceAllBoost")
        {
            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (Name == "AttackBoost")
        {
            Globalvariable.After_Death_ReSequence += 1;
            //testing first for vayu
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";

        }
        if (Name == "AttackAllBoost")
        {
            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (Name == "Revive")
        {
            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (Name == "Protect")
        {
            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }      

        //enemy action

        if (Name == "Attack")
        {
            Globalvariable.After_Death_ReSequence += 1;
            //player animation on hit
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
          
            PlayerPrefs.SetFloat(Button_Click_On_Player.name + "_HPValue", PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") - Mathf.RoundToInt(damaged));
            if (PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue")<=0)
            {
               
               
                Button_Click_On_Player.GetComponent<Animator>().SetBool("Death", true);
                Destroy(GameObject.Find(Button_Click_On_Player.name),2f);
                // Button_Click_On_Player.GetComponent<EnemyAction>().state =EnemyAction.State.Death;// "Death"; 


            }


        }
        if (Name == "LightingAttack")
        {
            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (Name == "ThunderStrom")
        {
            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (Name == "LightBoom")
        {
            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (Name == "AirAttack")
        {
            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (Name == "FireBall")
        {
            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (Name == "Inferno")
        {
            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (Name == "QuickEnd")
        {
            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (Name == "EarthQuake")
        {
            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (Name == "Wind")
        {
            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (Name == "FireBlast")
        {
            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (Name == "HeavenlyWorth")
        {
            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (Name == "HeavenlyWorth")
        {
            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
       if(Name == "Strom")
        {
            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
    }

    public float  ActivePlayer_Attack_Attribute()
    {
        float value = -1;
        //for(int i=0;i<Players.Length;i++)
        //{
        spawanHero = GameObject.FindGameObjectsWithTag("Player");
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
            for (int i = 0; i < spawanHero.Length; i++)
            {
                try
                {
                    if (spawanHero[i].GetComponent<PA>().state.ToString() == "waitingforinput")
                    {
                        value = spawanHero[i].GetComponent<Callingscriptableobject>().Attribute.ATK;
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
