using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroll : MonoBehaviour
{
    private static bool cameraExists;
    // Start is called before the first frame update

    [Range(1, 4)]
    public int pixelScale = 1;

    private Camera _camera;
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
    //    if (_camera == null)
    //    {
    //        _camera = GetComponent<Camera>();
    //        _camera.orthographic = true;
    //    }
    //    _camera.orthographicSize = Screen.height * (0.005f / pixelScale);
    }
}
