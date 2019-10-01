using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemSpawner : MonoBehaviour
{
    public int MaxNoOfEnemy;
    public int Melee = 0;
    public int Range = 0;
    public GameObject [] ActiveMelee;
    public GameObject [] ActiveRange;
    // Start is called before the first frame update
    void Start()
    {
    //step1:
        int value = Random.Range(1, MaxNoOfEnemy + 1);
        //Debug.Log(value);

        Melee = Random.Range(0, value);
        if(Melee==0)
        {           
            Range = Random.Range(1, value);
            if (Range > 3)
            {
                Range = 3;
            }
        }
        else
        {
            if (Melee > 3)
            {
                Melee = 3;
            }
            Range = Random.Range(0, value);
            if (Range > 3)
            {
                Range = 3;
            }
        }        
        //Range = value - Melee;        
        MeleeSpwanning();
        RangeSpwanning();
    }

    void MeleeSpwanning()
    {
        if (Melee == 0)
        {
            for(int i=0;i<ActiveMelee.Length;i++)
            {
                Destroy(ActiveMelee[i]);
            }
        }
        if (Melee == 1)
        {
            for (int i = 1; i < ActiveMelee.Length; i++)
            {
                Destroy(ActiveMelee[i]);
            }
        }
        if (Melee == 2)
        {
            for (int i = 2; i < ActiveMelee.Length; i++)
            {
                Destroy(ActiveMelee[i]);
            }
        }
    }

    void RangeSpwanning()
    {
        if (Range == 0)
        {
            for (int i = 0; i < ActiveRange.Length; i++)
            {
                Destroy(ActiveRange[i]);
            }
        }
        if (Range == 1)
        {
            for (int i = 1; i < ActiveRange.Length; i++)
            {
                Destroy(ActiveRange[i]);
            }
        }
        if (Range == 2)
        {
            for (int i = 2; i < ActiveRange.Length; i++)
            {
                Destroy(ActiveRange[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
