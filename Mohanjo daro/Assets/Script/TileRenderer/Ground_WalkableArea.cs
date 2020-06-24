using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_WalkableArea : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
