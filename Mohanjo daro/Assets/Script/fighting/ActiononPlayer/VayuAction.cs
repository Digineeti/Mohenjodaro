using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VayuAction : MonoBehaviour
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
            ActiveAction = 3;
            Action = new int[ActiveAction];
            Action[0] = 0;
            Action[1] = 1;
            Action[2] = 10;
           
            //enemy action
            EActiveAction = 2;
            Eaction = new int[EActiveAction];
            Eaction[0] = 0;
            Eaction[1] = 9;

            //InactivePlayer
            InActiveAction = 1;
            InActive = new int[InActiveAction];
            InActive[0] = 10;
           

        }
        if (int.Parse(attributeCall.Attribute.Level) > 10 && int.Parse(attributeCall.Attribute.Level) > 20)
        {
            //Active player action
            ActiveAction = 4;
            Action = new int[ActiveAction];
            Action[0] = 0;
            Action[1] = 1;
            Action[2] = 5;
            Action[3] = 7;
            //enemy action
            EActiveAction = 2;
            Eaction = new int[EActiveAction];
            Eaction[0] = 0;
            Eaction[1] = 9;
            //InactivePlayer
            InActiveAction = 2;
            InActive = new int[InActiveAction];
            InActive[0] = 5;
            InActive[1] = 7;
        }
        if (int.Parse(attributeCall.Attribute.Level) > 20 && int.Parse(attributeCall.Attribute.Level) > 30)
        {
            //Active player action
            ActiveAction = 4;
            Action = new int[ActiveAction];
            Action[0] = 0;
            Action[1] = 1;
            Action[2] = 6;
            Action[3] = 8;
            //enemy action
            EActiveAction = 2;
            Eaction = new int[EActiveAction];
            Eaction[0] = 0;
            Eaction[1] = 9;
            //InactivePlayer
            InActiveAction = 2;
            InActive = new int[InActiveAction];
            InActive[0] = 6;
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
        //    Action[3] = 7;
        //    //enemy action
        //    EActiveAction = 2;
        //    Eaction = new int[EActiveAction];
        //    Eaction[0] = 0;
        //    Eaction[1] = 9;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
