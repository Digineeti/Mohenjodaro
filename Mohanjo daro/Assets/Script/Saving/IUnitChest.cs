using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitChest
{
    //current position of the player
    string[] GetChest();
    void SetChest(string[] chest);
    //chest that alread grab..
}
