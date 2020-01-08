using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private int stackSize;
    [SerializeField]
    private string  title;
    //[SerializeField]
    //private QualityLevel  quality;

}
