using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapScript : MonoBehaviour
{
    private Transform Player;

    private void Start()
    {
        Player = GameObject.Find("Indra").transform;
    }

    private void LateUpdate()
    {
        if(Player==null)
        {
            Player = Globalvariable.NotDestroyed_Player.transform;
        }
        Vector3 newposition = Player.position;
        newposition.y = transform.position.y;
        newposition.z = -10f;
        transform.position = newposition;

        transform.rotation = Quaternion.Euler(0f, Player.transform.position.y,0f);
    }
}
