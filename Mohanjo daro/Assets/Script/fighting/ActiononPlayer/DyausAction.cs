using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyausAction : MonoBehaviour
{
    public Callingscriptableobject attributeCall;
    public int[] Action;
    public int ActiveAction;

    public int[] Eaction;
    public int EActiveAction;
    public int[] InActive;
    public int InActiveAction;

    public string[,] SpAction;
    public int specialActioncount;

    public string[,] SpPAction;
    public int specialPActioncount;

    // Start is called before the first frame update
    void Start()
    {
        specialActioncount = 1;
        SpAction = new string[specialActioncount, 2];
        //action on enemy..
        SpAction[0, 0] = "HeavenlyWorth"; SpAction[0, 1] = "5";
        //action on player..
        specialPActioncount = 2;
        SpPAction = new string[specialPActioncount, 2];
        SpPAction[0, 0] = "Revive"; SpPAction[0, 1] = "2";
        SpPAction[1, 0] = "HealAll"; SpPAction[1, 1] = "4";
        InActive = Action;
        if (int.Parse(attributeCall.Attribute.Level) < 10)
        {
            //Active player action
            ActiveAction = 4;
            Action = new int[ActiveAction];
            Action[0] = 0;
            Action[1] = 1;
            Action[2] = 9;
            Action[3] = 4;

            //enemy action
            EActiveAction = 2;
            Eaction = new int[EActiveAction];
            Eaction[0] = 0;
            Eaction[1] = 12;

            //InactivePlayer
            InActiveAction = 2;
            InActive = new int[InActiveAction];
            InActive[0] = 9;
            InActive[1] = 4;

        }
        if (int.Parse(attributeCall.Attribute.Level) > 10 && int.Parse(attributeCall.Attribute.Level) > 20)
        {
            //Active player action
            ActiveAction = 4;
            Action = new int[ActiveAction];
            Action[0] = 0;
            Action[1] = 1;
            Action[2] = 9;
            Action[3] = 3;
            //Active enemy action
            EActiveAction = 2;
            Eaction = new int[EActiveAction];
            Eaction[0] = 0;
            Eaction[1] = 12;

            //InactivePlayer
            InActiveAction = 2;
            InActive = new int[InActiveAction];
            InActive[0] = 9;
            InActive[1] = 3;

        }
        if (int.Parse(attributeCall.Attribute.Level) > 20 && int.Parse(attributeCall.Attribute.Level) > 30)
        {
            //Active player action
            ActiveAction = 4;
            Action = new int[ActiveAction];
            Action[0] = 0;
            Action[1] = 1;
            Action[2] = 9;
            Action[3] = 3;
            //enemy action
            EActiveAction = 2;
            Eaction = new int[EActiveAction];
            Eaction[0] = 0;
            Eaction[1] = 12;

            //InactivePlayer
            InActiveAction = 2;
            InActive = new int[InActiveAction];
            InActive[0] = 9;
            InActive[1] = 3;

        }

      

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
