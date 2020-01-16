using UnityEngine;
using System.Collections;

public class csDestroyEffect : MonoBehaviour {

    float timeToDestroyeTheObject;
    private void Start()
    {
        timeToDestroyeTheObject = 0;
    }
    void Update () {
        timeToDestroyeTheObject += Time.deltaTime;
        if(timeToDestroyeTheObject>2)
        {
            Destroy(gameObject);
        }
        //if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.C))
        //{
           
        //}
    }
}
