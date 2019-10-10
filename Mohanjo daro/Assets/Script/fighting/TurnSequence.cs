using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnSequence : MonoBehaviour
{
    public Turn_Management Turn;   
    int count = 0;
    bool startup = true;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
        //if(startup == true)
        //{
        //    startup = false;
        //    while (Turn.TurnQueue.Count > 0)
        //    {

        //        Turn_Management.CharacterMoveChoice characterAbility = Turn.TurnQueue.Dequeue();

        //        for (int i = 0; i < Turn.spawanHero.Length; i++)
        //        {
        //            //Debug.Log(spawanHero[i].name);

        //            if (Turn.spawanHero[i].gameObject == characterAbility.character.Name)
        //            {
        //                count++;
        //                try
        //                {
        //                    Turn.spawanHero[i].GetComponent<PA>().TurnUiPanel.GetComponentInChildren<TMP_Text>().text = count.ToString();                           
        //                }
        //                catch (System.Exception)
        //                {
        //                    Turn.spawanHero[i].GetComponent<EnemyAction>().TurnUiPanel.GetComponentInChildren<TMP_Text>().text = count.ToString();
        //                }
        //            }

        //        }
        //    }           
        //}
    }
}
