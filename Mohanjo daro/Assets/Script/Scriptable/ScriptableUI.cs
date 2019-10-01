using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]
[CreateAssetMenu(fileName ="ScriptableUI", menuName ="PlayerUI")]
public class ScriptableUI :ScriptableObject
{
    public string Name;                     //player name    
    public string Level;                    //player level 
    public int HPMax;                       //player Max Health Point
    public int SPMax;                       //player Max Special Point
    public float Exp;                       //player Initial Exprience Point  
    public int ATK;                         //player Attack
    public int DEF;                         //player Defence
    public int MAT;                         //player Magic Attack
    public int MDF;                         //player Magic Defence
    public int AGI;                         //player Agility
    public int Luk;                         //player Luck
    
}
