using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleRotate : MonoBehaviour
{
    public Vector3 speed;
    private float time=0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time < 0.07f)
            transform.Rotate(speed * Time.deltaTime);
        else
            Destroy(gameObject);
    }
}
