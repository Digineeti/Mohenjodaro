using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever_event_Manager : MonoBehaviour
{

    public Lever_event[] event_Depend_on;
    bool val;
    public GameObject hidden_Path_transition;
    //cutscene 
    public GameObject the_Main_Camera;
    public GameObject cut_scene_Camera;
    bool cutscene_play;
    // Start is called before the first frame update
    void Start()
    {
        hidden_Path_transition.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {

        foreach (var item in event_Depend_on)
        {
            if (item.active)
                val = true;
            else
            {
                val = false;
                cutscene_play = true;
            }
                
        }
        if (val && cutscene_play)
        {
            cutscene_play = false;
            //play the animation of hidden path && use the cut scene
            hidden_Path_transition.SetActive(true);
            gameObject.GetComponent<Animator>().SetBool("active", true);
            the_Main_Camera.SetActive(false);
            cut_scene_Camera.SetActive(true);
            StartCoroutine(Play_CutScene());

        }
        else if(!val )
        {           
            gameObject.GetComponent<Animator>().SetBool("active", false);          
        }
    }

    IEnumerator Play_CutScene()
    {
        yield return new WaitForSeconds(1f);
        the_Main_Camera.SetActive(true);
        cut_scene_Camera.SetActive(false);
    }
}
