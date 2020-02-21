using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertStartPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerMovement thePlayer;
    public GameObject []Starting_Positions;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();
        //if (gameObject.name == "ExitCave")
       
        for (int i = 0; i < Starting_Positions.Length; i++)
        {
            if (StartPointGlobalData.Scene== Starting_Positions[i].gameObject.name)
            {
                thePlayer.transform.position = Starting_Positions[i].transform.position;
                StartPointGlobalData.Scene = null;
            }               
        }      
        thePlayer.lastMove = new Vector2(0f,1f);
    }   
}
