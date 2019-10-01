using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PA : MonoBehaviour
{
    #region variable
    public GameObject ActiveCircle;                         //declaring the gameobject  for player turn circle
    public Callingscriptableobject callScriptObject;        //declaring the scriptable object 
    public State state;                                     //declare state variable player current state
    public float AGIValue;                                  //declare AGI variable, player current Agi
    public GameObject helathSliderPanel;                    //declaring PlayerUi health bar object
    public GameObject PlayerUIPanel;                        //declaring playerUi State object 
    public GameObject TurnUiPanel;                          //declaring TurnUi State object 
   
    //making player state collection 
    public enum State
    {
        waitingforinput,
        busy,
    }
    #endregion

    private void Start()
    {
        state = State.busy;                             //make default state in busy state
        ActiveCircle.SetActive(false);                  //make all player turn circle disable
        AGIValue = callScriptObject.Attribute.AGI;      //set player AGI value from scriptable object 
        Globalvariable.PlayerUi = false;                //call global variable PlayerUi false
    }
    // Update is called once per frame
    void Update()
    {

        if(Globalvariable.turnUi== true)
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
            helathSliderPanel.SetActive(false);
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
            
            //do action on player input press
            if (Input.GetKeyDown(KeyCode.A))
            {
                //player action goes here
                Debug.Log(gameObject.name + " Hit");
                //calling the playe attack animation 
                //Anim.SetBool("movetoattack",true);
                //making the global variable index set to zero
                Globalvariable.Index--;
                Globalvariable.Heal=0;
                //after action make player state busy
                state = State.busy;
            }
        }
        else
        {
            ActiveCircle.SetActive(false);
           
        }
        
    }

    public void Healling_Option()
    {
        if (state == State.waitingforinput)
        {
            Debug.Log(gameObject.name + " Hit");           
            Globalvariable.Index--;
            Globalvariable.Heal = 0;
            //after action make player state busy
            state = State.busy;
        }
    }

}
