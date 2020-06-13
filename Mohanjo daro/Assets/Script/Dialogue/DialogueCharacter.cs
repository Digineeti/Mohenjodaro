using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Dialogue", menuName = "DialogueScriptableObjects/Characters", order = 1)]
public class DialogueCharacter : ScriptableObject
{

    [Header("Dialogue conversation Player Image")]
    public string dialoger;   
    public Sprite photo;


    public Expression[] expressions;
    // Start is called before the first frame update
    [System.Serializable]
    public class Expression
    {
        //public string name;
        public GameObject photo;
        public Material material;      
        //public string boolInAnimator;
        // AudioClip audio;
    }
}
