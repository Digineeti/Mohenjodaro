using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]
[CreateAssetMenu(fileName ="En_ScriptableUI", menuName ="EnemyUI")]
public class En_ScriptableUI :ScriptableObject
{
    public string Name;                     //player name    
    public string Level;                       //player level 
    public float HPMax;                       //player Max Health Point   
    public float Exp;                         //player Initial Exprience Point  
    public float ATK;                         //player Attack
    public float DEF;                         //player Defence
    public float MAT;                         //player Magic Attack
    public float MDF;                         //player Magic Defence
    public float AGI;                         //player Agility
    public float Luk;                         //player Luck
}
