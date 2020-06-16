using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever_event_Manager : MonoBehaviour
{

    public Lever_event[] event_Depend_on;
    bool val;
    //public GameObject hidden_Path_transition;
    //cutscene 
    public GameObject the_Main_Camera;
    public GameObject cut_scene_Camera;
    bool cutscene_play;
    // Start is called before the first frame update
    void Start()
    {
        //hidden_Path_transition.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {

        val = Check_all_Lever_Active();

        if (val && cutscene_play)
        {
            cutscene_play = false;
            //play the animation of hidden path && use the cut scene
            //hidden_Path_transition.SetActive(true);
            gameObject.GetComponent<Animator>().SetBool("active", true);
            the_Main_Camera.SetActive(false);
            cut_scene_Camera.SetActive(true);
            StartCoroutine(Play_CutScene());
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;

        }
        else if(!val)
        {           
            gameObject.GetComponent<Animator>().SetBool("active", false);          
        }
    }

    IEnumerator Play_CutScene()
    {
        yield return new WaitForSeconds(1.5f);
        the_Main_Camera.SetActive(true);
        cut_scene_Camera.SetActive(false);
    }

    protected bool Check_all_Lever_Active()
    {
        int count = 0;
        foreach (var item in event_Depend_on)
        {         
               
            if (!item.active)
            {
                count += 1;
            }
               
        }
        //Debug.Log(count);
        if (count > 0)
        {
            cutscene_play = true;
            return false;        
        }           
        else
        {
            return true;
        }
          
    }
}
