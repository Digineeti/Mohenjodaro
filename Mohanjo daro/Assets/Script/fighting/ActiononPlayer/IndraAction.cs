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
    // Start is called before the first frame update
    void Start()
    {
       
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

        
        //else
        //{
        //    //Active player action
        //    ActiveAction = 4;
        //    Action = new int[ActiveAction];
        //    Action[0] = 0;
        //    Action[1] = 1;
        //    Action[2] = 2;
        //    Action[3] = 5;
        //    //enemy action
        //    EActiveAction = 3;
        //    Eaction = new int[EActiveAction];
        //    Eaction[0] = 0;
        //    Eaction[1] = 1;
        //    Eaction[2] = 2;
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }
}
