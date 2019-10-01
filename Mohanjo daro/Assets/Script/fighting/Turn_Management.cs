using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(extract)
        {
            extract = false;
            spawanHero = GameObject.FindGameObjectsWithTag("Player");
            for(int i=0;i<spawanHero.Length;i++)
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
        }

        if (Globalvariable.Index == 0)
        {
            //Destroy(startmassage);
            if (characterQueue.Count > 0)
            {
                Globalvariable.Index++;
                CharacterMoveChoice characterAbility = characterQueue.Dequeue();

                Debug.Log(characterAbility.character.Name + "'s speed = " + characterAbility.character.AGI);

                for (int i = 0; i < spawanHero.Length; i++)
                {
                    //Debug.Log(spawanHero[i].name);

                    if (spawanHero[i].gameObject == characterAbility.character.Name)
                    {
                        try
                        {
                            spawanHero[i].GetComponent<PA>().state = PA.State.waitingforinput;
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
                            spawanHero[i].GetComponent<EnemyAction>().state = EnemyAction.State.Action;
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
                            spawanHero[i].GetComponent<EnemyAction>().state = EnemyAction.State.busy;
                            for (int j = 0; j < ChangeInPrefab.Length; j++)
                            {
                                if (spawanHero[i].name == ChangeInPrefab[j].name)
                                {
                                    ChangeInPrefab[j].GetComponent<EnemyAction>().state = EnemyAction.State.busy;
                                }
                            }
                        }                      
                    }
                }
            }
            else
            {
                for (int i = 0; i < selectedChoice.Count; i++)
                {
                    characterQueue.Enqueue(selectedChoice[i]); TurnQueue.Enqueue(selectedChoice[i]);
                }
            }
        }
    }
}
