using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCevents : MonoBehaviour
{
    private Rigidbody2D RD;
    public enum NPCType
    {
        horiontalRight,
        horiontalLeft,
        verticalUp,
        verticalDown,
        ideal,
    }
    public NPCType type;

    private bool moving;
    float start_Time = 0;
    float end_Time = 0;
    public int dialogue_StartLine;
    public int dialogue_EndLine;
    // Start is called before the first frame update
    void Start()
    {
        RD = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //int val = Random.Range(0,4);
        //if (val == 0)
        //{
        //    type = NPCType.horiontalRight;
        //}
        //else if(val==1)
        //{
        //    type = NPCType.verticalUp;
        //}
        //else if(val==3)
        //{
        //    type = NPCType.verticalDown;
        //}
        //else
        //{
        //    type = NPCType.horiontalLeft;
        //}
        //if (type.ToString() == "horiontalRight")
        //{
        //    RD.velocity = new Vector2(2f, 0f);          
        //}     
        //if (type.ToString() == "verticalUp")
        //{
        //    RD.velocity = new Vector2(0f, 2f);         
        //}
        //if (type.ToString() == "horiontalLeft")
        //{
        //    RD.velocity = new Vector2(-2f, 0f);
        //}
        //if (type.ToString() == "verticalDown")
        //{
        //    RD.velocity = new Vector2(0f, -2f);
        //}
    }

    IEnumerator Trigger_Event()
    {
        SceneManager.LoadScene("DialogueNPC", LoadSceneMode.Additive);
        yield return new WaitForEndOfFrame();      

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ScenePlayer")
        {

            //if (type.ToString() == "horiontal")
            //{
            //    RD.velocity = new Vector2(0f, 0f);
            //    //amin.SetBool("EnemyMoving", true);
            //    //amin.SetFloat("MoveX", 1f);
            //}
            //if (type.ToString() == "vertical")
            //{
            //    RD.velocity = new Vector2(0f, 0f);
            //    //amin.SetFloat("FaceY", -1f);
            //    //amin.SetBool("EnemyMoving", false);
            //}
            Globalvariable.Dialogue_Open = true;           
            StartCoroutine(Trigger_Event());
        }
    }
}
