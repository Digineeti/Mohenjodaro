using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    #region variable_Declaration_Section
    [HideInInspector] public float  horizontal;                     //Declare float variable for x_axis movement
    [HideInInspector] public float  vertical;                       //Declare float variable for y_axis movement
    [HideInInspector] public bool  kick;                            //Declare bool variable for kick the enemy
    [HideInInspector] public bool attack;                           //Declare bool variable for attack to enemy 

                      bool          readyToClear;                   //Bool used to keep input in sync  
                      private static bool playerExists;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);           
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //calling  Clear_Input method 
        Clear_Input();

        //calling ProcessInput Method
        ProcessInputs();        
    }

    // Fixed Update is called once per frame with uniform speed
    private void FixedUpdate()
    {
        readyToClear = true;
    }
    
    void Clear_Input()
    {
        //If we're not ready to clear input, exit
        if (!readyToClear)
            return;
       
        readyToClear        = false;                                       //Reset all inputs
        horizontal          = 0f;                                          //Reseting the Horizontal  
        vertical            = 0f;                                          //Reseting the Vertical
        kick                = false;
        attack              = false;
    }

    void ProcessInputs()
    {
        //Accumulate horizontal axis input
        horizontal          += Input.GetAxis("Horizontal");                //passing input button to Horizontal Variable..its a float type 
        vertical            += Input.GetAxis("Vertical");                  //passing input button to Horizontal Variable..its a float type 
        kick                =  kick || Input.GetButtonDown("Kick");
        attack              = attack || Input.GetButtonDown("Select");
    }

    void Access_Input()
    {
        if (horizontal > 0)
            Debug.Log("Horizontal Positive movement along x-axis");         //checking Horizontal Positive axis input key working or not 
        if (horizontal < 0)
            Debug.Log("Horizontal Negative movement along x-axis");         //checking Horizontal Negative axis input key working or not 
        if (vertical > 0)
            Debug.Log("Vertical positive movement along y-axis");           //checking Vertical Positive axis input key working or not 
        if (vertical < 0)
            Debug.Log("Vertical negative movement along y-axis");           //checking Vertical Negative axis input key working or not 
    }
}
