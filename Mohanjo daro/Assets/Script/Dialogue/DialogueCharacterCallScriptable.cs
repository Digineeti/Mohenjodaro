using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueCharacterCallScriptable : MonoBehaviour
{
    public DialogueCharacter[] character;
    public Text player_Name;
    public Image player_Image;
    string p_Name;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i<character.Length; i++)
        {
            int index = player_Name.text.IndexOf("[");

            if (player_Name.text!="" && index>0)
            {
                p_Name = player_Name.text.Substring(0, index);
                string expression = player_Name.text.Substring(index+1, 1);
                
               

                if (p_Name == character[i].dialoger)
                {
                    player_Image.sprite = character[i].expressions[int.Parse(expression)].photo;

                }
            }
           
        }
        player_Name.text = p_Name;
    }
}
