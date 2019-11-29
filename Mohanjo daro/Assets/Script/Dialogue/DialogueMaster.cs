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
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Animator animator;
    public GameObject Dialoguebox;

    private Queue<string> sentences;

    public Sprite[] LeftPlayerContainer;
    public Sprite[] RightPlayerContainer;

    public Image leftPlayer;
    public Image RightPlayer;
    bool stop_Next;

    public Text DialogueBackLog;   
    public GameObject DialogueLog;
    public Scrollbar Scroll;
    private bool Auto_play;
    private bool scrolldown;
    private float counter;

    void Start()
    {
        PlayerPrefs.DeleteKey("Dialogue");
        //DialogueBackLog.text = PlayerPrefs.GetString("Dialogue");
        //DialogueLog.SetActive(true);
        //Scroll.value = 0;
        stop_Next = false;
        sentences = new Queue<string>(); 
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
            int index = sentence.ToString().IndexOf(":");
            if (PlayerPrefs.HasKey("Dialogue"))
            {
                string Dialogue = PlayerPrefs.GetString("Dialogue");
                Dialogue += "[" + sentence.ToString().Substring(0, index) + "]" + "\n";
                Dialogue += sentence.ToString().Substring(index + 1, sentence.ToString().Length - (index + 1)) + "\n\n";

                PlayerPrefs.SetString("Dialogue", Dialogue);
            }
            else
            {
                PlayerPrefs.SetString("Dialogue", "[" + sentence.ToString().Substring(0, index) + "]" + "\n" + sentence.ToString().Substring(index + 1, sentence.ToString().Length - (index + 1)) + "\n\n");
            }

            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));

            //saving the dialogue data in the file with the name of palyer and the dialogue.....
            //string destination = Application.persistentDataPath + "/DialogueLog.dat";
            //FileStream file;

            //if (File.Exists(destination)) file = File.OpenWrite(destination);
            //else file = File.Create(destination);

            //DialogueData data = new DialogueData(nameText.text, dialogueText.text);
            
            //BinaryFormatter bf = new BinaryFormatter();
            //bf.Serialize(file, data);
            //file.Close();


        }
    }

    IEnumerator TypeSentence(string sentence)
    {
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
        scrolldown=true;
        DialogueLog.SetActive(true);
        DialogueBackLog.text= PlayerPrefs.GetString("Dialogue");
        //Debug.Log(dialogue);
        //string destination = Application.persistentDataPath + "/DialogueLog.dat";
        //FileStream file;

        //if (File.Exists(destination)) file = File.OpenRead(destination);
        //else
        //{
        //    Debug.LogError("File not found");
        //    return;
        //}

        //BinaryFormatter bf = new BinaryFormatter();
        //DialogueData data = (DialogueData)bf.Deserialize(file);
        //file.Close();


        //Debug.Log(data.name);      
        //Debug.Log(data.Dialogue);
    }   
    public void Close_Dialogue_Log()
    {       
        DialogueLog.SetActive(false);
    }

    public void Auto_click()
    {
        Auto_play = true;
    }

    public void Skip_Button()
    {

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




    //saving using the data dictionary.....

    //public static DialogueMaster Instance()
    //{
    //    if (dialogueMaster == null)
    //    {
    //        dialogueMaster = new DialogueMaster();
    //    } // end if

    //    return dialogueMaster;
    //} // end public static FriendsInformation Instance()

    //private DialogueMaster()
    //{
    //    // Create a Dictionary to store friends at runtime
    //    this.dialogueDictionary = new Dictionary<string, DialogueData>();
    //    this.formatter = new BinaryFormatter();
    //} // end private FriendsInformation()

    //public void AddFriend(string name, string email)
    //{
    //    // If we already had added a friend with this name
    //    if (this.dialogueDictionary.ContainsKey(name))
    //    {
    //        Debug.Log("You had already added " + name + " before.");
    //    }
    //    // Else if we do not have this friend details 
    //    // in our dictionary
    //    else
    //    {

    //        // Add him in the dictionary
    //        this.dialogueDictionary.Add(name, new DialogueData(name, email));
    //        //Console.WriteLine("Friend added successfully.");
    //    } // end if
    //} // end public bool AddFriend(string name, string email)

    //public void Save()
    //{
    //    // Gain code access to the file that we are going
    //    // to write to
    //    try
    //    {
    //        // Create a FileStream that will write data to file.
    //        FileStream writerFileStream =
    //            new FileStream(DATA_FILENAME, FileMode.Create, FileAccess.Write);
    //        // Save our dictionary of friends to file
    //        this.formatter.Serialize(writerFileStream, this.dialogueDictionary);

    //        // Close the writerFileStream when we are done.
    //        writerFileStream.Close();
    //    }
    //    catch (Exception)
    //    {
    //        //Console.WriteLine("Unable to save our friends' information");
    //    } // end try-catch
    //} // end public bool Load()

    //public void Load()
    //{

    //    // Check if we had previously Save information of our friends
    //    // previously
    //    if (File.Exists(DATA_FILENAME))
    //    {

    //        try
    //        {
    //            // Create a FileStream will gain read access to the 
    //            // data file.
    //            FileStream readerFileStream = new FileStream(DATA_FILENAME,
    //                FileMode.Open, FileAccess.Read);
    //            // Reconstruct information of our friends from file.
    //            this.dialogueDictionary = (Dictionary<String, DialogueData>)
    //                this.formatter.Deserialize(readerFileStream);
    //            // Close the readerFileStream when we are done
    //            readerFileStream.Close();

    //        }
    //        catch (Exception)
    //        {
    //            Console.WriteLine("There seems to be a file that contains " +
    //                "friends information but somehow there is a problem " +
    //                "with reading it.");
    //        } // end try-catch

    //    } // end if

    //} // end public bool Load()

    //public void Print()
    //{
    //    // If we have saved information about friends
    //    if (this.dialogueDictionary.Count > 0)
    //    {
    //        //Console.WriteLine("Name, Email");
    //        foreach (DialogueData friend in this.dialogueDictionary.Values)
    //        {
    //            Debug.Log(friend.name + ", " + friend.Dialogue);
    //        } // end foreach
    //    }
    //    else
    //    {
    //        Console.WriteLine("There are no saved information about your friends");
    //    } // end if
    //} // end public void Print()
}
