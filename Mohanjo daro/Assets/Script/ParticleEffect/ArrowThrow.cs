using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowThrow : MonoBehaviour
{

    public Transform fireblast;
    public GameObject[] Arrow;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "Player")
        {
            Debug.Log(collision.name);
            Instantiate(fireblast, collision.transform.position, collision.transform.rotation);
            Destroy(gameObject);
        }
       
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Instantiate(fireblast, collision.transform.position, collision.transform.rotation);
    //}
    private void Update()
    {
        Arrow = GameObject.FindGameObjectsWithTag("Arrow");
        for (int i = 0; i < Arrow.Length; i++)
        {
            float step = 35f * Time.deltaTime; // calculate distance to move

            Arrow[i].transform.position = Vector3.MoveTowards(transform.position, Globalvariable.TargetPosition[i], step);
            //Globalvariable.TargetPosition[i] = new Vector3(0,0,0);
        }





    }
}
