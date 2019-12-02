using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private Inventory Inventory;
    public GameObject ItemsAction;
    // Start is called before the first frame update
   private  void Start()
    {
        Inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            for (int i = 0; i < Inventory.Slots.Length; i++)
            {
                if(Inventory.IsFull[i]==false)
                {
                    Inventory.IsFull[i] = true;
                    Instantiate(ItemsAction, Inventory.Slots[i].transform,false);
                    Destroy(gameObject);
                    break;

                }
            }
        }
    }

}
