using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueData 
{    
    public string name;
    public string Dialogue;

    public DialogueData(string nameStr, string DialogueStr)
    {       
        name = "["+nameStr+"]";
        Dialogue = DialogueStr + "\n";
    }
}
