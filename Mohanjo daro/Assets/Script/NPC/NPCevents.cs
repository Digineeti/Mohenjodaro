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
    bool trigger_Active_Dialogue;
    // Start is called before the first frame update
    void Start()
    {
        RD = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger_Active_Dialogue)
        {

            trigger_Active_Dialogue = false;
            GameObject dialoguebar = GameObject.Find("MainDialogueSystem");
            dialoguebar.transform.position = gameObject.transform.position;
            if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + gameObject.name))
            {
                int val = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + gameObject.name);
                val += 1;
                if (val > dialogue_EndLine)
                    val = dialogue_EndLine;

                dialoguebar.GetComponent<RPGTalk>().lineToStart = val.ToString();
                dialoguebar.GetComponent<RPGTalk>().lineToBreak = val.ToString();
                dialoguebar.GetComponent<RPGTalk>().NewTalk();
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + gameObject.name, val);
            }
            else
            {
                dialoguebar.GetComponent<RPGTalk>().lineToStart = dialogue_StartLine.ToString();
                dialoguebar.GetComponent<RPGTalk>().lineToBreak = dialogue_StartLine.ToString();
                dialoguebar.GetComponent<RPGTalk>().NewTalk();
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + gameObject.name, dialogue_StartLine);
            }
        }


        
    }

    IEnumerator Trigger_Event()
    {
        SceneManager.LoadScene("DialogueNPC", LoadSceneMode.Additive);
        yield return new WaitForEndOfFrame();
        trigger_Active_Dialogue = true;

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
