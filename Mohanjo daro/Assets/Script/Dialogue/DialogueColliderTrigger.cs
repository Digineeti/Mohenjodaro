using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueColliderTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<DialogueMaster>().StartDialogue(dialogue);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        FindObjectOfType<DialogueMaster>().EndDialogue();       
    }

}

