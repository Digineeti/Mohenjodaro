using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]
[CreateAssetMenu(fileName = "InventoryScriptable", menuName = "InventoryObject")]
public class InventoryScriptable : ScriptableObject
{
    //effect on the player attribute
    public float attack;
    public float defence;
    public float experience;    

}
