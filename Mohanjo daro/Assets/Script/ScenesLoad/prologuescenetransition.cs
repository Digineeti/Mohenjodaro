using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prologuescenetransition : MonoBehaviour
{
    public GameObject player;
    public GameObject enterposition;
    public Animator tranmisionamin;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(loadScene());
        }
    }
    IEnumerator loadScene()
    {
        //tranmisionamin.SetFloat("transition", 1);
        tranmisionamin.SetBool("Start", true);
        yield return new WaitForSeconds(1f);
        player.transform.position = new Vector3(enterposition.transform.position.x,enterposition.transform.position.y,0f);
        
        tranmisionamin.SetBool("Start", false);
        //tranmisionamin.SetBool("Start", true);
    }
}
