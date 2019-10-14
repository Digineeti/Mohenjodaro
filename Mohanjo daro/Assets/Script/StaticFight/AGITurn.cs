using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class AGITurn : MonoBehaviour
{
    //No of hero active in the scene
    public int NoOfHero;
    public GameObject[] playerlist;


    public GameObject startmassage;
    //bool StartActive=true;
  
    public struct Character
    {
        public string Name;
        public float AGI;
        public GameObject prefab;
    }

    public struct Ability
    {
        public string Name;
    }

    public struct CharacterMoveChoice
    {
        public Character character;
        public Ability ability;
    }
   
    public List<CharacterMoveChoice> selectedChoice = new List<CharacterMoveChoice>();
    Queue<CharacterMoveChoice> characterQueue = new Queue<CharacterMoveChoice>();
    // Start is called before the first frame update
    void Start()
    {
        //herolist generated
        for (int i = 0; i < playerlist.Length; i++)
        {
            Character characterOne;
            if (playerlist[i].gameObject.tag == "Player")
            {
                characterOne = new Character
                {
                    Name = playerlist[i].gameObject.name,
                    AGI = playerlist[i].GetComponent<Callingscriptableobject>().Attribute.AGI,
                    prefab = playerlist[i].gameObject                    
                };
            }
            else
            {
                characterOne = new Character
                {
                    Name = playerlist[i].gameObject.name,
                    AGI = playerlist[i].GetComponent<En_Callingscriptableobject>().Attribute.AGI,
                    prefab = playerlist[i].gameObject
                };
            }
           
        Ability testAbility = new Ability
            {
                Name = "Tackle"
            };
            CharacterMoveChoice choice1 = new CharacterMoveChoice
            {
                character = characterOne,
                ability = testAbility

            };
            selectedChoice.Add(choice1);
        }


        selectedChoice.Sort(delegate (CharacterMoveChoice x, CharacterMoveChoice y)
        {
            if (x.character.AGI == y.character.AGI) return 0;

            else if (x.character.AGI > y.character.AGI) return -1;

            else if (x.character.AGI < y.character.AGI) return 1;

            else return x.character.AGI.CompareTo(y.character.AGI);
        });
        for (int i = 0; i < selectedChoice.Count; i++)
        {
            characterQueue.Enqueue(selectedChoice[i]);
        }

       
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Globalvariable.Index==0)
        {
            //Destroy(startmassage);
            //StartActive = false;
            if (characterQueue.Count > 0)
            {
                Globalvariable.Index++;
                CharacterMoveChoice characterAbility = characterQueue.Dequeue();

                Debug.Log(characterAbility.character.Name + "'s speed = " + characterAbility.character.AGI);
                //int index = Array.IndexOf(characterQueue.ToArray(), characterAbility.character.Name);                
                for (int i = 0; i < 6; i++)
                {
                    if (playerlist[i].gameObject.name == characterAbility.character.Name)
                    {
                        playerlist[i].GetComponent<PA>().state = PA.State.waitingforinput;
                    }
                    else
                    {
                        playerlist[i].GetComponent<PA>().state = PA.State.busy;
                    }
                }
                for(int i=6;i<playerlist.Length;i++)
                {
                    if (playerlist[i].gameObject.name == characterAbility.character.Name)
                    {
                        playerlist[i].GetComponent<EnemyAction>().state = EnemyAction.State.Action;
                    }
                    else
                    {
                        playerlist[i].GetComponent<EnemyAction>().state = EnemyAction.State.busy;
                    }
                }
            }
            else
            {
                for (int i = 0; i < selectedChoice.Count; i++)
                {
                    characterQueue.Enqueue(selectedChoice[i]);
                }
            }
        }
    }
}
