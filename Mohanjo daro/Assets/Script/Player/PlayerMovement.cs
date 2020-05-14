using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RPGTALK.Localization;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    #region variable_Declaration_Section
    [Header("Walk and Run section")]
    public float h_Current_Speed = 1f;                                //player speed 
    public float v_Current_Speed = 1f;                                //player speed 
    public float acceleration_Speed = 2f;                             //player speed 
    public float max_Speed = 3f;                                      //player speed 


    PlayerInput input;                                                //Declare Playerinput file object
    Rigidbody2D RD;                                                   //Declare Playerinput file object
    public int direction_X = 1;                                       //Direction player is facing
    public int direction_Y = 1;                                       //Direction player is facing

    private Animator amin;
    private bool playerMoving;
    public  Vector2 lastMove;

    private bool WalkArea;


    [SerializeField]
    private GearSocket [] gearSocket;
    #endregion
    private void Awake()
    {
        lastMove = new Vector2(0f, 0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();                            //initializing the input to playerinput 
        RD = GetComponent<Rigidbody2D>();                               //initializing the input to playerinput 
        amin = GetComponent<Animator>();

    }

    private void Update()
    {
        
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //calling the Groundmovement function
        GroundMovement();
    }

    //player movement script 
    void GroundMovement()
    {
        
            if (Globalvariable.Dialogue_Open == false)
            {
                playerMoving = false;
                // Smooting the currentSpeed to the targetSpeed
                if (input.horizontal > 0.5f || input.horizontal < -0.5f)
                {
                    h_Current_Speed = Mathf.SmoothStep(h_Current_Speed, max_Speed, acceleration_Speed * Time.deltaTime);
                    float x_velocity = input.horizontal * h_Current_Speed;
                    //Debug.Log("Speed: " + h_Current_Speed);
                    //transform.Translate(new Vector2(x_velocity*Time.deltaTime, 0f));
                    RD.velocity = new Vector2(input.horizontal * h_Current_Speed, 0f);
                    playerMoving = true;
                    lastMove = new Vector2(input.horizontal, 0f);
                    //FindObjectOfType<AudioManager>().play("PlayerWalk");
                    Globalvariable.Fight_Scene_Load_freqency += Time.deltaTime;

                }
                if (input.vertical > 0.5f || input.vertical < -0.5f)
                {
                    v_Current_Speed = Mathf.SmoothStep(v_Current_Speed, max_Speed, acceleration_Speed * Time.deltaTime);
                    float y_velocity = input.vertical * v_Current_Speed;
                    // Debug.Log("Speed: " + v_Current_Speed);
                    //transform.Translate(new Vector2(0f, y_velocity*Time.deltaTime));
                    RD.velocity = new Vector2(0f, input.vertical * v_Current_Speed);
                    playerMoving = true;
                    lastMove = new Vector2(0f, input.vertical);
                    Globalvariable.Fight_Scene_Load_freqency += Time.deltaTime;
                }

                if ((input.horizontal > 0.5f || input.horizontal < -0.5f) && (input.vertical > 0.5f || input.vertical < -0.5f))
                {
                    RD.velocity = new Vector2(0f, 0f);

                }

                if (input.horizontal < 0.5f && input.horizontal > -0.5f)
                {
                    RD.velocity = new Vector2(0f, RD.velocity.y);
                    h_Current_Speed = 0;

                    //Globalvariable.Fight_Scene_Load_freqency += Time.deltaTime;
                }
                if (input.vertical < 0.5f && input.vertical > -0.5f)
                {
                    RD.velocity = new Vector2(RD.velocity.x, 0f);
                    v_Current_Speed = 0;
                    //Globalvariable.Fight_Scene_Load_freqency += Time.deltaTime;

                }

                amin.SetFloat("MoveX", input.horizontal);
                amin.SetFloat("MoveY", input.vertical);
                amin.SetBool("PlayerMoving", playerMoving);
                amin.SetFloat("LastMoveX", lastMove.x);
                amin.SetFloat("LastMoveY", lastMove.y);

                foreach (GearSocket g in gearSocket)
                {
                    g.SetXandY(input.horizontal, input.vertical, lastMove, playerMoving);
                    //g.Activate_Layer(layerName);
                }

            }
            else
            {
                playerMoving = false;
                amin.SetBool("PlayerMoving", playerMoving);
                RD.velocity = new Vector2(0f, 0f);
            }
        

    }

   
  
}




