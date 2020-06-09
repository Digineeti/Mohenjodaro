using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    public bool active;
    private bool chest_activation_section;
    //
    public int receive_item_count;
    public GameObject[] items_prefab;


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ScenePlayer")
        {
            chest_activation_section = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        chest_activation_section = false;
    }

    private void Update()
    {
        if (chest_activation_section)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                active = !active;
                gameObject.GetComponent<Animator>().SetBool("active", active);
            }
        }

    }



}
