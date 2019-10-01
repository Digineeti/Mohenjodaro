using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ReceiveAndDamageValue :MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Players;
    bool action;
    int value;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Action()
    {

        for (int i = 0; i < Players.Length; i++)
        {
            if (Players[i].GetComponent<PA>().state.ToString() == "waitingforinput")
            {
                Globalvariable.currentTime += Time.deltaTime;
                Globalvariable.nextTime = Globalvariable.currentTime + 1f;
                action = true;
                value = i;
            }
            if (action == true)
            {
                Players[value].GetComponent<Animator>().SetBool("punch", true);
                
                //if (Globalvariable.currentTime > Globalvariable.nextTime)
                //{
                    Globalvariable.Index--;
                    Globalvariable.Heal = 0;
                    Players[value].GetComponent<Animator>().SetBool("punch", false);
                    //after action make player state busy
                    action = false;
                //}
            }
        }
    }
}
