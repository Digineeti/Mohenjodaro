using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndraAction : MonoBehaviour
{
    public Callingscriptableobject attributeCall;
    public int[] Action;
    public int ActiveAction;

    public int[] Eaction;
    public int EActiveAction;

    public int[] InActive;
    public int InActiveAction;

    public string [,] SpAction;
    public int specialActioncount;

    public string[,] SpPAction;
    public int specialPActioncount;
    // Start is called before the first frame update
    void Start()
    {
        specialActioncount = 2;
        SpAction = new string [specialActioncount,2];
        //action on enemy..
        SpAction[0,0] = "LightingAttack"; SpAction[0,1] = "2";
        SpAction[1,0] = "ThunderStrom"; SpAction[1,1] = "4";
        //action on player..
        specialPActioncount = 0;
        SpPAction = new string[specialPActioncount, 2];

        //check  level from save data ..
        //if save data is not available then check from the attribute list (initial value...)

        if (int.Parse(attributeCall.Attribute.Level)<10)
        {
            //Active player action
            ActiveAction = 3;
            Action = new int[ActiveAction];
            Action[0] = 0;
            Action[1] = 1;
            Action[2] = 2;
            //enemy action
            EActiveAction = 3;
            Eaction = new int[EActiveAction];
            Eaction[0] = 0;
            Eaction[1] = 1;
            Eaction[2] = 2;
            //InactivePlayer
            InActiveAction = 0;
            InActive = new int[InActiveAction];
          
        }

        if (int.Parse(attributeCall.Attribute.Level) > 10 && int.Parse(attributeCall.Attribute.Level) > 20)
        {
            //Active player action
            ActiveAction = 3;
            Action = new int[ActiveAction];
            Action[0] = 0;
            Action[1] = 1;
            Action[2] = 2;
            //enemy action
            EActiveAction = 3;
            Eaction = new int[EActiveAction];
            Eaction[0] = 0;
            Eaction[1] = 1;
            Eaction[2] = 2;
            //InactivePlayer
            InActiveAction = 0;
            InActive = new int[InActiveAction];
        }
        if (int.Parse(attributeCall.Attribute.Level) > 20 && int.Parse(attributeCall.Attribute.Level) > 30)
        {
            //Active player action
            ActiveAction = 4;
            Action = new int[ActiveAction];
            Action[0] = 0;
            Action[1] = 1;
            Action[2] = 2;
            Action[3] = 4;
            //enemy action
            EActiveAction = 3;
            Eaction = new int[EActiveAction];
            Eaction[0] = 0;
            Eaction[1] = 1;
            Eaction[2] = 2;

            //InactivePlayer
            InActiveAction = 1;
            InActive = new int[InActiveAction];
            InActive[0] = 4;
        }        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
