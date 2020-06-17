using System;
using UnityEngine;

[Serializable]
public class SaveData 
{
    public PlayerData MyPlayerData { get; set; }
    public SaveData()
    {

    }
}

[Serializable]
public class PlayerData
{
    public int MyLevel { get; set; }

    public float Myx { get; set; }
    public float Myy { get; set; }

    public PlayerData( int level,Vector2 Position)
    {
        this.MyLevel = level;
        this.Myx = Position.x;
        this.Myy = Position.y;
    }
}
