﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PA : MonoBehaviour
{
    #region variable
    
    public GameObject ActiveCircle;                         //declaring the gameobject  for player turn circle
    public Callingscriptableobject callScriptObject;        //declaring the scriptable object 
  
    public float AGIValue;                                  //declare AGI variable, player current Agi
    //public GameObject helathSliderPanel;                    //declaring PlayerUi health bar object
    public GameObject PlayerUIPanel;                        //declaring playerUi State object 
    public GameObject TurnUiPanel;                          //declaring TurnUi State object 
    public ParticleSystem ParticalturnBlinker;
    public GameObject Light;

    bool startup;

    float currentTime;
    float NextTime;
    bool damage = true;

    private Animator anim;

    //making player state collection 
    public State state;                                     //declare state variable player current state
    public enum State
    {
        waitingforinput,      
        busy,
    }

    public TurnState Turnstate;
    public enum TurnState
    {
        Turnover,
        NextTurn,
    }

    public  Death DeathPlayer;
    public enum Death
    {
        Active,
        death,
    }

    //moving toward to enemy
    private float speed = 4;
    private Vector3 targetPosition;
    private bool isMoving = false;

   
    #endregion

    private void Start()
    {
        state = State.busy;                             //make default state in busy state
        ActiveCircle.SetActive(false);                  //make all player turn circle disable
        AGIValue = callScriptObject.Attribute.AGI;      //set player AGI value from scriptable object 
        Globalvariable.PlayerUi = false;                //call global variable PlayerUi false

        anim = GetComponent<Animator>();

        Turnstate = TurnState.NextTurn;

        //GM = GetComponent<GridMaster>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Globalvariable.turnUi== true)
        {
            TurnUiPanel.SetActive(true);
        }
        else
        {
            TurnUiPanel.SetActive(false);
        }
        //set PlayerUI healthbar active by default
        if (Globalvariable.PlayerUi == true)
        {
            //healthbar enable
            //helathSliderPanel.SetActive(false);
            //playerUi stat disable
            PlayerUIPanel.SetActive(true);
        }
        else
        {
            //healthbar disable
            PlayerUIPanel.SetActive(false);
        }       

       //player action on state change 
        if (state == State.waitingforinput)
        {
            //active the turn circle
            Globalvariable.AttackUi = true;
            ActiveCircle.SetActive(true);

            var emission = ParticalturnBlinker.emission;
            emission.enabled = true;
            Light.SetActive(true);
            //ParticalturnBlinker.Play();

            //do action on player input press
            if(DeathPlayer==Death.Active)
            {
                Globalvariable.currentTime += Time.deltaTime;
                if (Globalvariable.Active_Player_Action)
                {
                    Globalvariable.nextTime = Globalvariable.currentTime + 1f;
                    anim.SetBool(Globalvariable.Active_Player_Animation_Parameter, true);
                    startup = true;
                    Globalvariable.Active_Player_Action = false;
                }
                if (startup == true)
                {
                    if (Globalvariable.currentTime > Globalvariable.nextTime)
                    {
                        startup = false;
                        anim.SetBool(Globalvariable.Active_Player_Animation_Parameter, false);
                        Globalvariable.Index = 0;
                        Turnstate = TurnState.Turnover;
                        Globalvariable.Active_Player_Animation_Parameter = null;
                       

                    }

                }

              
            }
            if(DeathPlayer == Death.death)
            {
                Globalvariable.Index = 0;
                Turnstate = TurnState.Turnover;
            }
            //add the ap here to the player attribute.....
            //player move on mouse clcik in the scene

            //if (Input.GetMouseButton(0))
            //{
            //    SetTargetPosition();
            //}
            //if (isMoving)
            //{
            //    move();
            //}

        }
        else
        {
            ActiveCircle.SetActive(false);
            var emission = ParticalturnBlinker.emission;
            emission.enabled = false;
            currentTime += Time.deltaTime;
            if (damage == true)
            {
                if (gameObject.transform.GetChild(1).gameObject.activeSelf == true)
                {
                    NextTime = currentTime + 1;
                    damage = false;
                }
            }
            if (currentTime > NextTime)
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                damage = true;
            }

            if (Globalvariable.All_Player_Hoverbutton == false)
                Light.SetActive(false);
        }
       
    }

    public void Healling_Option()
    {
        if (state == State.waitingforinput)
        {
            Debug.Log(gameObject.name + " Hit");           
            Globalvariable.Index=0;
            Globalvariable.Heal = 0;
            //after action make player state busy
            state = State.busy;
        }
    }

    private void LateUpdate()
    {
        //if (state == State.waitingforinput)
        //{
        //    if (sp_Added==2)
        //    {
        //        Globalvariable.SP = false;
        //        PlayerPrefs.DeleteKey(gameObject.name + "Added_SP");
        //        PlayerPrefs.SetFloat(gameObject.name + "_SPValue", Mathf.Clamp(PlayerPrefs.GetFloat(gameObject.name + "_SPValue") + PlayerPrefs.GetFloat(gameObject.name + "Action_SP"), 0f, PlayerPrefs.GetFloat(gameObject.name + "_SPMax")));
        //    }

        //}
    }
    void SetTargetPosition()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;
        isMoving = true;
    }

    void move()
    {
        //transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (transform.position == targetPosition)
        {
            isMoving = false;
        }
    }

    void Health_Potion()
    {

    }
}
