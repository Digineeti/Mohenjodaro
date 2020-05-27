﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroll : MonoBehaviour
{
    private static bool cameraExists;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
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
    void Update()
    {
        
    }
}
