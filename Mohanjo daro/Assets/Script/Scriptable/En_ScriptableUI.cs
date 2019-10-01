using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]
[CreateAssetMenu(fileName ="En_ScriptableUI", menuName ="EnemyUI")]
public class En_ScriptableUI :ScriptableObject
{
    public string Name;                     //player name    
    public int HPMax;                       //player Max Health Point   
    public int Exp;                         //player Initial Exprience Point  
    public int ATK;                         //player Attack
    public int DEF;                         //player Defence
    public int MAT;                         //player Magic Attack
    public int MDF;                         //player Magic Defence
    public int AGI;                         //player Agility
    public int Luk;                         //player Luck
}
