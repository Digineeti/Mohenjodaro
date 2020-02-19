using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerMovement thePlayer;

    public GameObject []Starting_Positions;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();
        //if (gameObject.name == "ExitCave")
        int startingIndex = 0;
        for(int i=0;i<Starting_Positions.Length;i++)
        {
            if (StartPointGlobalData.Scene == Starting_Positions[i].gameObject.name)
                startingIndex = i;
        }
        thePlayer.transform.position = Starting_Positions[startingIndex].transform.position;
        if(startingIndex > 0)
        {
            StartPointGlobalData.Scene = null;
        }
        thePlayer.lastMove = new Vector2(0f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
