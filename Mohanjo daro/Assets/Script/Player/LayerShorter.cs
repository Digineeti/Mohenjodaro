using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerShorter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ScenePlayer")
        {
            gameObject.transform.parent.GetComponent<SpriteRenderer>().sortingOrder = 100;

           gameObject.transform.parent.GetComponent<SpriteRenderer>().color=new Color(1,1,1,0.6f);
            //tmp.a = 0f;
           //gameObject.transform.parent.GetComponent<SpriteRenderer>().color = tmp;

            // gameObject.transform.parent.GetComponent<SpriteRenderer>().sortingOrder = collision.GetComponent<SpriteRenderer>().sortingOrder - 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Color tmp = gameObject.transform.parent.GetComponent<SpriteRenderer>().color;
        tmp.a = 1f;
        gameObject.transform.parent.GetComponent<SpriteRenderer>().color = tmp;

    }
}
