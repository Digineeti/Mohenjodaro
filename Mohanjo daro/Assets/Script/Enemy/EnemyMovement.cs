using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject[] lieutenant;
    private int lieutenant_count;
    public int count_check;

    public int dialogue_StartLine;
    public int dialogue_EndLine;
    bool trigger_Active;
    #endregion
    #region random_movement

   
    #endregion
   
    void Start()
    {
        RD= GetComponent<Rigidbody2D>();
        amin = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        #region enemy_Horiontal_Movement
        
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
        try
        {
            GameObject dialoguebar = GameObject.Find("MainDialogueSystem");
            gameObject.GetComponent<RPGTalkArea>().rpgtalkTarget = dialoguebar.GetComponent<RPGTalk>();
            gameObject.GetComponent<RPGTalkArea>().lineToStart = dialogue_StartLine.ToString();
            gameObject.GetComponent<RPGTalkArea>().lineToBreak = dialogue_EndLine.ToString();
        }
        catch (System.Exception)
        {

          
        }
        //if(trigger_Active)
        //{
        //    trigger_Active = false;
           

        //}


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
            //SceneManager.LoadSceneAsync("Dialogue", LoadSceneMode.Additive);
            StartCoroutine(Trigger_Event());
           
            //var objs = from GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)) where go.scene.name == sceneName select go;
            //SceneManager.GetSceneByBuildIndex(sceneIndex).GetRootGameObjects();

            //GameObject dialoguebar = GameObject.Find("MainDialogueSystem");
           
           
            
            //dialoguebar.GetComponent<RPGTalk>().lineToStart=gameObject.GetComponent<RPGTalk>()

            //Search_the_Lieutenant();
            //Rearrange_the_dialogue_Sequence();


           

            //GameObject dialoguebar = GameObject.Find("MainDialogueSystem");
            //if (dialoguebar.transform.GetChild(3).gameObject.activeSelf)
            //{

            //}
            //else
            //{
            //    //destroyed the enemy after talk.

            //    Destroy(gameObject, 1f);
            //}
            //new code for dialogue system...



        }
        //enemy ai movement script ....goes here 

    }

  
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, look_Radius);
    }


    protected void Search_the_Lieutenant()
    {
        lieutenant = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < lieutenant.Length; i++)
        {
            // find the number of lieutenant in the scene..
            if (lieutenant[i].name == "Lieutenant")
                lieutenant_count++;
        }
    }
    protected void Rearrange_the_dialogue_Sequence()
    {
        //change the talk line number as par the sequence 
        if (gameObject.name == "Lieutenant" && lieutenant_count == 3)
        {
            gameObject.GetComponent<RPGTalkArea>().lineToStart = "35";
            gameObject.GetComponent<RPGTalkArea>().lineToBreak = "36";
            count_check--;
        }
        if (gameObject.name == "Lieutenant" && lieutenant_count == 2)
        {
            gameObject.GetComponent<RPGTalkArea>().lineToStart = "38";
            gameObject.GetComponent<RPGTalkArea>().lineToBreak = "39";
            count_check--;
        }
        if (gameObject.name == "Lieutenant" && lieutenant_count == 1)
        {
            gameObject.GetComponent<RPGTalkArea>().lineToStart = "41";
            gameObject.GetComponent<RPGTalkArea>().lineToBreak = "46";
            count_check--;
        }
    }

    IEnumerator Trigger_Event()
    {
        //yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Dialogue", LoadSceneMode.Additive);
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("Dialogue"));
        yield return new WaitForEndOfFrame();
        trigger_Active = true;

    }
}
