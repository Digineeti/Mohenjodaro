using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SelectAllTiles : MonoBehaviour
{
    void Start()
    {
        Tilemap tilemap = GetComponent<Tilemap>();

        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

        Debug.Log(allTiles.Length);

        for(int i=0;i<allTiles.Length;i++)
        {
           
        }
        //for (int x = 0; x < bounds.size.x; x++)
        //{
        //    for (int y = 0; y < bounds.size.y; y++)
        //    {
        //        TileBase tile = allTiles[x + y * bounds.size.x];
        //        if (tile != null)
        //        {
        //            Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name);
        //        }
        //        else
        //        {
        //            Debug.Log("x:" + x + " y:" + y + " tile: (null)");
        //        }
        //    }
        //}
    }
}
