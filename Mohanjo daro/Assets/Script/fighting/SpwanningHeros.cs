using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpwanningHeros : MonoBehaviour
{
    public GameObject Player; 
    public float PlayerScale=0.5f; 
  
    
    void Start()
    {
       //Player.GetComponent<PlayerAction>().state = PlayerAction.State.busy;
        Player = Instantiate(Player, gameObject.transform.position, Quaternion.identity);
        int id = Player.name.IndexOf("(");
        Player.name = Player.name.Substring(0, id);
        Player.transform.Rotate(0f, 180f, 0f, Space.Self); // change y to 0 from 180
        Player.transform.localScale = new Vector3(PlayerScale, PlayerScale, 1);
    }
    private void Update()
    {
        
    }


}
