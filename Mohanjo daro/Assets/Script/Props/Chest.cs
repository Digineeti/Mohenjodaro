using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
    {

    
    private bool chest_activation_section;
    //
    public int receive_item_count;
    public GameObject[] items_prefab;
    bool item_receive;

    [HideInInspector] public bool enter;

    GameObject player;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ScenePlayer")
        {
            chest_activation_section = true;
            player = collision.gameObject;
        }
    }
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    chest_activation_section = false;

    //}

    private void Update()
    {
       
        //check the chest from the list of array in the save data 
        /* if chest exists in the save list then set the animation to active mode else not*/
        if (chest_activation_section)
        {
           
            enter = enter || Input.GetButtonDown("ActionEnter");
            if (enter)
            {                
                gameObject.GetComponent<Animator>().SetBool("active", true);
                    
            }
            if (gameObject.GetComponent<Animator>().GetBool("active") && Input.GetKeyDown(KeyCode.G))
            {
                gameObject.GetComponent<Animator>().SetBool("Grabgold", true);
                Globalvariable.Gold = player.GetComponent<PlayerMovement>().GetGold() + receive_item_count;
                player.GetComponent<PlayerMovement>().SetGold(Globalvariable.Gold);
            }
        }

    }

    
}
