using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAction : MonoBehaviour
{
    #region variable
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
    internal string ActinName;

    public State state;
    public enum State
    {
        Action,
        busy,

    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        state = State.busy;
        ActiveCircle.SetActive(false);
        anim = GetComponent<Animator>();
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
        if (state == State.Action)
        {
            int Action = Random.Range(0, AL.EnemyActionsList.Length);
            ActinName = AL.EnemyActionsList[Action];
            int Hiton = Random.Range(0, PlayerList.Length);


            Globalvariable.currentTime += Time.deltaTime;
            if (action == true)
            {
                Globalvariable.nextTime = Globalvariable.currentTime + 1f;
                action = false;
            }
            ActiveCircle.SetActive(true);
           
          
            if (Globalvariable.currentTime > Globalvariable.nextTime)
            {
                action = true;
                Globalvariable.Index--;
                state = State.busy;
                anim.SetBool("Happy", false);
                anim.SetBool("Punch", false);
            }

        }
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
           
        }

    }

    public float damage_Calculation()
    {
        //damage formula 


        return 0;
    }


}
