using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlickeringLight : MonoBehaviour
{
     public UnityEngine.Experimental.Rendering.Universal.Light2D m_Light2D;
    Light light;
    public float mintime;
    public float maxtime;

    // Start is called before the first frame update
    void Start()
    {
        //light = GetComponent<Light>();
        StartCoroutine(Flashing());
    }


    IEnumerator Flashing()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(mintime,maxtime));
            m_Light2D.enabled = !m_Light2D.enabled;
        }
    }

   
}
