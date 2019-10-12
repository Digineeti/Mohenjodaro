using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueEnemy : MonoBehaviour
{
    private GameObject[] spawanHero;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        spawanHero = GameObject.FindGameObjectsWithTag("Player");
        for (int i=0;i<spawanHero.Length;i++)
        {
            GameObject[] CompEnemy;
            CompEnemy = GameObject.FindGameObjectsWithTag("Player");
            int count = 0;
            for(int j=0;j<CompEnemy.Length;j++)
            {
                if(spawanHero[i].name==CompEnemy[j].name)
                {
                    count++;

                    if(count==2)
                    {
                        //first 
                        CompEnemy[j].gameObject.name = spawanHero[i].name + "first";
                    }
                    if(count==3)
                    {
                        //second
                        CompEnemy[j].gameObject.name = spawanHero[i].name + "Second";

                    }
                }
            }
          
        }
       
    }
}
