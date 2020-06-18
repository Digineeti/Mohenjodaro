using System;
using UnityEngine;

public interface IUnit
{
    //current level of the player
    int GetLevel();
    void SetLevel(int level);
    //current position of the player
    Vector2 GetPosition();
    void SetPosition(Vector2 position);
    //chest that alread grab..
    GameObject GetChest();
    void SetChest(GameObject chestid);
    //dialogue that already diliver
    GameObject Dialogue();
    void SetDialogue(GameObject Dialogueid);

   
}


