using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playeranimator : MonoBehaviour
{
    public Animator ani;
    public PlayerInput input;
    private bool punch;
    float punchtime;
    float timetoReturnback;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        punchtime += Time.deltaTime;
        if (input.kick)
        {

           
            timetoReturnback = punchtime + 1;
            ani.SetBool("punch", true);
        }

        if(timetoReturnback<punchtime)
        {
            ani.SetBool("punch", false);
        }
        //StartCoroutine(wait());
        //if (punch == true)
        //{
           
           
        //    //punch = false;
        //}
        //else
        //{
           
            
        //}
    }

  
}
