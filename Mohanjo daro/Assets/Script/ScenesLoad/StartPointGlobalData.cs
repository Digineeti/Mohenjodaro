using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPointGlobalData : MonoBehaviour
{
    private static string _sceneName;
    public static string Scene
    {
        get { return _sceneName; }
        set { _sceneName = value; }
    }
}
