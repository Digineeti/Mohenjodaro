using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayershorterRoot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ScenePlayer")
        {
            gameObject.transform.parent.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
    }
}
