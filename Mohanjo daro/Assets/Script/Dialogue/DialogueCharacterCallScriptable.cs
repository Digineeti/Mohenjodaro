using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueCharacterCallScriptable : MonoBehaviour
{
    public DialogueCharacter[] character;
    public DialogueCharacter[] enemy_character;

    public Text player_Name;

    public Image player_Image;
    public Animator active_Dialoguer;
    //public Animator player_anim;
    public Image enemy_Image;
    //public Animator enemy_anim;

    string p_Name="";
    string e_Name= "";
    bool active_Player;
   
    // Update is called once per frame
    void Update()
    {


        for (int i = 0; i < character.Length; i++)
        {
            int index = player_Name.text.IndexOf("[");
            if (player_Name.text != "" && index > 0)
            {
                p_Name = player_Name.text.Substring(0, index);
                string expression = player_Name.text.Substring(index + 1, 1);

                //find the one to whom player talking..
                string talker_Name = player_Name.text.Substring(player_Name.text.IndexOf(",") + 1, player_Name.text.IndexOf("]") - (index + 2));
                int index2 = talker_Name.IndexOf("[");
                string t_Name = talker_Name.Substring(0, index2);
                string t_expression = talker_Name.Substring(index2 + 1, 1);

                //Debug.Log(talker_Name);
                
                if (p_Name == character[i].dialoger)
                {
                    active_Player = true;
                    player_Image.sprite = character[i].expressions[int.Parse(expression)].photo;
                    active_Dialoguer.SetBool("active",true);
                    //enemy_anim.SetBool("active", false);
                    for (int j = 0; j < enemy_character.Length; j++)
                    {
                        if (t_Name == enemy_character[j].dialoger)
                        {
                            enemy_Image.sprite = enemy_character[j].expressions[int.Parse(t_expression)].photo;
                        }
                    }                   
                }
            }
        }
        for (int i = 0; i < enemy_character.Length; i++)
        {
            int index = player_Name.text.IndexOf("[");
            if (player_Name.text != "" && index > 0)
            {
                p_Name = player_Name.text.Substring(0, index);
                string expression = player_Name.text.Substring(index + 1, 1);

                //find the one to whom player talking..
                string talker_Name = player_Name.text.Substring(player_Name.text.IndexOf(",") + 1, player_Name.text.IndexOf("]") - (index + 2));
                int index2 = talker_Name.IndexOf("[");
                string t_Name = talker_Name.Substring(0, index2);
                string t_expression = talker_Name.Substring(index2 + 1, 1);

                //Debug.Log(talker_Name);

                if (p_Name == enemy_character[i].dialoger)
                {
                    active_Player = true;
                    enemy_Image.sprite = enemy_character[i].expressions[int.Parse(expression)].photo;
                    active_Dialoguer.SetBool("active", false);
                    //player_anim.SetBool("active", false);
                    for (int j = 0; j < character.Length; j++)
                    {
                        if (t_Name == character[j].dialoger)
                        {
                            //enemy_Image
                            player_Image.sprite = character[j].expressions[int.Parse(t_expression)].photo;
                        }
                    }
                }
            }
        }

        //for (int i = 0; i < enemy_character.Length; i++)
        //{
        //    int index = player_Name.text.IndexOf("[");
        //    if (player_Name.text != "" && index > 0)
        //    {
        //        e_Name = player_Name.text.Substring(0, index);
        //        string expression = player_Name.text.Substring(index + 1, 1);

        //        if (e_Name == enemy_character[i].dialoger)
        //        {
        //            active_Player = false;
        //            enemy_Image.sprite = enemy_character[i].expressions[int.Parse(expression)].photo;                    
        //        }
        //    }
        //}
        if (active_Player)
            player_Name.text = p_Name;
        else
            player_Name.text = e_Name;
    }

}
