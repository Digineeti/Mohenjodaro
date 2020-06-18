using System;
using UnityEngine;

[Serializable]
public class SaveData :MonoBehaviour
{
    private static int level;
    public static int Level
    {
        get { return level; }
        set { level = value; }
    }

    private static Vector2 position;
    public static Vector2 Position
    {
        get { return position; }
        set { position = value; }
    }
}


