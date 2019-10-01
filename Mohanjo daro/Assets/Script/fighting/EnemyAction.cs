using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAction : MonoBehaviour
{
    #region variable
    [HideInInspector]
    public bool PlayerState = false;

    public GameObject ActiveCircle;
    public GameObject[] ActionList;

    public Animator anim;
    bool action=true;



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
        if (state == State.Action)
        {
            Globalvariable.currentTime += Time.deltaTime;
            if (action == true)
            {
                Globalvariable.nextTime = Globalvariable.currentTime + 1f;
                action = false;
            }
            ActiveCircle.SetActive(true);
            //if (Input.GetKeyDown(KeyCode.E))
            //{
            //Automatic action perform 
            int num = Random.Range(1, ActionList.Length);
           
            if (num == 1)
            {
                //Debug.Log("Action: " + num + "Hit");
                anim.SetBool("Happy", true);
            }
            if (num == 2)
            {
                //Debug.Log("Action: " + num + "I am thinking");
                anim.SetBool("Punch", true);
            }
               
            if (num == 3)
            {
                //Debug.Log("Action: " + num + "I Hit");
                anim.SetBool("Happy", true);
            }
            if (num == 4)
            {
                //Debug.Log("Action: " + num + "I am Ready to kill you");
                anim.SetBool("Punch", true);
            }

            if (Globalvariable.currentTime > Globalvariable.nextTime)
            {
                action = true;
                Globalvariable.Index--;
                state = State.busy;
                anim.SetBool("Happy", false);
                anim.SetBool("Punch", false);
            }


            //}
        }
        else
        {
            ActiveCircle.SetActive(false);
        }

    }


}
