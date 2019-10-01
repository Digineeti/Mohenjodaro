using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListSortTest : MonoBehaviour
{
    
    public struct Character
    {
        [SerializeField]
        public string Name;
        public int BaseSpeed;
        public GameObject prefab;
    }

    public struct Ability
    {
        public string Name;
    }

    
    public Character characterOne, characterTwo,characterthree;

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
        characterOne = new Character
        {
            Name = "Billy",
            BaseSpeed = 10
        };

        characterTwo = new Character
        {
            Name = "Fred",
            BaseSpeed = 8
        };

        characterthree = new Character
        {
            Name = "ABCD",
            BaseSpeed=15
        };

        Ability testAbility = new Ability
        {
            Name = "Tackle"
        };

        CharacterMoveChoice choice1 = new CharacterMoveChoice
        {
            character = characterOne,
            ability = testAbility

        };

        CharacterMoveChoice choice2 = new CharacterMoveChoice
        {
            character = characterTwo,
            ability = testAbility
        };

        CharacterMoveChoice choice3 = new CharacterMoveChoice
        {
            character = characterthree,
            ability = testAbility
        };

        selectedChoice.Add(choice2);
        selectedChoice.Add(choice1);
        selectedChoice.Add(choice3);
        selectedChoice.Add(choice1);
        selectedChoice.Add(choice2);
        selectedChoice.Add(choice3);

        for (int i = 0; i < selectedChoice.Count; i++)
        {
            Debug.Log(selectedChoice[i].character.Name + " speed : " + selectedChoice[i].character.BaseSpeed);
        }

        Debug.Log("Sorting");

        selectedChoice.Sort(delegate (CharacterMoveChoice x, CharacterMoveChoice y)
        {
            if (x.character.BaseSpeed == y.character.BaseSpeed) return 0;

            else if (x.character.BaseSpeed > y.character.BaseSpeed) return -1;

            else if (x.character.BaseSpeed < y.character.BaseSpeed) return 1;

            else return x.character.BaseSpeed.CompareTo(y.character.BaseSpeed);
        });



        for (int i = 0; i < selectedChoice.Count; i++)
        {
            characterQueue.Enqueue(selectedChoice[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {

            if (characterQueue.Count > 0)
            {
                CharacterMoveChoice characterAbility = characterQueue.Dequeue();
                Debug.Log(characterAbility.character.Name + "'s speed = " + characterAbility.character.BaseSpeed);
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
