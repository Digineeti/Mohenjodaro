using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Boat_Motion : MonoBehaviour
{

    Rigidbody2D RD;
    Animator anim;

    public GameObject the_Main_Camera;
    public GameObject cut_scene_Camera;
    // Start is called before the first frame update
    private GameObject vcam;
    
    public GameObject tPlayer;
    public Transform boat;
    bool once=true;
    void Start()
    {
        RD = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        the_Main_Camera.SetActive(false);
        cut_scene_Camera.SetActive(true);

        
    }

    // Update is called once per frame
    void Update()
    {
        RD.velocity = new Vector2(0f, 1.5f);
        if(once)
        {
            once = false;
            tPlayer = GameObject.Find("Indra 1");
            vcam = GameObject.Find("CinemachineCamera");
            boat = GameObject.Find("Boat").transform;
            //vcam.GetComponent<CinemachineVirtualCamera>().LookAt = boat;
            vcam.GetComponent<CinemachineVirtualCamera>().Follow = boat;
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("reach", true);
        the_Main_Camera.SetActive(true);
        //StartCoroutine(Play_CutScene());
        //vcam.GetComponent<CinemachineVirtualCamera>().LookAt = tPlayer.transform;
        vcam.GetComponent<CinemachineVirtualCamera>().Follow = tPlayer.transform;
        cut_scene_Camera.SetActive(false);
       
        
    }
    IEnumerator Play_CutScene()
    {
        yield return new WaitForSeconds(1f);
       
    }
}
