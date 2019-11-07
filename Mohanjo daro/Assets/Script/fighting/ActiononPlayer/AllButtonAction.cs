﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            EnemyDefenceValue = PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_DEF");

            float value = -1;
            float luckValue = 0;
            spawanHero = GameObject.FindGameObjectsWithTag("Player");
            //GameObject Button_Click_On_Player = gameObject.transform.parent.parent.parent.parent.parent.gameObject;
            try
            {
                if (Button_Click_On_Player.GetComponent<PA>().state.ToString() == "waitingforinput")
                {
                    //extract the atk value from the playerprefs save data...
                    value = Button_Click_On_Player.GetComponent<Callingscriptableobject>().Attribute.ATK;
                    luckValue= PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_Luk");
                }
            }
            catch (System.Exception)
            {

            }
            if (value < 0)
            {
                for (int i = 0; i < spawanHero.Length; i++)
                {
                    try
                    {
                        if (spawanHero[i].GetComponent<PA>().state.ToString() == "waitingforinput")
                        {
                            //extract the atk value from the playerprefs save data...
                            value = spawanHero[i].GetComponent<Callingscriptableobject>().Attribute.ATK;
                            luckValue = PlayerPrefs.GetFloat(spawanHero[i].name + "_Luk");
                        }
                    }
                    catch (System.Exception)
                    {
                        
                    }
                }
            }

            PlayerAttackPower = value;
           
            //player animation on hit
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";

            // Extract ata on the click game object value
            // EnemyDefenceValue = Button_Click_On_Player.GetComponent<En_Callingscriptableobject>().Attribute.DEF;
            //damaged on the basis of luck value 
            float missvalue=100-luckValue;
            if (missvalue > 25)
                missvalue = 25;

            float criticalvalue = (100 - ((luckValue * 20) / 100))+1;
            float damaged=0;
            float randonvalue = Random.Range(1, 100);
            if(randonvalue>0 && randonvalue<=missvalue)
            {
                damaged = (4 * PlayerAttackPower - 2 * EnemyDefenceValue)*0;
                Debug.Log("damaged miss " + damaged);
            }
            else if(randonvalue>missvalue && randonvalue<criticalvalue)
            {
                damaged = (4 * PlayerAttackPower - 2 * EnemyDefenceValue) * 1;
                Debug.Log("damaged normal " + damaged);
            }
            else
            {
                damaged = (4 * PlayerAttackPower - 2 * EnemyDefenceValue) * 2;
                Debug.Log("damaged critical "+ damaged );
            }
            //calculating attackpower using the formula
          


            GameObject damagepanel = Button_Click_On_Player.transform.GetChild(1).gameObject;
            damagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(damaged).ToString();
            damagepanel.SetActive(true);

          
           
            //the enemy current Hp value           
            PlayerPrefs.SetFloat(Button_Click_On_Player.name + "_HPValue", PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") - Mathf.RoundToInt(damaged));
            if (PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue")<=0)
            {  
                Button_Click_On_Player.GetComponent<Animator>().SetBool("Death", true);
                Destroy(GameObject.Find(Button_Click_On_Player.transform.parent.name),2f);
                Globalvariable.WinningLosing = true;
                Globalvariable.After_Death_ReSequence += 1;
            }


        }
        if (Name == "LightingAttack")
        {
            EnemyDefenceValue = PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_DEF");

            float value = -1;
            float luckValue = 0;
            spawanHero = GameObject.FindGameObjectsWithTag("Player");
            //GameObject Button_Click_On_Player = gameObject.transform.parent.parent.parent.parent.parent.gameObject;
            try
            {
                if (Button_Click_On_Player.GetComponent<PA>().state.ToString() == "waitingforinput")
                {
                    value = Button_Click_On_Player.GetComponent<Callingscriptableobject>().Attribute.ATK;
                    PlayerPrefs.SetFloat(Button_Click_On_Player.name + "_SPValue", PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_SPValue") - Mathf.RoundToInt(20));
                    luckValue = PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_Luk");
                }
            }
            catch (System.Exception)
            {

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
                            PlayerPrefs.SetFloat(spawanHero[i].name + "_SPValue", PlayerPrefs.GetFloat(spawanHero[i].name + "_SPValue") - Mathf.RoundToInt(20));
                            luckValue = PlayerPrefs.GetFloat(spawanHero[i].name + "_Luk");
                        }
                    }
                    catch (System.Exception)
                    {
                    }
                }
            }

            PlayerAttackPower = value;
          
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";


            //sp used =20 one 

            float missvalue = 100 - luckValue;
            if (missvalue > 25)
                missvalue = 25;

            float criticalvalue = (100 - ((luckValue * 20) / 100)) + 1;
            float damaged = 0;
            float randonvalue = Random.Range(1, 100);

            damaged = 1.5F * PlayerAttackPower;
            float MAXDamage = damaged + (damaged * 20) / 100;
            float DamagedReceive = 0;
            DamagedReceive = Mathf.Clamp(DamagedReceive, damaged, MAXDamage);

            if (randonvalue > 0 && randonvalue <= missvalue)
            {               
                DamagedReceive = DamagedReceive * 0;                
            }
            else if (randonvalue > missvalue && randonvalue < criticalvalue)
            {
                DamagedReceive = DamagedReceive * 1;
            }
            else
            {
                DamagedReceive = DamagedReceive * 2;
            }

            //float damaged = 1.5F * PlayerAttackPower;
            GameObject damagepanel = Button_Click_On_Player.transform.GetChild(1).gameObject;
            damagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
            damagepanel.SetActive(true);
            PlayerPrefs.SetFloat(Button_Click_On_Player.name + "_HPValue", PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
         
            if (PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") <= 0)
            {
                Button_Click_On_Player.GetComponent<Animator>().SetBool("Death", true);
                Destroy(GameObject.Find(Button_Click_On_Player.transform.parent.name), 2f);
                Globalvariable.WinningLosing = true;
                Globalvariable.After_Death_ReSequence += 1;
            }

        }
        if (Name == "ThunderStrom")
        {
            float value = -1;
            float luckValue = 0;
            spawanHero = GameObject.FindGameObjectsWithTag("Player");
            //GameObject Button_Click_On_Player = gameObject.transform.parent.parent.parent.parent.parent.gameObject;
            try
            {
                if (Button_Click_On_Player.GetComponent<PA>().state.ToString() == "waitingforinput")
                {
                    value = Button_Click_On_Player.GetComponent<Callingscriptableobject>().Attribute.ATK;
                    PlayerPrefs.SetFloat(Button_Click_On_Player.name + "_SPValue", PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_SPValue") - Mathf.RoundToInt(50));
                    luckValue = PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_Luk");
                }
            }
            catch (System.Exception)
            {

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
                            PlayerPrefs.SetFloat(spawanHero[i].name + "_SPValue", PlayerPrefs.GetFloat(spawanHero[i].name + "_SPValue") - Mathf.RoundToInt(50));
                            luckValue = PlayerPrefs.GetFloat(spawanHero[i].name + "_Luk");
                        }
                    }
                    catch (System.Exception)
                    {

                    }
                }
            }

            PlayerAttackPower = value;
           
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
            //float damaged = 0.9F * PlayerAttackPower;


            float missvalue = 100 - luckValue;
            if (missvalue > 25)
                missvalue = 25;

            float criticalvalue = (100 - ((luckValue * 20) / 100)) + 1;
            float damaged = 0;
            float randonvalue = Random.Range(1, 100);

            damaged = 0.9F * PlayerAttackPower;
            float MAXDamage = damaged + (damaged * 20) / 100;
            float DamagedReceive = 0;
            DamagedReceive = Mathf.Clamp(DamagedReceive, damaged, MAXDamage);

            if (randonvalue > 0 && randonvalue <= missvalue)
            {
                DamagedReceive = DamagedReceive * 0;
            }
            else if (randonvalue > missvalue && randonvalue < criticalvalue)
            {
                DamagedReceive = DamagedReceive * 1;
            }
            else
            {
                DamagedReceive = DamagedReceive * 2;
            }


            EnemyDefenceValue = PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_DEF");
            for(int i=0;i<spawanHero.Length;i++)
            {
                try
                {
                    if (spawanHero[i].GetComponent<PA>().state.ToString() == "waitingforinput")
                    {

                    }

                }
                catch (System.Exception)
                {                  

                    GameObject damagepanel = spawanHero[i].transform.GetChild(1).gameObject;
                    damagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                    damagepanel.SetActive(true);
                    PlayerPrefs.SetFloat(spawanHero[i].name + "_HPValue", PlayerPrefs.GetFloat(spawanHero[i].name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                    if (PlayerPrefs.GetFloat(spawanHero[i].name + "_HPValue") <= 0)
                    {
                        spawanHero[i].GetComponent<Animator>().SetBool("Death", true);
                        Destroy(GameObject.Find(spawanHero[i].transform.parent.name), 2f);
                        Globalvariable.WinningLosing = true;
                        Globalvariable.After_Death_ReSequence += 1;
                    }

                }
                
            }
            //sp used =50 All
        }
        if (Name == "Strom")
        {
            EnemyDefenceValue = PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_DEF");

            float value = -1;
            float luckValue = 0;
            spawanHero = GameObject.FindGameObjectsWithTag("Player");
            //GameObject Button_Click_On_Player = gameObject.transform.parent.parent.parent.parent.parent.gameObject;
            try
            {
                if (Button_Click_On_Player.GetComponent<PA>().state.ToString() == "waitingforinput")
                {
                    value = Button_Click_On_Player.GetComponent<Callingscriptableobject>().Attribute.ATK;
                    PlayerPrefs.SetFloat(Button_Click_On_Player.name + "_SPValue", PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_SPValue") - Mathf.RoundToInt(50));
                    luckValue = PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_Luk");
                }
            }
            catch (System.Exception)
            {

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
                            PlayerPrefs.SetFloat(spawanHero[i].name + "_SPValue", PlayerPrefs.GetFloat(spawanHero[i].name + "_SPValue") - Mathf.RoundToInt(50));
                            luckValue = PlayerPrefs.GetFloat(spawanHero[i].name + "_Luk");
                        }
                    }
                    catch (System.Exception)
                    {
                    }
                }
            }

            PlayerAttackPower = value;

            
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";


            //sp used =50 all
            //float damaged = 0.8F * PlayerAttackPower;
            float missvalue = 100 - luckValue;
            if (missvalue > 25)
                missvalue = 25;

            float criticalvalue = (100 - ((luckValue * 20) / 100)) + 1;
            float damaged = 0;
            float randonvalue = Random.Range(1, 100);

            damaged = 0.8F * PlayerAttackPower;
            float MAXDamage = damaged + (damaged * 20) / 100;
            float DamagedReceive = 0;
            DamagedReceive = Mathf.Clamp(DamagedReceive, damaged, MAXDamage);

            if (randonvalue > 0 && randonvalue <= missvalue)
            {
                DamagedReceive = DamagedReceive * 0;
            }
            else if (randonvalue > missvalue && randonvalue < criticalvalue)
            {
                DamagedReceive = DamagedReceive * 1;
            }
            else
            {
                DamagedReceive = DamagedReceive * 2;
            }



            for (int i = 0; i < spawanHero.Length; i++)
            {
                try
                {
                    if (spawanHero[i].GetComponent<PA>().state.ToString() == "waitingforinput")
                    {

                    }

                }
                catch (System.Exception)
                {

                    GameObject damagepanel = spawanHero[i].transform.GetChild(1).gameObject;
                    damagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                    damagepanel.SetActive(true);
                    PlayerPrefs.SetFloat(spawanHero[i].name + "_HPValue", PlayerPrefs.GetFloat(spawanHero[i].name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                    if (PlayerPrefs.GetFloat(spawanHero[i].name + "_HPValue") <= 0)
                    {
                        spawanHero[i].GetComponent<Animator>().SetBool("Death", true);
                        Destroy(GameObject.Find(spawanHero[i].transform.parent.name), 2f);
                        Globalvariable.WinningLosing = true;
                        Globalvariable.After_Death_ReSequence += 1;
                    }

                }

            }
        }
        if (Name == "FireBall")
        {
            EnemyDefenceValue = PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_DEF");

            float value = -1;
            float luckValue = 0;
            spawanHero = GameObject.FindGameObjectsWithTag("Player");
            //GameObject Button_Click_On_Player = gameObject.transform.parent.parent.parent.parent.parent.gameObject;
            try
            {
                if (Button_Click_On_Player.GetComponent<PA>().state.ToString() == "waitingforinput")
                {
                    value = Button_Click_On_Player.GetComponent<Callingscriptableobject>().Attribute.ATK;
                    PlayerPrefs.SetFloat(Button_Click_On_Player.name + "_SPValue", PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_SPValue") - Mathf.RoundToInt(20));
                    luckValue = PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_Luk");
                }
            }
            catch (System.Exception)
            {

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
                            PlayerPrefs.SetFloat(spawanHero[i].name + "_SPValue", PlayerPrefs.GetFloat(spawanHero[i].name + "_SPValue") - Mathf.RoundToInt(20));
                            luckValue = PlayerPrefs.GetFloat(spawanHero[i].name + "_Luk");
                        }
                    }
                    catch (System.Exception)
                    {
                    }
                }
            }

            PlayerAttackPower = value;

           
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";


            //sp used =20  Random 4 near enemywhom receive damage
            //float damaged = 0.75F * PlayerAttackPower;
            float missvalue = 100 - luckValue;
            if (missvalue > 25)
                missvalue = 25;

            float criticalvalue = (100 - ((luckValue * 20) / 100)) + 1;
            float damaged = 0;
            float randonvalue = Random.Range(1, 100);

            damaged = 0.75F * PlayerAttackPower;
            float MAXDamage = damaged + (damaged * 20) / 100;
            float DamagedReceive = 0;
            DamagedReceive = Mathf.Clamp(DamagedReceive, damaged, MAXDamage);

            if (randonvalue > 0 && randonvalue <= missvalue)
            {
                DamagedReceive = DamagedReceive * 0;
            }
            else if (randonvalue > missvalue && randonvalue < criticalvalue)
            {
                DamagedReceive = DamagedReceive * 1;
            }
            else
            {
                DamagedReceive = DamagedReceive * 2;
            }

            //random action ...
            //1,2,3,4
            //2,1,5
            //3,1,6
            //4,1,5,6
            //5,2,4
            //6,3,4

            //
            GameObject damagepanel = Button_Click_On_Player.transform.GetChild(1).gameObject;
            damagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
            damagepanel.SetActive(true);
            PlayerPrefs.SetFloat(Button_Click_On_Player.name + "_HPValue", PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
            if (PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") <= 0)
            {
                Button_Click_On_Player.GetComponent<Animator>().SetBool("Death", true);
                Destroy(GameObject.Find(Button_Click_On_Player.transform.parent.name), 2f);
                Globalvariable.WinningLosing = true;
                Globalvariable.After_Death_ReSequence += 1;
            }
        }
        if (Name == "FireBlast")
        {
            EnemyDefenceValue = PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_DEF");

            float value = -1;
            float luckValue = 0;
            spawanHero = GameObject.FindGameObjectsWithTag("Player");
            //GameObject Button_Click_On_Player = gameObject.transform.parent.parent.parent.parent.parent.gameObject;
            try
            {
                if (Button_Click_On_Player.GetComponent<PA>().state.ToString() == "waitingforinput")
                {
                    value = Button_Click_On_Player.GetComponent<Callingscriptableobject>().Attribute.ATK;
                    PlayerPrefs.SetFloat(Button_Click_On_Player.name + "_SPValue", PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_SPValue") - Mathf.RoundToInt(50));
                    luckValue = PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_Luk");
                }
            }
            catch (System.Exception)
            {

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
                            PlayerPrefs.SetFloat(spawanHero[i].name + "_SPValue", PlayerPrefs.GetFloat(spawanHero[i].name + "_SPValue") - Mathf.RoundToInt(50));
                            luckValue = PlayerPrefs.GetFloat(spawanHero[i].name + "_Luk");
                        }
                    }
                    catch (System.Exception)
                    {
                    }
                }
            }

            PlayerAttackPower = value;

           
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";

            //sp used =50 All
            //float damaged = 0.75F * PlayerAttackPower;

            float missvalue = 100 - luckValue;
            if (missvalue > 25)
                missvalue = 25;

            float criticalvalue = (100 - ((luckValue * 20) / 100)) + 1;
            float damaged = 0;
            float randonvalue = Random.Range(1, 100);

            damaged = 0.75F * PlayerAttackPower;
            float MAXDamage = damaged + (damaged * 20) / 100;
            float DamagedReceive = 0;
            DamagedReceive = Mathf.Clamp(DamagedReceive, damaged, MAXDamage);

            if (randonvalue > 0 && randonvalue <= missvalue)
            {
                DamagedReceive = DamagedReceive * 0;
            }
            else if (randonvalue > missvalue && randonvalue < criticalvalue)
            {
                DamagedReceive = DamagedReceive * 1;
            }
            else
            {
                DamagedReceive = DamagedReceive * 2;
            }



            for (int i = 0; i < spawanHero.Length; i++)
            {
                try
                {
                    if (spawanHero[i].GetComponent<PA>().state.ToString() == "waitingforinput")
                    {

                    }

                }
                catch (System.Exception)
                {

                    GameObject damagepanel = spawanHero[i].transform.GetChild(1).gameObject;
                    damagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                    damagepanel.SetActive(true);
                    PlayerPrefs.SetFloat(spawanHero[i].name + "_HPValue", PlayerPrefs.GetFloat(spawanHero[i].name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                    if (PlayerPrefs.GetFloat(spawanHero[i].name + "_HPValue") <= 0)
                    {
                        spawanHero[i].GetComponent<Animator>().SetBool("Death", true);
                        Destroy(GameObject.Find(spawanHero[i].transform.parent.name), 2f);
                        Globalvariable.WinningLosing = true;
                        Globalvariable.After_Death_ReSequence += 1;
                    }

                }

            }
        }
        if (Name == "Wind")
        {
            EnemyDefenceValue = PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_DEF");

            float value = -1;
            float luckValue = 0;
            spawanHero = GameObject.FindGameObjectsWithTag("Player");
            //GameObject Button_Click_On_Player = gameObject.transform.parent.parent.parent.parent.parent.gameObject;
            try
            {
                if (Button_Click_On_Player.GetComponent<PA>().state.ToString() == "waitingforinput")
                {
                    value = Button_Click_On_Player.GetComponent<Callingscriptableobject>().Attribute.ATK;
                    PlayerPrefs.SetFloat(Button_Click_On_Player.name + "_SPValue", PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_SPValue") - Mathf.RoundToInt( 30));
                    luckValue = PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_Luk");
                }
            }
            catch (System.Exception)
            {

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
                            PlayerPrefs.SetFloat(spawanHero[i].name + "_SPValue", PlayerPrefs.GetFloat(spawanHero[i].name + "_SPValue") - Mathf.RoundToInt(30));
                            luckValue = PlayerPrefs.GetFloat(spawanHero[i].name + "_Luk");
                        }
                    }
                    catch (System.Exception)
                    {
                    }
                }
            }

            PlayerAttackPower = value;

           
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";

            //sp used =30 One row of enemy

            //float damaged = 1F * PlayerAttackPower;
            float missvalue = 100 - luckValue;
            if (missvalue > 25)
                missvalue = 25;

            float criticalvalue = (100 - ((luckValue * 20) / 100)) + 1;
            float damaged = 0;
            float randonvalue = Random.Range(1, 100);

            damaged = 1F * PlayerAttackPower;
            float MAXDamage = damaged + (damaged * 20) / 100;
            float DamagedReceive = 0;
            DamagedReceive = Mathf.Clamp(DamagedReceive, damaged, MAXDamage);

            if (randonvalue > 0 && randonvalue <= missvalue)
            {
                DamagedReceive = DamagedReceive * 0;
            }
            else if (randonvalue > missvalue && randonvalue < criticalvalue)
            {
                DamagedReceive = DamagedReceive * 1;
            }
            else
            {
                DamagedReceive = DamagedReceive * 2;
            }


            //hit enemy rows wise.....


            GameObject Parent = Button_Click_On_Player.transform.parent.gameObject;
            #region middle row
            if (Parent.name == "Position1")
            {
                GameObject damagepanel = Button_Click_On_Player.transform.GetChild(1).gameObject;
                damagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                damagepanel.SetActive(true);
                PlayerPrefs.SetFloat(Button_Click_On_Player.name + "_HPValue", PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                if (PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") <= 0)
                {
                    Button_Click_On_Player.GetComponent<Animator>().SetBool("Death", true);
                    Destroy(GameObject.Find(Button_Click_On_Player.transform.parent.name), 2f);
                    Globalvariable.WinningLosing = true;
                    Globalvariable.After_Death_ReSequence += 1;
                }

                GameObject secondplayer = GameObject.Find("Position4");
                if (secondplayer!=null)
                {
                    GameObject sdamagepanel = secondplayer.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                    sdamagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                    sdamagepanel.SetActive(true);
                    PlayerPrefs.SetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue", PlayerPrefs.GetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                    if (PlayerPrefs.GetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue") <= 0)
                    {
                        secondplayer.transform.GetChild(0).GetComponent<Animator>().SetBool("Death", true);
                        Destroy(GameObject.Find(secondplayer.gameObject.name), 2f);
                        Globalvariable.WinningLosing = true;
                        Globalvariable.After_Death_ReSequence += 1;
                    }
                }
            }
            if (Parent.name == "Position4")
            {
                GameObject damagepanel = Button_Click_On_Player.transform.GetChild(1).gameObject;
                damagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                damagepanel.SetActive(true);
                PlayerPrefs.SetFloat(Button_Click_On_Player.name + "_HPValue", PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                if (PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") <= 0)
                {
                    Button_Click_On_Player.GetComponent<Animator>().SetBool("Death", true);
                    Destroy(GameObject.Find(Button_Click_On_Player.transform.parent.name), 2f);
                    Globalvariable.WinningLosing = true;
                    Globalvariable.After_Death_ReSequence += 1;
                }

                GameObject secondplayer = GameObject.Find("Position1");
                if(secondplayer != null)
                {
                    GameObject sdamagepanel = secondplayer.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                    sdamagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                    sdamagepanel.SetActive(true);
                    PlayerPrefs.SetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue", PlayerPrefs.GetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                    if (PlayerPrefs.GetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue") <= 0)
                    {
                        secondplayer.transform.GetChild(0).GetComponent<Animator>().SetBool("Death", true);
                        Destroy(GameObject.Find(secondplayer.gameObject.name), 2f);
                        Globalvariable.WinningLosing = true;
                        Globalvariable.After_Death_ReSequence += 1;
                    }
                }
               
            }
            #endregion
            #region topRow
            if (Parent.name == "Position2")
            {
                GameObject damagepanel = Button_Click_On_Player.transform.GetChild(1).gameObject;
                damagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                damagepanel.SetActive(true);
                PlayerPrefs.SetFloat(Button_Click_On_Player.name + "_HPValue", PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                if (PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") <= 0)
                {
                    Button_Click_On_Player.GetComponent<Animator>().SetBool("Death", true);
                    Destroy(GameObject.Find(Button_Click_On_Player.transform.parent.name), 2f);
                    Globalvariable.WinningLosing = true;
                    Globalvariable.After_Death_ReSequence += 1;
                }

                GameObject secondplayer = GameObject.Find("Position5");
                if (secondplayer != null)
                {
                    GameObject sdamagepanel = secondplayer.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                    sdamagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                    sdamagepanel.SetActive(true);
                    PlayerPrefs.SetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue", PlayerPrefs.GetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                    if (PlayerPrefs.GetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue") <= 0)
                    {
                        secondplayer.transform.GetChild(0).GetComponent<Animator>().SetBool("Death", true);
                        Destroy(GameObject.Find(secondplayer.gameObject.name), 2f);
                        Globalvariable.WinningLosing = true;
                        Globalvariable.After_Death_ReSequence += 1;
                    }
                }
            }
            if (Parent.name == "Position5")
            {
                GameObject damagepanel = Button_Click_On_Player.transform.GetChild(1).gameObject;
                damagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                damagepanel.SetActive(true);
                PlayerPrefs.SetFloat(Button_Click_On_Player.name + "_HPValue", PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                if (PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") <= 0)
                {
                    Button_Click_On_Player.GetComponent<Animator>().SetBool("Death", true);
                    Destroy(GameObject.Find(Button_Click_On_Player.transform.parent.name), 2f);
                    Globalvariable.WinningLosing = true;
                    Globalvariable.After_Death_ReSequence += 1;
                }

                GameObject secondplayer = GameObject.Find("Position2");
                if (secondplayer != null)
                {
                    GameObject sdamagepanel = secondplayer.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                    sdamagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                    sdamagepanel.SetActive(true);
                    PlayerPrefs.SetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue", PlayerPrefs.GetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                    if (PlayerPrefs.GetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue") <= 0)
                    {
                        secondplayer.transform.GetChild(0).GetComponent<Animator>().SetBool("Death", true);
                        Destroy(GameObject.Find(secondplayer.gameObject.name), 2f);
                        Globalvariable.WinningLosing = true;
                        Globalvariable.After_Death_ReSequence += 1;
                    }
                }
            }
            #endregion
            #region bottomRow
            if (Parent.name == "Position3")
            {
                GameObject damagepanel = Button_Click_On_Player.transform.GetChild(1).gameObject;
                damagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                damagepanel.SetActive(true);
                PlayerPrefs.SetFloat(Button_Click_On_Player.name + "_HPValue", PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                if (PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") <= 0)
                {
                    Button_Click_On_Player.GetComponent<Animator>().SetBool("Death", true);
                    Destroy(GameObject.Find(Button_Click_On_Player.transform.parent.name), 2f);
                    Globalvariable.WinningLosing = true;
                    Globalvariable.After_Death_ReSequence += 1;
                }

                GameObject secondplayer = GameObject.Find("Position6");
                if (secondplayer != null)
                {
                    GameObject sdamagepanel = secondplayer.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                    sdamagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                    sdamagepanel.SetActive(true);
                    PlayerPrefs.SetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue", PlayerPrefs.GetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                    if (PlayerPrefs.GetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue") <= 0)
                    {
                        secondplayer.transform.GetChild(0).GetComponent<Animator>().SetBool("Death", true);
                        Destroy(GameObject.Find(secondplayer.gameObject.name), 2f);
                        Globalvariable.WinningLosing = true;
                        Globalvariable.After_Death_ReSequence += 1;
                    }
                }
            }
            if (Parent.name == "Position6")
            {
                GameObject damagepanel = Button_Click_On_Player.transform.GetChild(1).gameObject;
                damagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                damagepanel.SetActive(true);
                PlayerPrefs.SetFloat(Button_Click_On_Player.name + "_HPValue", PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                if (PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") <= 0)
                {
                    Button_Click_On_Player.GetComponent<Animator>().SetBool("Death", true);
                    Destroy(GameObject.Find(Button_Click_On_Player.transform.parent.name), 2f);
                    Globalvariable.WinningLosing = true;
                    Globalvariable.After_Death_ReSequence += 1;
                }

                GameObject secondplayer = GameObject.Find("Position3");
                if (secondplayer != null)
                {
                    GameObject sdamagepanel = secondplayer.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                    sdamagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                    sdamagepanel.SetActive(true);
                    PlayerPrefs.SetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue", PlayerPrefs.GetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                    if (PlayerPrefs.GetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue") <= 0)
                    {
                        secondplayer.transform.GetChild(0).GetComponent<Animator>().SetBool("Death", true);
                        Destroy(GameObject.Find(secondplayer.gameObject.name), 2f);
                        Globalvariable.WinningLosing = true;
                        Globalvariable.After_Death_ReSequence += 1;
                    }
                }
            }
            #endregion
        }
        if (Name == "QuickSand")
        {
            EnemyDefenceValue = PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_DEF");

            float value = -1;
            float luckValue = 0;
            spawanHero = GameObject.FindGameObjectsWithTag("Player");
            //GameObject Button_Click_On_Player = gameObject.transform.parent.parent.parent.parent.parent.gameObject;
            try
            {
                if (Button_Click_On_Player.GetComponent<PA>().state.ToString() == "waitingforinput")
                {
                    value = Button_Click_On_Player.GetComponent<Callingscriptableobject>().Attribute.ATK;
                    PlayerPrefs.SetFloat(Button_Click_On_Player.name + "_SPValue", PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_SPValue") - Mathf.RoundToInt(30));
                    luckValue = PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_Luk");
                }
            }
            catch (System.Exception)
            {

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
                            PlayerPrefs.SetFloat(spawanHero[i].name + "_SPValue", PlayerPrefs.GetFloat(spawanHero[i].name + "_SPValue") - Mathf.RoundToInt(30));
                            luckValue = PlayerPrefs.GetFloat(spawanHero[i].name + "_Luk");
                        }
                    }
                    catch (System.Exception)
                    {
                    }
                }
            }

            PlayerAttackPower = value;

           
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";

            //sp used =30 front Enemy

            //float damaged = 0.75F * PlayerAttackPower;
            float missvalue = 100 - luckValue;
            if (missvalue > 25)
                missvalue = 25;

            float criticalvalue = (100 - ((luckValue * 20) / 100)) + 1;
            float damaged = 0;
            float randonvalue = Random.Range(1, 100);

            damaged =0.75F * PlayerAttackPower;
            float MAXDamage = damaged + (damaged * 20) / 100;
            float DamagedReceive = 0;
            DamagedReceive = Mathf.Clamp(DamagedReceive, damaged, MAXDamage);

            if (randonvalue > 0 && randonvalue <= missvalue)
            {
                DamagedReceive = DamagedReceive * 0;
            }
            else if (randonvalue > missvalue && randonvalue < criticalvalue)
            {
                DamagedReceive = DamagedReceive * 1;
            }
            else
            {
                DamagedReceive = DamagedReceive * 2;
            }

            GameObject Parent = Button_Click_On_Player.transform.parent.gameObject;

            if (Parent.name == "Position1" )
            {
                GameObject damagepanel = Button_Click_On_Player.transform.GetChild(1).gameObject;
                damagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                damagepanel.SetActive(true);
                PlayerPrefs.SetFloat(Button_Click_On_Player.name + "_HPValue", PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                if (PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") <= 0)
                {
                    Button_Click_On_Player.GetComponent<Animator>().SetBool("Death", true);
                    Destroy(GameObject.Find(Button_Click_On_Player.transform.parent.name), 2f);
                    Globalvariable.WinningLosing = true;
                    Globalvariable.After_Death_ReSequence += 1;
                }

                GameObject secondplayer = GameObject.Find("Position2");
                if (secondplayer != null)
                {
                    GameObject sdamagepanel = secondplayer.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                    sdamagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                    sdamagepanel.SetActive(true);
                    PlayerPrefs.SetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue", PlayerPrefs.GetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                    if (PlayerPrefs.GetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue") <= 0)
                    {
                        secondplayer.transform.GetChild(0).GetComponent<Animator>().SetBool("Death", true);
                        Destroy(GameObject.Find(secondplayer.gameObject.name), 2f);
                        Globalvariable.WinningLosing = true;
                        Globalvariable.After_Death_ReSequence += 1;
                    }
                }
                GameObject thirdplayer = GameObject.Find("Position3");
                if (thirdplayer != null)
                {
                    GameObject thdamagepanel = thirdplayer.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                    thdamagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                    thdamagepanel.SetActive(true);
                    PlayerPrefs.SetFloat(thirdplayer.transform.GetChild(0).gameObject.name + "_HPValue", PlayerPrefs.GetFloat(thirdplayer.transform.GetChild(0).gameObject.name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                    if (PlayerPrefs.GetFloat(thirdplayer.transform.GetChild(0).gameObject.name + "_HPValue") <= 0)
                    {
                        thirdplayer.transform.GetChild(0).GetComponent<Animator>().SetBool("Death", true);
                        Destroy(GameObject.Find(thirdplayer.gameObject.name), 2f);
                        Globalvariable.WinningLosing = true;
                        Globalvariable.After_Death_ReSequence += 1;
                    }
                }
            }
            else if(Parent.name == "Position2")
            {
                GameObject damagepanel = Button_Click_On_Player.transform.GetChild(1).gameObject;
                damagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                damagepanel.SetActive(true);
                PlayerPrefs.SetFloat(Button_Click_On_Player.name + "_HPValue", PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                if (PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") <= 0)
                {
                    Button_Click_On_Player.GetComponent<Animator>().SetBool("Death", true);
                    Destroy(GameObject.Find(Button_Click_On_Player.transform.parent.name), 2f);
                    Globalvariable.WinningLosing = true;
                    Globalvariable.After_Death_ReSequence += 1;
                }

                GameObject secondplayer = GameObject.Find("Position1");
                if (secondplayer != null)
                {
                    GameObject sdamagepanel = secondplayer.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                    sdamagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                    sdamagepanel.SetActive(true);
                    PlayerPrefs.SetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue", PlayerPrefs.GetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                    if (PlayerPrefs.GetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue") <= 0)
                    {
                        secondplayer.transform.GetChild(0).GetComponent<Animator>().SetBool("Death", true);
                        Destroy(GameObject.Find(secondplayer.gameObject.name), 2f);
                        Globalvariable.WinningLosing = true;
                        Globalvariable.After_Death_ReSequence += 1;
                    }
                }
                GameObject thirdplayer = GameObject.Find("Position3");
                if (thirdplayer != null)
                {
                    GameObject thdamagepanel = thirdplayer.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                    thdamagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                    thdamagepanel.SetActive(true);
                    PlayerPrefs.SetFloat(thirdplayer.transform.GetChild(0).gameObject.name + "_HPValue", PlayerPrefs.GetFloat(thirdplayer.transform.GetChild(0).gameObject.name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                    if (PlayerPrefs.GetFloat(thirdplayer.transform.GetChild(0).gameObject.name + "_HPValue") <= 0)
                    {
                        thirdplayer.transform.GetChild(0).GetComponent<Animator>().SetBool("Death", true);
                        Destroy(GameObject.Find(thirdplayer.gameObject.name), 2f);
                        Globalvariable.WinningLosing = true;
                        Globalvariable.After_Death_ReSequence += 1;
                    }
                }
            }
            else if(Parent.name == "Position3")
            {
                GameObject damagepanel = Button_Click_On_Player.transform.GetChild(1).gameObject;
                damagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                damagepanel.SetActive(true);
                PlayerPrefs.SetFloat(Button_Click_On_Player.name + "_HPValue", PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                if (PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") <= 0)
                {
                    Button_Click_On_Player.GetComponent<Animator>().SetBool("Death", true);
                    Destroy(GameObject.Find(Button_Click_On_Player.transform.parent.name), 2f);
                    Globalvariable.WinningLosing = true;
                    Globalvariable.After_Death_ReSequence += 1;
                }

                GameObject secondplayer = GameObject.Find("Position1");
                if (secondplayer != null)
                {
                    GameObject sdamagepanel = secondplayer.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                    sdamagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                    sdamagepanel.SetActive(true);
                    PlayerPrefs.SetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue", PlayerPrefs.GetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                    if (PlayerPrefs.GetFloat(secondplayer.transform.GetChild(0).gameObject.name + "_HPValue") <= 0)
                    {
                        secondplayer.transform.GetChild(0).GetComponent<Animator>().SetBool("Death", true);
                        Destroy(GameObject.Find(secondplayer.gameObject.name), 2f);
                        Globalvariable.WinningLosing = true;
                        Globalvariable.After_Death_ReSequence += 1;
                    }
                }
                GameObject thirdplayer = GameObject.Find("Position2");
                if (thirdplayer != null)
                {
                    GameObject thdamagepanel = thirdplayer.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
                    thdamagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                    thdamagepanel.SetActive(true);
                    PlayerPrefs.SetFloat(thirdplayer.transform.GetChild(0).gameObject.name + "_HPValue", PlayerPrefs.GetFloat(thirdplayer.transform.GetChild(0).gameObject.name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                    if (PlayerPrefs.GetFloat(thirdplayer.transform.GetChild(0).gameObject.name + "_HPValue") <= 0)
                    {
                        thirdplayer.transform.GetChild(0).GetComponent<Animator>().SetBool("Death", true);
                        Destroy(GameObject.Find(thirdplayer.gameObject.name), 2f);
                        Globalvariable.WinningLosing = true;
                        Globalvariable.After_Death_ReSequence += 1;
                    }
                }
            }
            else
            {
                GameObject damagepanel = Button_Click_On_Player.transform.GetChild(1).gameObject;
                damagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                damagepanel.SetActive(true);
                PlayerPrefs.SetFloat(Button_Click_On_Player.name + "_HPValue", PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                if (PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_HPValue") <= 0)
                {
                    Button_Click_On_Player.GetComponent<Animator>().SetBool("Death", true);
                    Destroy(GameObject.Find(Button_Click_On_Player.transform.parent.name), 2f);
                    Globalvariable.WinningLosing = true;
                    Globalvariable.After_Death_ReSequence += 1;
                }
            }

            
        }
        if (Name == "EarthQuake")
        {
            EnemyDefenceValue = PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_DEF");

            float value = -1;
            float luckValue = 0;
            spawanHero = GameObject.FindGameObjectsWithTag("Player");
            //GameObject Button_Click_On_Player = gameObject.transform.parent.parent.parent.parent.parent.gameObject;
            try
            {
                if (Button_Click_On_Player.GetComponent<PA>().state.ToString() == "waitingforinput")
                {
                    value = Button_Click_On_Player.GetComponent<Callingscriptableobject>().Attribute.ATK;
                    PlayerPrefs.SetFloat(Button_Click_On_Player.name + "_SPValue", PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_SPValue") - Mathf.RoundToInt(60));
                    luckValue = PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_Luk");
                }
            }
            catch (System.Exception)
            {

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
                            PlayerPrefs.SetFloat(spawanHero[i].name + "_SPValue", PlayerPrefs.GetFloat(spawanHero[i].name + "_SPValue") - Mathf.RoundToInt(30));
                            luckValue = PlayerPrefs.GetFloat(spawanHero[i].name + "_Luk");
                        }
                    }
                    catch (System.Exception)
                    {
                    }
                }
            }

            PlayerAttackPower = value;

            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";

            //sp used =60  used in All Enemy
            //float damaged = 1.25F * PlayerAttackPower;

            float missvalue = 100 - luckValue;
            if (missvalue > 25)
                missvalue = 25;

            float criticalvalue = (100 - ((luckValue * 20) / 100)) + 1;
            float damaged = 0;
            float randonvalue = Random.Range(1, 100);

            damaged = 1.25F * PlayerAttackPower;
            float MAXDamage = damaged + (damaged * 20) / 100;
            float DamagedReceive = 0;
            DamagedReceive = Mathf.Clamp(DamagedReceive, damaged, MAXDamage);

            if (randonvalue > 0 && randonvalue <= missvalue)
            {
                DamagedReceive = DamagedReceive * 0;
            }
            else if (randonvalue > missvalue && randonvalue < criticalvalue)
            {
                DamagedReceive = DamagedReceive * 1;
            }
            else
            {
                DamagedReceive = DamagedReceive * 2;
            }

            for (int i = 0; i < spawanHero.Length; i++)
            {
                try
                {
                    if (spawanHero[i].GetComponent<PA>().state.ToString() == "waitingforinput")
                    {

                    }

                }
                catch (System.Exception)
                {

                    GameObject damagepanel = spawanHero[i].transform.GetChild(1).gameObject;
                    damagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                    damagepanel.SetActive(true);
                    PlayerPrefs.SetFloat(spawanHero[i].name + "_HPValue", PlayerPrefs.GetFloat(spawanHero[i].name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                    if (PlayerPrefs.GetFloat(spawanHero[i].name + "_HPValue") <= 0)
                    {
                        spawanHero[i].GetComponent<Animator>().SetBool("Death", true);
                        Destroy(GameObject.Find(spawanHero[i].transform.parent.name), 2f);
                        Globalvariable.WinningLosing = true;
                        Globalvariable.After_Death_ReSequence += 1;
                    }

                }

            }
        }
        if (Name == "HeavenlyWorth")
        {
            EnemyDefenceValue = PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_DEF");

            float value = -1; float luckValue = 0;
            spawanHero = GameObject.FindGameObjectsWithTag("Player");
            //GameObject Button_Click_On_Player = gameObject.transform.parent.parent.parent.parent.parent.gameObject;
            try
            {
                if (Button_Click_On_Player.GetComponent<PA>().state.ToString() == "waitingforinput")
                {
                    value = Button_Click_On_Player.GetComponent<Callingscriptableobject>().Attribute.ATK;
                    PlayerPrefs.SetFloat(Button_Click_On_Player.name + "_SPValue", PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_SPValue") - Mathf.RoundToInt(70));
                    luckValue = PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_Luk");
                }
            }
            catch (System.Exception)
            {

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
                            PlayerPrefs.SetFloat(spawanHero[i].name + "_SPValue", PlayerPrefs.GetFloat(spawanHero[i].name + "_SPValue") - Mathf.RoundToInt(70));
                            luckValue = PlayerPrefs.GetFloat(spawanHero[i].name + "_Luk");
                        }
                    }
                    catch (System.Exception)
                    {
                    }
                }
            }

            PlayerAttackPower = value;


            //Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";

            //sp used =70  used in All Enemy
            //float damaged = 1.25F * PlayerAttackPower;
            float missvalue = 100 - luckValue;
            if (missvalue > 25)
                missvalue = 25;

            float criticalvalue = (100 - ((luckValue * 20) / 100)) + 1;
            float damaged = 0;
            float randonvalue = Random.Range(1, 100);

            damaged = 1.25F * PlayerAttackPower;
            float MAXDamage = damaged + (damaged * 20) / 100;
            float DamagedReceive = 0;
            DamagedReceive = Mathf.Clamp(DamagedReceive, damaged, MAXDamage);

            if (randonvalue > 0 && randonvalue <= missvalue)
            {
                DamagedReceive = DamagedReceive * 0;
            }
            else if (randonvalue > missvalue && randonvalue < criticalvalue)
            {
                DamagedReceive = DamagedReceive * 1;
            }
            else
            {
                DamagedReceive = DamagedReceive * 2;
            }

            for (int i = 0; i < spawanHero.Length; i++)
            {
                try
                {
                    if (spawanHero[i].GetComponent<PA>().state.ToString() == "waitingforinput")
                    {

                    }

                }
                catch (System.Exception)
                {

                    GameObject damagepanel = spawanHero[i].transform.GetChild(1).gameObject;
                    damagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(DamagedReceive).ToString();
                    damagepanel.SetActive(true);
                    PlayerPrefs.SetFloat(spawanHero[i].name + "_HPValue", PlayerPrefs.GetFloat(spawanHero[i].name + "_HPValue") - Mathf.RoundToInt(DamagedReceive));
                    if (PlayerPrefs.GetFloat(spawanHero[i].name + "_HPValue") <= 0)
                    {
                        spawanHero[i].GetComponent<Animator>().SetBool("Death", true);
                        Destroy(GameObject.Find(spawanHero[i].transform.parent.name), 2f);
                        Globalvariable.WinningLosing = true;
                        Globalvariable.After_Death_ReSequence += 1;
                    }

                }

            }
        }

        if (Name == "LightBoom")
        {
            EnemyDefenceValue = PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_DEF");

            float value = -1;
            spawanHero = GameObject.FindGameObjectsWithTag("Player");
            //GameObject Button_Click_On_Player = gameObject.transform.parent.parent.parent.parent.parent.gameObject;
            try
            {
                if (Button_Click_On_Player.GetComponent<PA>().state.ToString() == "waitingforinput")
                {
                    value = Button_Click_On_Player.GetComponent<Callingscriptableobject>().Attribute.ATK;

                }
            }
            catch (System.Exception)
            {

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
                    }
                }
            }

            PlayerAttackPower = value;

            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
        if (Name == "AirAttack")
        {
            EnemyDefenceValue = PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_DEF");

            float value = -1;
            spawanHero = GameObject.FindGameObjectsWithTag("Player");
            //GameObject Button_Click_On_Player = gameObject.transform.parent.parent.parent.parent.parent.gameObject;
            try
            {
                if (Button_Click_On_Player.GetComponent<PA>().state.ToString() == "waitingforinput")
                {
                    value = Button_Click_On_Player.GetComponent<Callingscriptableobject>().Attribute.ATK;

                }
            }
            catch (System.Exception)
            {

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
                    }
                }
            }

            PlayerAttackPower = value;


            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }       
        if (Name == "Inferno")
        {
            EnemyDefenceValue = PlayerPrefs.GetFloat(Button_Click_On_Player.name + "_DEF");
            float value = -1;
            spawanHero = GameObject.FindGameObjectsWithTag("Player");
            //GameObject Button_Click_On_Player = gameObject.transform.parent.parent.parent.parent.parent.gameObject;
            try
            {
                if (Button_Click_On_Player.GetComponent<PA>().state.ToString() == "waitingforinput")
                {
                    value = Button_Click_On_Player.GetComponent<Callingscriptableobject>().Attribute.ATK;

                }
            }
            catch (System.Exception)
            {

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
                    }
                }
            }

            PlayerAttackPower = value;


            Globalvariable.After_Death_ReSequence += 1;
            Globalvariable.Active_Player_Action = true;
            Globalvariable.Active_Player_Animation_Parameter = "punch";
        }
      
       
      
    }    
    
}
