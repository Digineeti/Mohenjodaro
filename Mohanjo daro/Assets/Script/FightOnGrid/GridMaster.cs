using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridMaster : MonoBehaviour
{

    public GameObject[] spawanHero;
    //private int maxmove = 3;
    public GameObject[] Grids;
    private void Start()
    {
         
    }

    private void Update()
    {
        spawanHero = GameObject.FindGameObjectsWithTag("Player");
        for(int i=0;i<spawanHero.Length;i++)
        {
            try
            {
                if (spawanHero[i].GetComponent<PA>().state.ToString() == "waitingforinput")
                {
                    //let move posiiblities 3;
                    //add global variable to set the player position..4,2

                   if(spawanHero[i].name== "Indra")
                    {

                        //for loop for possible move count 
                        //x+j/x-j
                        //horizontally and vertical
                        //y+j/y-j
                        //vertically
                        //row -1//row+1(j-1)
                        //row-2//row+2(j-2)
                        //row-3//row+3(j-3)
                        Grids[18].GetComponent<SpriteRenderer>().color = Color.black;
                        Grids[25].GetComponent<SpriteRenderer>().color = Color.black;
                        Grids[32].GetComponent<SpriteRenderer>().color = Color.black;
                        Grids[39].GetComponent<SpriteRenderer>().color = Color.black;
                        Grids[11].GetComponent<SpriteRenderer>().color = Color.black;
                        Grids[4].GetComponent<SpriteRenderer>().color = Color.black;
                        //Grids[18].GetComponent<SpriteRenderer>().color = Color.black;
                        //Grids[18].GetComponent<SpriteRenderer>().color = Color.black;
                    }
                }
            }
            catch (System.Exception)
            {

             
            }
        }
       
    }


}
