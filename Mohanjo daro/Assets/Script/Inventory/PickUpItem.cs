using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
                if (Inventory.IsFull[i] == false)
                {
                    Inventory.IsFull[i] = true;
                    Instantiate(ItemsAction, Inventory.Slots[i].transform, false);
                    TMP_Text Counter = Inventory.Slots[i].GetComponentInChildren<TMP_Text>();                   
                    Counter.text = 1.ToString();
                    Destroy(gameObject);
                    break;

                }
                else
                {
                    if (gameObject.name == Inventory.Slots[i].gameObject.transform.GetChild(1).name || gameObject.name+ "(Clone)" == Inventory.Slots[i].gameObject.transform.GetChild(1).name)
                    {
                        //add the item in the list ..... 
                        TMP_Text Counter = Inventory.Slots[i].GetComponentInChildren<TMP_Text>();
                        int NewValue = int.Parse(Counter.text)+1;
                        Counter.text = NewValue.ToString();
                        Destroy(gameObject);
                        break;

                    }
                }
               
               
               

            }
        }
    }

}
