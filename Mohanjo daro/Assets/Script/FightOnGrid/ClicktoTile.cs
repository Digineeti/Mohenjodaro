using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicktoTile : MonoBehaviour
{
    public int tileX;
    public int tileY;
    public TileMapGrid map;

    void OnMouseUp()
    {
        Debug.Log("Click!");

        map.GeneratePathTo(tileX, tileY);
    }
}
