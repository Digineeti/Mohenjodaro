using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chinemachinecontroll : MonoBehaviour
{
    private static bool cameraExists;
   
   
    // Start is called before the first frame update
    void Start()
    {
        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject shape = GameObject.Find("CameraBoundary");
        gameObject.GetComponent<CinemachineConfiner>().m_BoundingShape2D = shape.GetComponent<PolygonCollider2D>();
    }
}
