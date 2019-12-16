using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

[SerializeField]
public class DialogueMaster:MonoBehaviour
{
    [Header("dialogue Content")]
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Animator animator;
    public GameObject Dialoguebox;
    private Queue<string> sentences;
    [Header("Dialogue conversation Player Image")]
    public Sprite[] LeftPlayerContainer;
    public Sprite[] RightPlayerContainer;
    public Image leftPlayer;
    public Image RightPlayer;
    bool stop_Next;

    public Text DialogueBackLog;   
    public GameObject DialogueLog;
    public Scrollbar Scroll;
    [Header("Action properties")]
    private bool Auto_play;
    private bool scrolldown;
    private float counter;
    private bool Skip;
    private bool skip_Active;

    private bool IsDialogueOpen;
    //save the dialogue in file....
    string  fileName = "Dialogue.txt";
    

    void Start()
    {
        PlayerPrefs.DeleteKey("Dialogue");
        //DialogueBackLog.text = PlayerPrefs.GetString("Dialogue");
        //DialogueLog.SetActive(true);
        //Scroll.value = 0;
        stop_Next = false;
        sentences = new Queue<string>();

        //reading the dialogue.....
        

        //save the dialogue in file ....
        if (File.Exists(fileName))
        {
            Debug.Log(fileName + " already exists.");
            return;
        }
        var sr = File.CreateText(fileName);
        //sr.WriteLine("This is my file.");
        //sr.WriteLine("I can write ints {0} or floats {1}, and so on.",
        //    1, 4.2);
        //sr.Close();

       

    }
    int activeDialogue = 0;
    public void StartDialogue(Dialogue dialogue)
    {
        //animator.SetBool("IsOpen", true);
        Globalvariable.Dialogue_Open = true;
        activeDialogue = 1;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            int index = sentence.ToString().IndexOf(":");
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    private void Update()
    {
        if (Skip == true)
            Auto_play = true;

        if (activeDialogue>0)
        {
            Dialoguebox.SetActive(true);            
        }
        else
        {
            Dialoguebox.SetActive(false);           
        }
        if(Auto_play==true)
        {
            DisplayNextSentence();
        }
        counter += Time.deltaTime;
        if (scrolldown == true)
        {
            Scroll.value = 0;
            if (counter > 5)
            {                
                scrolldown = false;
            }
        }

        if(Globalvariable.Dialogue_Open==true)
        {
            //not working when press enter key...
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                DisplayNextSentence();
            }

        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (IsDialogueOpen == false)
                Open_Dialogue_Log();
            else
                Close_Dialogue_Log();

        }


        //if (counter < 5)
        //{
        //    var sw = new StreamWriter(fileName,true);
        //    sw.WriteLine(counter);
        //    sw.Close();

        //}
        //if (File.Exists(fileName))
        //{
        //    var srr = File.OpenText(fileName);
        //    var line = srr.ReadLine();
        //    while (line != null)
        //    {
        //        Debug.Log(line); // prints each line of the file
        //        line = srr.ReadLine();
        //    }
        //    srr.Close();
        //}


    }

    public void DisplayNextSentence()
    {
        if (stop_Next == false)
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
            string sentence = sentences.Dequeue();           

            //save the dialogue in the text file ..
           
            //if (PlayerPrefs.HasKey("Dialogue"))
            //{
            //    string Dialogue = PlayerPrefs.GetString("Dialogue");
            //    Dialogue += "[" + sentence.ToString().Substring(0, index) + "]" + "\n";
            //    Dialogue += sentence.ToString().Substring(index + 1, sentence.ToString().Length - (index + 1)) + "\n\n";

            //    PlayerPrefs.SetString("Dialogue", Dialogue);
            //}
            //else
            //{
            //    PlayerPrefs.SetString("Dialogue", "[" + sentence.ToString().Substring(0, index) + "]" + "\n" + sentence.ToString().Substring(index + 1, sentence.ToString().Length - (index + 1)) + "\n\n");
            //}
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

           
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        skip_Active = false;
        if (Skip == true)
        {
            if (File.Exists(fileName))
            {
                var srr = File.OpenText(fileName);
                var line = srr.ReadLine();
               
                while (line != null)
                {
                    line = srr.ReadLine();
                    if (line == sentence)
                    {
                        skip_Active = true;
                    }                  
                }
                srr.Close();
            }
            if (skip_Active == true)
            {
                nameText.color = Color.red;
                dialogueText.color = Color.red;
            }
            else
            {
                nameText.color = Color.white;
                dialogueText.color = Color.white;
                Skip = false;
                Auto_play = false;
            }
        }
       
        var sw = new StreamWriter(fileName, true);
        sw.WriteLine(sentence);
        sw.Close();

        dialogueText.text = "";
        int index = sentence.ToString().IndexOf(":");
        nameText.text = sentence.ToString().Substring(0, index);
        sentence = sentence.ToString().Substring(index + 1, sentence.ToString().Length - (index + 1));
        
        //AddFriend(nameText.text,sentence);

        if (nameText.text == "Gopal")
            leftPlayer.sprite = LeftPlayerContainer[0];
        else
            leftPlayer.sprite = LeftPlayerContainer[1];


        foreach (char letter in sentence.ToCharArray())
        {
            stop_Next = true;
            if (Input.GetMouseButtonDown(1))
            {
                dialogueText.text = sentence;
                sentence = "";
                stop_Next = false;
                goto Exit;
            }                
            else
                dialogueText.text += letter;
            yield return null;
        }
        stop_Next = false;
    Exit:
        yield return null;
    }

    public void EndDialogue()
    {
        //animator.SetBool("IsOpen", false);
        Globalvariable.Dialogue_Open = false;
        activeDialogue = 0;
        Dialoguebox.SetActive(false);
        //Disable auto play...
        Auto_play = false;
    }

    public void Open_Dialogue_Log()
    {
        //Scroll.value = -100; 
        IsDialogueOpen = !IsDialogueOpen;
        if (IsDialogueOpen == true)
        {
            scrolldown = true;
            DialogueLog.SetActive(true);
            if (File.Exists(fileName))
            {
                DialogueBackLog.text = "";
                var srr = File.OpenText(fileName);
                var line = srr.ReadLine();
                while (line != null)
                {

                    line = srr.ReadLine();
                    if (line == "" || line == null)
                    {
                    }
                    else
                    {
                        int index = line.ToString().IndexOf(":");
                        DialogueBackLog.text += "[" + line.ToString().Substring(0, index) + "]" + "\n" + line.ToString().Substring(index + 1, line.ToString().Length - (index + 1)) + "\n\n";
                    }
                }
                srr.Close();
            }
            else
            {
                Debug.Log("Could not Open the file: " + fileName + " for reading.");
                return;
            }
        }
        else {
            DialogueLog.SetActive(false);
        }
        
    }   

    public void Close_Dialogue_Log()
    {
        IsDialogueOpen = false;
        DialogueLog.SetActive(false);
    }

    public void Auto_click()
    {
        Auto_play = true;
    }

    public void Skip_Button()
    {
        Skip = true;
       
    }
    public void Hide_Button()
    {
        //Auto_play = true;
        if(activeDialogue == 0)
        {
            activeDialogue = 1;
        }
        else
        {
            activeDialogue = 0;
        }
    }

  
}
