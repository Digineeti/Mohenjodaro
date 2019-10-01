using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GameObject enemy;
    public GameObject midPoint;
    public Rigidbody2D RD;
    private Animator amin;
    private bool flip;

    //amin.SetFloat("MoveX", input.horizontal);
    //amin.SetFloat("MoveY", input.vertical);
    //amin.SetBool("PlayerMoving", playerMoving);
    //amin.SetFloat("LastMoveX", lastMove.x);
    //amin.SetFloat("LastMoveY", lastMove.y);
    // Start is called before the first frame update
    void Start()
    {
        RD= GetComponent<Rigidbody2D>();
        amin = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.transform.position.x <= midPoint.transform.position.x+5 && flip)
        {
          
                RD.velocity = new Vector2(3f, 0f);
                amin.SetFloat("MoveX", 3f);
                //movement 
           
            //move in positive direction
        }
        else
        {
            if(flip==true)
            {
                enemy.transform.localScale.Scale(new Vector3(-1,0,0));
            }
            flip = false;
            if(enemy.transform.position.x <= midPoint.transform.position.x - 5 )
            {
                flip = true;
                enemy.transform.localScale.Scale(new Vector3(-1, 0, 0));
            }

            
            RD.velocity = new Vector2(-3f, 0f);
            amin.SetFloat("MoveX", -3f);
            //call negative mov

        }
        //else if (enemy.transform.position.x > midPoint.transform.position.x - 10)
        //{
        //    Debug.Log("Negative");
        //    if (enemy.transform.position.x <= midPoint.transform.position.x)
        //    {
        //        //flip()
        //    }
        //    else
        //    {
        //        //movement 
        //    }
        //}
        //positive motion
    }
   
}
