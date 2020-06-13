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
    public float look_Radius;
    public Transform traget;
    public float speed;
    public enum enemytype
    {
        horiontal,
        vertical,
        ideal,      
    }
    public enemytype type;
    #endregion
    #region random_movement

    //public float timer;
    //public int newtarget;    
    //public Vector2 target;

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
        if (Globalvariable.Dialogue_Open == false)
        {
            float distance = Vector2.Distance(traget.position, transform.position);
            if (distance < look_Radius)
            {
                if(type.ToString()== "horiontal")
                {
                    RD.velocity = new Vector2(2f, 0f);
                    amin.SetBool("EnemyMoving", true);
                    amin.SetFloat("MoveX", 2f);
                }
                if(type.ToString() == "vertical")
                {
                    RD.velocity = new Vector2(0f, -2f);
                    amin.SetBool("EnemyMoving", true);
                    amin.SetFloat("MoveY", -2f);
                }
                if(type.ToString() == "ideal")
                {
                    RD.velocity = new Vector2(0f, 0f);
                    amin.SetBool("EnemyMoving", false);
                    amin.SetFloat("MoveY", -2f);
                }
               
               
                //apply the trigonomatric eqution to find the path in horizontal and vertical way ...

                //float h = distance;

                //float x = Mathf.Cos(60) * h;
                //float y = Mathf.Sin(30) * h;




            }
        }
        #endregion
        //timer += Time.deltaTime;
        //if(timer>= newtarget)
        //{
        //    searchtarget();
        //    timer = 0;

        //}
    }

    void searchtarget()
    {
        //float myx = gameObject.transform.position.x;
        //float myy = gameObject.transform.position.y;
        //float xpos = myx + Random.Range(myx - 5, myx + 5);
        //float ypos = myy + Random.Range(myy - 5, myy + 5);
        //target = new Vector2(xpos, gameObject.transform.position.y);

        //RD.velocity = new Vector2(target.x, speed);
        



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="ScenePlayer")
        {

            if (type.ToString() == "horiontal")
            {
                RD.velocity = new Vector2(0f, 0f);
                amin.SetBool("EnemyMoving", true);
                amin.SetFloat("MoveX", 1f);
            }
            if (type.ToString() == "vertical")
            {
                RD.velocity = new Vector2(0f, 0f);
                amin.SetFloat("FaceY", -1f);
                amin.SetBool("EnemyMoving", false);
            }
           
            
            Globalvariable.Dialogue_Open = true;

            GameObject dialoguebar = GameObject.Find("MainDialogueSystem");
            if (dialoguebar.transform.GetChild(3).gameObject.activeSelf)
            {
               
            }
            else
            {               
                    Destroy(gameObject,1f);
            }

        }
        //enemy ai movement script ....goes here 

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.CompareTag("ScenePlayer"))
    //        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    //    else
    //    {

    //    }
    //}
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, look_Radius);
    }
}
