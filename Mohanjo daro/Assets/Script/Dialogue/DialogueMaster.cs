using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[SerializeField]
public class DialogueMaster:MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Animator animator;
    public GameObject Dialoguebox;

    private Queue<string> sentences;
    private Queue<string> names;

    // Use this for initialization
    void Start()
    {
        //animator.SetBool("IsOpen", false);
        //Dialoguebox.SetActive(false);
        sentences = new Queue<string>(); names = new Queue<string>();
    }
    int activeDialogue = 0;
    public void StartDialogue(Dialogue dialogue)
    {
        //animator.SetBool("IsOpen", true);
        activeDialogue = 1;
      
        
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            names.Enqueue(sentence);
            int index = sentence.ToString().IndexOf(":");
            //nameText.text = sentence.ToString().Substring(0, index);           
            sentences.Enqueue(sentence.ToString().Substring(index + 1, sentence.ToString().Length - (index + 1)));

            //dialogueText.text = sentence.ToString().Substring(index + 1, sentence.ToString().Length - (index + 1));
        }
        DisplayNextSentence();
    }
    private void Update()
    {
        if(activeDialogue>0)
        {
            Dialoguebox.SetActive(true);
        }
        else
        {
            Dialoguebox.SetActive(false);
        }
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue(); 
        string Name= names.Dequeue();
        int index = Name.ToString().IndexOf(":");
        nameText.text = Name.ToString().Substring(0, index);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        //animator.SetBool("IsOpen", false);
        activeDialogue = 0;
        Dialoguebox.SetActive(false);
    }
}
