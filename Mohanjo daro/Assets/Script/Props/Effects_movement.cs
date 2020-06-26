using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects_movement : MonoBehaviour
{
    public GameObject target_Position;
    public float speed = 15;
    Vector3 dirNormalized;
    bool start = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Impact());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
        if(Input.GetKeyDown(KeyCode.F))
        {
            gameObject.GetComponent<Animator>().SetBool("start",true);
            StartCoroutine(move());
            start = true;
           
        }
        if(start)
        {
            dirNormalized = (target_Position.transform.position - transform.position).normalized;
            float step = speed * Time.deltaTime;

            // move sprite towards the target location
            transform.position = Vector2.MoveTowards(transform.position, target_Position.transform.position, step);
        }
    }
    IEnumerator move()
    {
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<Animator>().SetBool("start", false);
       

    }
    IEnumerator Impact()
    {

        yield return new WaitForSeconds(.5f);      
        gameObject.GetComponent<Animator>().SetBool("start", true);      
        yield return new WaitForSeconds(.5f);       
        gameObject.GetComponent<Animator>().SetBool("start", false);
    }
}
