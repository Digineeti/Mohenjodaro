using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SachiAction : MonoBehaviour
{
    public Callingscriptableobject attributeCall;
    public int[] Action;
    public int ActiveAction;

    public int[] Eaction;
    public int EActiveAction;

    public int[] InActive;
    public int InActiveAction;
    // Start is called before the first frame update
    void Start()
    {
        
        if (int.Parse(attributeCall.Attribute.Level) < 10)
        {
            //Active player action
            ActiveAction = 4;
            Action = new int[ActiveAction];
            Action[0] = 0;
            Action[1] = 1;
            Action[2] = 3;
            Action[3] = 4;
            //enemy action
            EActiveAction = 2;
            Eaction = new int[EActiveAction];
            Eaction[0] = 0;
            Eaction[1] = 10;

            //InactivePlayer
            InActiveAction = 2;
            InActive = new int[InActiveAction];
            InActive[0] = 3;
            InActive[1] = 4;
        }
        if (int.Parse(attributeCall.Attribute.Level) > 10 && int.Parse(attributeCall.Attribute.Level) > 20)
        {
            //Active player action
            ActiveAction = 4;
            Action = new int[ActiveAction];
            Action[0] = 0;
            Action[1] = 1;
            Action[2] = 3;
            Action[3] = 5;
            //enemy action
            EActiveAction = 2;
            Eaction = new int[EActiveAction];
            Eaction[0] = 0;
            Eaction[1] = 10;

            //InactivePlayer
            InActiveAction = 2;
            InActive = new int[InActiveAction];
            InActive[0] = 3;
            InActive[1] = 5;
        }
        if (int.Parse(attributeCall.Attribute.Level) > 20 && int.Parse(attributeCall.Attribute.Level) > 30)
        {
            //Active player action
            ActiveAction = 4;
            Action = new int[ActiveAction];
            Action[0] = 0;
            Action[1] = 1;
            Action[2] = 3;
            Action[3] = 8;
            //enemy action
            EActiveAction = 2;
            Eaction = new int[EActiveAction];
            Eaction[0] = 0;
            Eaction[1] = 10;
            //InactivePlayer
            InActiveAction = 2;
            InActive = new int[InActiveAction];
            InActive[0] = 3;
            InActive[1] = 8;
        }
        //else
        //{
        //    //Active player action
        //    ActiveAction = 4;
        //    Action = new int[ActiveAction];
        //    Action[0] = 0;
        //    Action[1] = 1;
        //    Action[2] = 4;
        //    Action[3] = 9;
        //    //enemy action
        //    EActiveAction = 2;
        //    Eaction = new int[EActiveAction];
        //    Eaction[0] = 0;
        //    Eaction[1] = 10;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
