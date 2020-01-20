using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowThrow : MonoBehaviour
{

    public Transform fireblast;
    public GameObject[] Arrow;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Globalvariable.TargetName.Length ==1)
        {
            if (collision.name == Globalvariable.TargetName[0])
            {
                Debug.Log(collision.name);
                Instantiate(fireblast, collision.transform.position, collision.transform.rotation);
                Destroy(gameObject);
            }
        }
        if (Globalvariable.TargetName.Length ==2)
        {
            if (collision.name == Globalvariable.TargetName[0]|| collision.name == Globalvariable.TargetName[1])
            {
                Debug.Log(collision.name);
                Instantiate(fireblast, collision.transform.position, collision.transform.rotation);
                Destroy(gameObject);
            }
        }
        if (Globalvariable.TargetName.Length ==3)
        {
            if (collision.name == Globalvariable.TargetName[0] || collision.name == Globalvariable.TargetName[1]|| collision.name == Globalvariable.TargetName[2])
            {
                Debug.Log(collision.name);
                Instantiate(fireblast, collision.transform.position, collision.transform.rotation);
                Destroy(gameObject);
            }

        }
        if (Globalvariable.TargetName.Length ==4)
        {
            if (collision.name == Globalvariable.TargetName[0] || collision.name == Globalvariable.TargetName[1] || collision.name == Globalvariable.TargetName[2] || collision.name == Globalvariable.TargetName[3])
            {
                Debug.Log(collision.name);
                Instantiate(fireblast, collision.transform.position, collision.transform.rotation);
                Destroy(gameObject);
            }
        }
        if (Globalvariable.TargetName.Length ==5)
        {
            if (collision.name == Globalvariable.TargetName[0] || collision.name == Globalvariable.TargetName[1] || collision.name == Globalvariable.TargetName[2] || collision.name == Globalvariable.TargetName[3] || collision.name == Globalvariable.TargetName[4])
            {
                Debug.Log(collision.name);
                Instantiate(fireblast, collision.transform.position, collision.transform.rotation);
                Destroy(gameObject);
            }
        }
        if (Globalvariable.TargetName.Length ==6)
        {
            if (collision.name == Globalvariable.TargetName[0] || collision.name == Globalvariable.TargetName[1] || collision.name == Globalvariable.TargetName[2] || collision.name == Globalvariable.TargetName[3] || collision.name == Globalvariable.TargetName[4] || collision.name == Globalvariable.TargetName[5])
            {
                Debug.Log(collision.name);
                Instantiate(fireblast, collision.transform.position, collision.transform.rotation);
                Destroy(gameObject);
            }
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
