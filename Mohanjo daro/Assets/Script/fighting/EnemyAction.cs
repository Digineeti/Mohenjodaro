﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyAction : MonoBehaviour
{
    #region variable
    public GameObject Light;
    public GameObject TurnUiPanel;
    [HideInInspector]
    public bool PlayerState = false;

    public GameObject ActiveCircle;
    private Animator anim;
    bool action = true;

    float currentTime;
    float NextTime;
    bool damage;

    public ActionList AL;
    //public GameObject []PlayerList;
    private GameObject[] Heros;
    internal string ActionName;
    GameObject damagepanel;
    int Hiton;
    public State state;
    public enum State
    {
        Action,
        busy,
        //Death,

    }

    public TurnState Turnstate;
    public enum TurnState
    {
        Turnover,
        NextTurn,
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        state = State.busy;
        ActiveCircle.SetActive(false);
        anim = GetComponent<Animator>();
        //
        Turnstate = TurnState.NextTurn;
    }

    // Update is called once per frame
    void Update()
    {
        //set PlayerUI healthbar active by default
        //if (Globalvariable.PlayerUi == true)
        //{
        //    //playerUi stat disable
        //    PlayerUIPanel.SetActive(true);
        //}
        //else
        //{
        //    //healthbar disable
        //    PlayerUIPanel.SetActive(false);
        //}

        if (Globalvariable.turnUi == true)
        {
            TurnUiPanel.SetActive(true);
        }
        else
        {
            TurnUiPanel.SetActive(false);
        }
        //enemy animation after the player animation over
        //if (Globalvariable.Active_Player_Animation_Parameter == null)
        //{
            if (state == State.Action)
            {

                Globalvariable.currentTime += Time.deltaTime;
                //set the trun only if enemy has the positive health value ...
                if (PlayerPrefs.GetFloat(gameObject.name + "_HPValue") > 0)
                {
                    if (action == true)
                    {
                        Globalvariable.nextTime = Globalvariable.currentTime + 1f;
                        damage_Calculation();
                        action = false;
                        anim.SetBool("Punch", true);
                        //Globalvariable.After_Death_ReSequence += 1;
                    }
                    ActiveCircle.SetActive(true);
                    Light.SetActive(true);
                    //damagepanel.SetActive(true);
                    if (Globalvariable.currentTime > Globalvariable.nextTime)
                    {
                        action = true;
                        //damagepanel.SetActive(false);
                        Globalvariable.Index = 0;
                        state = State.busy;
                        Turnstate = TurnState.Turnover;
                        anim.SetBool("Happy", false);
                        anim.SetBool("Punch", false);
                    }
                }

            }
            else
            {

                ActiveCircle.SetActive(false);
                currentTime += Time.deltaTime;
                if (Globalvariable.Effect_On_Enemy == true) //(damage == true)
                {
                    if (gameObject.transform.GetChild(1).gameObject.activeSelf == true)
                    {
                        NextTime = currentTime + 1f;
                        Globalvariable.Effect_On_Enemy = false; damage = true;
                        anim.SetBool(Globalvariable.Effect_Animation_On_Enemy, true);
                    }
                }
                if (damage == true && currentTime > NextTime)
                {
                    damage = false;
                    gameObject.transform.GetChild(1).gameObject.SetActive(false);
                    anim.SetBool(Globalvariable.Effect_Animation_On_Enemy, false);
                    Globalvariable.Effect_Animation_On_Enemy = null;


                }

                if (Globalvariable.All_Enemy_Hoverbutton == false)
                    Light.SetActive(false);
            }
          

        //}

    }

    public void damage_Calculation()
    {
        //Heros[0]= GameObject.Find("Agni");
        //Heros[1]= GameObject.Find("Dyaus");
        //Heros[2]= GameObject.Find("Indra");
        //Heros[3]= GameObject.Find("Prithvi");
        //Heros[4]= GameObject.Find("Sachi");
        //Heros[5]= GameObject.Find("Vayu");
        Heros = GameObject.FindGameObjectsWithTag("Player");
        List<GameObject> PlayerList = new List<GameObject>();
        float damaged = 0;
        int Action = Random.Range(0, AL.EnemyActionsList.Length);
        GameObject[] Active_Player_List = new GameObject[6];
        for (int i = 0; i < Heros.Length; i++)
        {
            try
            {
                if (Heros[i].GetComponent<PA>().DeathPlayer.ToString() == "Active")
                {
                    PlayerList.Add(Heros[i]);
                }
            }
            catch (System.Exception)
            {

            }

        }
        Heros = null;
        Heros = PlayerList.ToArray();

        ActionName = AL.EnemyActionsList[Action];
        //step:
        int Hiton = Random.Range(0, Heros.Length);
        try
        {

            //if the player is death then enemy attack miss... else hit...and make damaged
            //its comes form playerpref save date value...
            //float EnemyAttackValue = gameObject.GetComponent<En_Callingscriptableobject>().Attribute.ATK;
            //float PlayerDefenceValue = Heros[Hiton].GetComponent<Callingscriptableobject>().Attribute.DEF;
            if (PlayerPrefs.HasKey(Heros[Hiton].name + "Protect_Player"))
            {
                string protector_Name = PlayerPrefs.GetString(Heros[Hiton].name + "Protect_Player");
                int value = 0;
                for (int i = 0; i < Heros.Length; i++)
                {
                    if (Heros[i].name == protector_Name)
                    {
                        value = i;
                    }
                }
                float EnemyAttackValue = PlayerPrefs.GetFloat(gameObject.name + "_ATK");
                float PlayerDefenceValue = PlayerPrefs.GetFloat(Heros[value].name + "_DEF");
                //Debug.Log("player defence before boost=" + PlayerDefenceValue);
                //Debug.Log("player defence before boost damage=" + ((4 * EnemyAttackValue) - (2 * PlayerDefenceValue)));

                if (PlayerPrefs.HasKey(Heros[value].name + "Defence_Boost"))
                {
                    float Action_Defence_Value = PlayerPrefs.GetFloat(Heros[value].name + "Defence_Boost");
                    PlayerDefenceValue += Action_Defence_Value;
                    PlayerPrefs.DeleteKey(Heros[value].name + "Defence_Boost");
                    Debug.Log("player defence after boost=" + PlayerDefenceValue);
                }
                //damage will be depend on the diffrent action that enemy perform
                damaged = Mathf.Abs((4 * EnemyAttackValue) - (2 * PlayerDefenceValue));
                //Debug.Log("player defence after boost damage=" + ((4 * EnemyAttackValue) - (2 * PlayerDefenceValue)));
                for (int i = 0; i < Heros.Length; i++)
                {
                    Heros[i].transform.GetChild(1).gameObject.SetActive(false);
                }

                damagepanel = Heros[value].transform.GetChild(1).gameObject;
                damagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(damaged).ToString();
                damagepanel.SetActive(true);


                float currentvalue = 0;
                float savevalue = PlayerPrefs.GetFloat(Heros[value].name + "_HPValue");
                currentvalue = Mathf.Clamp(PlayerPrefs.GetFloat(Heros[value].name + "_HPValue") - Mathf.RoundToInt(damaged), 0f, PlayerPrefs.GetFloat(Heros[value].name + "_HPMax"));
                //the hero set new Hp value after damage receive.
                PlayerPrefs.SetFloat(Heros[value].name + "_HPValue", currentvalue);

                //destoring the hero.......
                if (currentvalue <= 0)
                {
                    //play the death animation here 
                    Heros[value].GetComponent<Animator>().SetBool("Death", true);
                    Heros[value].GetComponent<PA>().DeathPlayer = PA.Death.death;
                    //Destroy(Heros[Hiton]);
                }
                PlayerPrefs.DeleteKey(Heros[value].name + "Protect_Player");
                Debug.Log("Action: " + ActionName + " player: " + Heros[Hiton].name + " NewPlayer: " + Heros[value].name + " Damage: " + damaged);
                //player distroy her if it hp value is less or eual to zero.

            }
            else
            {
                float EnemyAttackValue = PlayerPrefs.GetFloat(gameObject.name + "_ATK");
                float PlayerDefenceValue = PlayerPrefs.GetFloat(Heros[Hiton].name + "_DEF");
                //Debug.Log("player defence before boost=" + PlayerDefenceValue);
                //Debug.Log("player defence before boost damage=" + ((4 * EnemyAttackValue) - (2 * PlayerDefenceValue)));

                if (PlayerPrefs.HasKey(Heros[Hiton].name + "Defence_Boost"))
                {
                    float Action_Defence_Value = PlayerPrefs.GetFloat(Heros[Hiton].name + "Defence_Boost");
                    PlayerDefenceValue += Action_Defence_Value;
                    PlayerPrefs.DeleteKey(Heros[Hiton].name + "Defence_Boost");
                    Debug.Log("player defence after boost=" + PlayerDefenceValue);
                }
                //damage will be depend on the diffrent action that enemy perform
                damaged = Mathf.Abs((4 * EnemyAttackValue) - (2 * PlayerDefenceValue));
                //Debug.Log("player defence after boost damage=" + ((4 * EnemyAttackValue) - (2 * PlayerDefenceValue)));
                for (int i = 0; i < Heros.Length; i++)
                {
                    Heros[i].transform.GetChild(1).gameObject.SetActive(false);
                }

                damagepanel = Heros[Hiton].transform.GetChild(1).gameObject;
                damagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(damaged).ToString();
                damagepanel.SetActive(true);

                float currentvalue = 0;
                float savevalue = PlayerPrefs.GetFloat(Heros[Hiton].name + "_HPValue");
                currentvalue = Mathf.Clamp(PlayerPrefs.GetFloat(Heros[Hiton].name + "_HPValue") - Mathf.RoundToInt(damaged), 0f, PlayerPrefs.GetFloat(Heros[Hiton].name + "_HPMax"));
                //the hero set new Hp value after damage receive.
                PlayerPrefs.SetFloat(Heros[Hiton].name + "_HPValue", currentvalue);

                //destoring the hero.......
                if (currentvalue <= 0)
                {
                    //play the death animation here 
                    Heros[Hiton].GetComponent<Animator>().SetBool("Death", true);
                    Heros[Hiton].GetComponent<PA>().DeathPlayer = PA.Death.death;
                    //Destroy(Heros[Hiton]);
                }
                //Debug.Log("Action: " + ActionName + " player: " + Heros[Hiton].name + " Damage: " + damaged);
            }
        }
        catch (System.Exception)
        {
            //goto step;

        }
    }

    void Enemy_dead_Event()
    {

        if (PlayerPrefs.GetFloat(gameObject.name + "_HPValue") <= 0)
        {
            gameObject.GetComponent<Animator>().SetBool("Death", true);
            Destroy(GameObject.Find(gameObject.transform.parent.name), 2f);
            Globalvariable.WinningLosing = true;
        }

    }
}
