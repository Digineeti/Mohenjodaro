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
        thePlayer.transform.position = transform.position;
        thePlayer.lastMove = new Vector2(0f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
