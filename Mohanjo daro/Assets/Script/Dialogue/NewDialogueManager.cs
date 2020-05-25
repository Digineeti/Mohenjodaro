using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using UnityEditor;

[SerializeField]

public class NewDialogueManager : MonoBehaviour
{
    
   

    [Header("Dialogue start ")]
    public int startLine;
    public int endLine=10;


    [Header("dialogue Content")]
    private string nameText;
   
    [Header("Dialogue conversation Player Image")]
    public Sprite[] LeftPlayerContainer;
    
    //[Header("Action properties")]
    string fileName = "Dialogue.txt";


    void Start()
    {
        string[] lines = System.IO.File.ReadAllLines(fileName);

        string name = lines[startLine];
        List<string> dialogue = new List<string>();
        
        Debug.Log(name);
    }
    private void Update()
    {

    }

    protected List<string> dialogue()
    {
        List<string> dialogue = new List<string>();

        return dialogue;
    }

   

}
