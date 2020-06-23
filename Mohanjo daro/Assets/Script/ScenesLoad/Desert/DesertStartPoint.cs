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
      
    }

    private void LateUpdate()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();
        //if (gameObject.name == "ExitCave")

        for (int i = 0; i < Starting_Positions.Length; i++)
        {
            if (StartPointGlobalData.Scene == Starting_Positions[i].gameObject.name)
            {
                thePlayer.gameObject.transform.position = Starting_Positions[i].transform.position;
                StartPointGlobalData.Scene = null;
                thePlayer.lastMove = new Vector2(0f, 1f);
                //make the global variable for player face direction after every scene transition.
                //assign the global variable with the last face direction of the player while triggering the scene transition event..

            }
        }
       
    }
}
