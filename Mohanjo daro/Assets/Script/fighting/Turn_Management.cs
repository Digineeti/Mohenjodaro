﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Turn_Management : MonoBehaviour
{
    public GameObject[] spawanHero;
    bool extract = true;

    public GameObject[] ChangeInPrefab;

    // Start is called before the first frame update
    public struct Character
    {
        public GameObject Name;
        public float AGI;
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
    public Queue<CharacterMoveChoice> TurnQueue = new Queue<CharacterMoveChoice>();
    void Start()
    {
        Globalvariable.extract_sequence = true;
    }

    // Update is called once per frame
    void Update()
    {
        spawanHero = GameObject.FindGameObjectsWithTag("Player");

        //if (extract)
        //{
        //    extract = false;
        //    Player_Attribute_Sequence();
        //}
        if (Globalvariable.extract_sequence)
        {
            Globalvariable.extract_sequence = false;
            Player_Attribute_Sequence();
        }
        if (Globalvariable.Index == 0)
        {
            //Destroy(startmassage);
            if (characterQueue.Count > 0)
            {
                Globalvariable.Index++;
                CharacterMoveChoice characterAbility = characterQueue.Dequeue();
                //Debug.Log(characterAbility.character.Name + "'s speed = " + characterAbility.character.AGI);
                for (int i = 0; i < spawanHero.Length; i++)
                {
                    //Debug.Log(spawanHero[i].name);
                    if (spawanHero[i].gameObject == characterAbility.character.Name)
                    {
                        try
                        {
                            
                            spawanHero[i].GetComponent<PA>().state = PA.State.waitingforinput;
                            //changing the state of prefeb 
                            for(int j=0;j<ChangeInPrefab.Length;j++)
                            {
                                if(spawanHero[i].name==ChangeInPrefab[j].name)
                                {
                                    ChangeInPrefab[j].GetComponent<PA>().state = PA.State.waitingforinput;
                                }
                            }                          
                        }
                        catch (System.Exception)
                        {
                            Globalvariable.AttackUi = false;
                            if(spawanHero[i].GetComponent<EnemyAction>().state.ToString()== "Death")
                            {

                            }
                            else
                            {
                                spawanHero[i].GetComponent<EnemyAction>().state = EnemyAction.State.Action;
                            }
                          
                            //changing the state of prefeb 
                            for (int j = 0; j < ChangeInPrefab.Length; j++)
                            {
                                if (spawanHero[i].name == ChangeInPrefab[j].name)
                                {
                                    ChangeInPrefab[j].GetComponent<EnemyAction>().state = EnemyAction.State.Action;
                                }
                            }
                        }                       
                    }
                    else
                    {
                        Globalvariable.AttackUi = false;
                        try
                        {
                            spawanHero[i].GetComponent<PA>().state = PA.State.busy;
                            //changing the state of prefeb 
                            for (int j = 0; j < ChangeInPrefab.Length; j++)
                            {
                                if (spawanHero[i].name == ChangeInPrefab[j].name)
                                {
                                    ChangeInPrefab[j].GetComponent<PA>().state = PA.State.busy;
                                }
                            }
                        }
                        catch (System.Exception)
                        {
                            if (spawanHero[i].GetComponent<EnemyAction>().state.ToString() == "Death")
                            {

                            }
                            else
                            {
                                spawanHero[i].GetComponent<EnemyAction>().state = EnemyAction.State.busy;
                            }
                            //changing the state of prefeb 
                            for (int j = 0; j < ChangeInPrefab.Length; j++)
                            {
                                if (spawanHero[i].name == ChangeInPrefab[j].name)
                                {
                                    ChangeInPrefab[j].GetComponent<EnemyAction>().state = EnemyAction.State.busy;
                                }
                            }
                        }                      
                    }
                    try
                    {
                        if (spawanHero[i].GetComponent<PA>().Turnstate.ToString() == "NextTurn")
                            spawanHero[i].GetComponent<PA>().TurnUiPanel.GetComponentInChildren<TMP_Text>().color = Color.red;
                        else
                            spawanHero[i].GetComponent<PA>().TurnUiPanel.GetComponentInChildren<TMP_Text>().color = Color.black;
                    }
                    catch (System.Exception)
                    {
                        if (spawanHero[i].GetComponent<EnemyAction>().Turnstate.ToString() == "NextTurn")
                            spawanHero[i].GetComponent<EnemyAction>().TurnUiPanel.GetComponentInChildren<TMP_Text>().color = Color.red;
                        else
                            spawanHero[i].GetComponent<EnemyAction>().TurnUiPanel.GetComponentInChildren<TMP_Text>().color = Color.black;
                        
                    }
                }
            }
            else
            {
                for (int i = 0; i < spawanHero.Length; i++)
                {
                    try
                    {
                        spawanHero[i].GetComponent<PA>().Turnstate = PA.TurnState.NextTurn;
                    }
                    catch (System.Exception)
                    {
                        spawanHero[i].GetComponent<EnemyAction>().Turnstate = EnemyAction.TurnState.NextTurn;
                    }
                }
                for (int i = 0; i < selectedChoice.Count; i++)
                {
                    characterQueue.Enqueue(selectedChoice[i]); TurnQueue.Enqueue(selectedChoice[i]);                  
                }
            }
        }

        // destory the player which has hp power is equal to or less then zero....

        //for (int i = 0; i < spawanHero.Length; i++)
        //{
        //    try
        //    {
        //        if (spawanHero[i].GetComponent<Callingscriptableobject>().HPValue.value <= 0)
        //            Destroy(gameObject);
        //    }
        //    catch (System.Exception)
        //    {

        //        if (spawanHero[i].GetComponent<En_Callingscriptableobject>().HPValue.value <= 0)
        //            Destroy(gameObject);
        //    }
        //}

      
    }

    public  void Player_Attribute_Sequence()
    {
      
        for (int i = 0; i < spawanHero.Length; i++)
        {
            try
            {
                Character One = new Character
                {
                    Name = spawanHero[i].gameObject,
                    AGI = spawanHero[i].GetComponent<Callingscriptableobject>().Attribute.AGI,
                };
                Ability testAbility = new Ability
                {
                    Name = "Tackle"
                };
                CharacterMoveChoice choice1 = new CharacterMoveChoice
                {
                    character = One,
                    ability = testAbility
                };
                selectedChoice.Add(choice1);
            }
            catch (System.Exception)
            {
                Character One = new Character
                {
                    Name = spawanHero[i].gameObject,
                    AGI = spawanHero[i].GetComponent<En_Callingscriptableobject>().Attribute.AGI,
                };
                Ability testAbility = new Ability
                {
                    Name = "Tackle"
                };
                CharacterMoveChoice choice1 = new CharacterMoveChoice
                {
                    character = One,
                    ability = testAbility
                };
                selectedChoice.Add(choice1);
            }
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
            TurnQueue.Enqueue(selectedChoice[i]);
        }
        //turn sequence 
        if(extract)
        {
            int count = 0;
            while (TurnQueue.Count > 0)
            {

                Turn_Management.CharacterMoveChoice characterAbility = TurnQueue.Dequeue();

                for (int i = 0; i < spawanHero.Length; i++)
                {
                    //Debug.Log(spawanHero[i].name);

                    if (spawanHero[i].gameObject == characterAbility.character.Name)
                    {
                        count++;
                        try
                        {
                            spawanHero[i].GetComponent<PA>().TurnUiPanel.GetComponentInChildren<TMP_Text>().text = count.ToString();
                        }
                        catch (System.Exception)
                        {
                            spawanHero[i].GetComponent<EnemyAction>().TurnUiPanel.GetComponentInChildren<TMP_Text>().text = count.ToString();
                        }
                    }

                }
            }
            extract = false;
        }
       

    }
}
