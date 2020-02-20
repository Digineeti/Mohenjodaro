using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalLight : MonoBehaviour
{
    private static bool GloLight;
    // Start is called before the first frame update
    void Start()
    {
       
            DontDestroyOnLoad(transform.gameObject);
       
    }
}
