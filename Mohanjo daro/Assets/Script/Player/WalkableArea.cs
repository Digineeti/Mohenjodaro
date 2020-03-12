using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WalkableArea : MonoBehaviour
{
    public Tilemap Base;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Base.GetComponent<CompositeCollider2D>().isTrigger=true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Base.GetComponent<CompositeCollider2D>().isTrigger=false;
    }
}
