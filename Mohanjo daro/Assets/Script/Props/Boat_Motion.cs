using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat_Motion : MonoBehaviour
{

    Rigidbody2D RD;
    Animator anim;

    public GameObject the_Main_Camera;
    public GameObject cut_scene_Camera;
    // Start is called before the first frame update
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
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        the_Main_Camera.SetActive(true);
        cut_scene_Camera.SetActive(false);
        anim.SetBool("reach", true);
        StartCoroutine(Play_CutScene());
    }
    IEnumerator Play_CutScene()
    {
        yield return new WaitForSeconds(1f);
       
    }
}
