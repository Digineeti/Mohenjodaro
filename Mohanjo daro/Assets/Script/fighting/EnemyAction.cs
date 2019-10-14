using System.Collections;
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
    bool action=true;

    float currentTime;
    float NextTime;
    bool damage=true;

    public ActionList AL;
    public GameObject []PlayerList;
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
        if (state == State.Action)
        {
            
            Globalvariable.currentTime += Time.deltaTime;
           
            if (action == true)
            {
                Globalvariable.nextTime = Globalvariable.currentTime + 1f;
                damage_Calculation();
                action = false;
                Globalvariable.After_Death_ReSequence += 1;
            }
            ActiveCircle.SetActive(true);
            Light.SetActive(true);
            //damagepanel.SetActive(true);
            if (Globalvariable.currentTime > Globalvariable.nextTime)
            {
                action = true;
                //damagepanel.SetActive(false);
                Globalvariable.Index=0;
                state = State.busy;
                Turnstate = TurnState.Turnover;
                anim.SetBool("Happy", false);
                anim.SetBool("Punch", false);
            }

        }
        //else if (state == State.Death)
        //{
        //    Globalvariable.currentTime += Time.deltaTime;
        //    if (action == true)
        //    {
        //        Globalvariable.nextTime = Globalvariable.currentTime + 1f;
        //        action = false;
        //        anim.SetBool("Death", true);
        //    }
        //    if (Globalvariable.currentTime > Globalvariable.nextTime)
        //    {
        //        action = true;               
        //        Turnstate = TurnState.Turnover;
        //        Destroy(gameObject);
        //        //gameObject.SetActive(false);
                
        //    }
        //}
        else
        {
            ActiveCircle.SetActive(false);
            currentTime += Time.deltaTime;
            if (damage == true)
            {
                if (gameObject.transform.GetChild(1).gameObject.activeSelf == true)
                {                   
                    NextTime = currentTime + 1;
                    damage = false;
                }
            }
            if(currentTime>NextTime)
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                damage = true;
            }
            if (Globalvariable.All_Enemy_Hoverbutton == false)
                Light.SetActive(false);
        }

    }

    public void  damage_Calculation()
    {
        
        float damaged = 0;
        int Action = Random.Range(0, AL.EnemyActionsList.Length);
        ActionName = AL.EnemyActionsList[Action];
        int Hiton = Random.Range(0, PlayerList.Length);

        float EnemyAttackValue = gameObject.GetComponent<En_Callingscriptableobject>().Attribute.ATK;
        float PlayerDefenceValue= PlayerList[Hiton].GetComponent<Callingscriptableobject>().Attribute.DEF;
        //damage will be depend on the diffrent action that enemy perform
        damaged = (EnemyAttackValue * EnemyAttackValue) / (PlayerDefenceValue + EnemyAttackValue);
        for (int i=0;i<PlayerList.Length;i++)
        {
            PlayerList[i].transform.GetChild(1).gameObject.SetActive(false);        
        }

        damagepanel = PlayerList[Hiton].transform.GetChild(1).gameObject;
        damagepanel.GetComponentInChildren<TMP_Text>().text = Mathf.RoundToInt(damaged).ToString();
        damagepanel.SetActive(true);

        //the enemy current Hp value 
        PlayerPrefs.SetFloat(PlayerList[Hiton].name + "_HPValue", PlayerPrefs.GetFloat(PlayerList[Hiton].name + "_HPValue") - Mathf.RoundToInt(damaged));

        Debug.Log("Action: "+ActionName +" player: "+ PlayerList[Hiton].name + " Damage: "+ damaged);
      

    }


}
