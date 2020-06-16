using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_event : MonoBehaviour
{
    public bool active;
    private bool lever_activation_section;
    [HideInInspector] public bool enter;
    private void Start()
    {
        gameObject.GetComponent<Animator>().SetBool("active", active);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ScenePlayer")
        {
            lever_activation_section = true;
        }
    }
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    lever_activation_section = false;
    //}

    private void Update()
    {
        if(lever_activation_section)
        {
            enter = enter || Input.GetButtonDown("ActionEnter");
            if (enter)
            {
                active = true;
                gameObject.GetComponent<Animator>().SetBool("active", active);
            }
        }
        
    }
}
