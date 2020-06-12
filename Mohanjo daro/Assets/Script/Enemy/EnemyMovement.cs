using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    #region movement_variable
    public GameObject enemy;
    public GameObject midPoint;
    private Rigidbody2D RD;
    private Animator amin;
    private bool flip;
    #endregion

    #region enemy_ineract_payer
    //public float look_Radius;
    //public Transform traget;

    #endregion

    //
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
        #region enemy_Horiontal_Movement
        //if (enemy.transform.position.x <= midPoint.transform.position.x + 5 && flip)
        //{

        //    RD.velocity = new Vector2(3f, 0f);
        //    amin.SetFloat("MoveX", 3f);
        //    //movement 

        //    //move in positive direction
        //}
        //else
        //{
        //    if (flip == true)
        //    {
        //        enemy.transform.localScale.Scale(new Vector3(-1, 0, 0));
        //    }
        //    flip = false;
        //    if (enemy.transform.position.x <= midPoint.transform.position.x - 5)
        //    {
        //        flip = true;
        //        enemy.transform.localScale.Scale(new Vector3(-1, 0, 0));
        //    }

        //    RD.velocity = new Vector2(-3f, 0f);
        //    amin.SetFloat("MoveX", -3f);
        //    //call negative mov

        //}

        #endregion
        #region move_toward_to_player
        //float distance = Vector2.Distance(traget.position,transform.position);
        //if(distance<look_Radius)
        //{

        //        RD.velocity = new Vector2(0f, -3f);
        //    amin.SetBool("EnemyMoving", true);
        //    amin.SetFloat("MoveY", -3f);
        //    if(distance<1)
        //    {
        //        RD.velocity = new Vector2(0f, 0f);
        //        amin.SetFloat("LastMoveY", -1f);
        //        amin.SetBool("EnemyMoving", false);
        //        Globalvariable.Dialogue_Open = true;
        //    }
        //}
        #endregion

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="ScenePlayer")
        {
            
            GameObject dialoguebar = GameObject.Find("MainDialogueSystem");
            if (dialoguebar.transform.GetChild(3).gameObject.activeSelf)
            {
               
            }
            else
            {               
                    Destroy(gameObject,3f);
            }

        }
        //enemy ai movement script ....goes here 

    }
    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, look_Radius);
    //}
}
