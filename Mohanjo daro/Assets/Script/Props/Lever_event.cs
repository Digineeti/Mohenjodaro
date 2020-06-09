using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_event : MonoBehaviour
{
    public bool active;
    private bool lever_activation_section;
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ScenePlayer")
        {
            lever_activation_section = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        lever_activation_section = false;
    }

    private void Update()
    {
        if(lever_activation_section)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                active = !active;
                gameObject.GetComponent<Animator>().SetBool("active", active);
            }
        }
        
    }
}
