using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GridMaster : MonoBehaviour
{

    public GameObject[] spawanHero;
    //private int maxmove = 3;
    public GameObject[] Grids;
   
    private static int _Indra_Starting_Point;
    public static int Indra_Starting_Point
    {
        get { return _Indra_Starting_Point; }
        set { _Indra_Starting_Point = value; }
    }
    private static int _Vayu_Starting_Point;
    public static int Vayu_Starting_Point
    {
        get { return _Vayu_Starting_Point; }
        set { _Vayu_Starting_Point = value; }
    }
    private static int _Sachi_Starting_Point;
    public static int Sachi_Starting_Point
    {
        get { return _Sachi_Starting_Point; }
        set { _Sachi_Starting_Point = value; }
    }
    private static int _Dayus_Starting_Point;
    public static int Dayus_Starting_Point
    {
        get { return _Dayus_Starting_Point; }
        set { _Dayus_Starting_Point = value; }
    }
    private static int _Agni_Starting_Point;
    public static int Agni_Starting_Point
    {
        get { return _Agni_Starting_Point; }
        set { _Agni_Starting_Point = value; }
    }
    private static int _Prithvi_Starting_Point;
    public static int Prithvi_Starting_Point
    {
        get { return _Prithvi_Starting_Point; }
        set { _Prithvi_Starting_Point = value; }
    }

    public int Vayu_StartingPoint;
    public int Agni_StartingPoint;
    public int Indra_StartingPoint;
    public int Sachi_StartingPoint;
    public int Prithvi_StartingPoint;
    public int Dayus_StartingPoint;

    public int Vayu_MaxMove;
    public int Agni_MaxMove;
    public int Indra_MaxMove;
    public int Sachi_MaxMove;
    public int Prithvi_MaxMove;
    public int Dayus_MaxMove;


    private void Start()
    {

        Vayu_Starting_Point = Vayu_StartingPoint;//9;
        Agni_Starting_Point = Agni_StartingPoint;// 13;
        Indra_Starting_Point = Indra_StartingPoint;// 11;

        Sachi_Starting_Point = Sachi_StartingPoint;// 1;
        Prithvi_Starting_Point = Prithvi_StartingPoint;// 3;
        Dayus_Starting_Point = Dayus_StartingPoint;//5;
       
      
    }

    private void Update()
    {
        spawanHero = GameObject.FindGameObjectsWithTag("Player");
        for(int i=0;i<spawanHero.Length;i++)
        {
            try
            {
                if (spawanHero[i].GetComponent<PA>().state.ToString() == "waitingforinput")
                {
                    //let move posiiblities 3;
                    //add global variable to set the player position..4,2
                    int loop_Value = Max_possible_Moves(spawanHero[i].name);
                    int diagonal = loop_Value;  int diagonal1 = loop_Value;
                    int Column_Effected = 0; 
                    int starting_Point = Starting_Point(spawanHero[i].name);
                    for(int j=0;j<Grids.Length;j++)
                    {
                        Grids[j].GetComponent<SpriteRenderer>().color = Color.black;
                       // Grids[j].GetComponent<Button>().image.color= Color.black;
                        //Grids[j].GetComponent<>().color = Color.black;

                    }
                    int row_Value_Plus = starting_Point;
                    int row_Value_Minus = starting_Point;
                    int row_Value_Up = starting_Point;
                    int row_Value_Down = starting_Point;
                    for (int j=0; j<=loop_Value;j++)
                    {
                        //finding the game object inthe array list ..

                        GameObject Parent = Grids[starting_Point].transform.parent.gameObject;
                        if (row_Value_Plus <= 96)
                        {
                            Grids[row_Value_Plus].GetComponent<SpriteRenderer>().color = Color.green;
                            //Grids[row_Value_Plus].GetComponent<Button>().image.color = Color.green;
                        }
                          
                        row_Value_Plus += 8;
                        if (row_Value_Plus > 96)
                            row_Value_Plus -=8;
                        //else
                        //    Column_Effected++;


                        row_Value_Minus -= 8;
                        if (row_Value_Minus < 0)
                            row_Value_Minus +=8;
                        //else
                        //    Column_Effected++;
                        if (row_Value_Minus >= 0)
                            Grids[row_Value_Minus].GetComponent<SpriteRenderer>().color = Color.green;
                       


                        if (Parent.name== Grids[row_Value_Up].transform.parent.gameObject.name)
                        {                           
                            Grids[row_Value_Up].GetComponent<SpriteRenderer>().color = Color.green;                            
                        }
                        if (row_Value_Up < 96)
                            row_Value_Up++; 
                       
                        if (Parent.name == Grids[row_Value_Down].transform.parent.gameObject.name)
                        {
                            Grids[row_Value_Down].GetComponent<SpriteRenderer>().color = Color.green;                          
                        }
                        if (row_Value_Down > 0)
                            row_Value_Down--;
                        //diagonal grids...

                        //if (row_Value < 0)
                        //    row_Value ;
                    }

                    int row_Value_Plus_ = starting_Point;
                    int row_Value_Minus_ = starting_Point;
                    int row_Value_Up_ = starting_Point;
                    int row_Value_Down_ = starting_Point;
                    for (int z = 0; z < loop_Value; z++)
                    {
                        row_Value_Plus_ -= z + 1;
                        row_Value_Minus_ -= z + 1;
                        row_Value_Up_ += z + 1;
                        row_Value_Down_ += z + 1;

                        if (row_Value_Plus_ >= 0)
                        {
                            if (Grids[starting_Point].transform.parent.gameObject.name == Grids[row_Value_Plus_].transform.parent.gameObject.name)
                            {
                                for (int j = 0; j < diagonal - 1; j++)
                                {

                                    row_Value_Plus_ += 8;
                                    if (row_Value_Plus_ > 96)
                                        row_Value_Plus_ -= 8;
                                    if (row_Value_Plus_ <= 96)
                                        Grids[row_Value_Plus_].GetComponent<SpriteRenderer>().color = Color.green;

                                    row_Value_Minus_ -= 8;
                                    if (row_Value_Minus_ < 0)
                                        row_Value_Minus_ += 8;
                                    if (row_Value_Minus_ >= 0)
                                        Grids[row_Value_Minus_].GetComponent<SpriteRenderer>().color = Color.green;
                                }
                                diagonal--;
                                row_Value_Plus_ = starting_Point;
                                row_Value_Minus_ = starting_Point;

                            }
                        }
                        if (row_Value_Up_ <= 96)
                        {
                            if (Grids[starting_Point].transform.parent.gameObject.name == Grids[row_Value_Up_].transform.parent.gameObject.name)
                            {
                                for (int j = 0; j < diagonal1 - 1; j++)
                                {
                                    row_Value_Up_ += 8;
                                    if (row_Value_Up_ > 96)
                                        row_Value_Up_ -= 8;
                                    if (row_Value_Up_ <= 96)
                                        Grids[row_Value_Up_].GetComponent<SpriteRenderer>().color = Color.green;

                                    row_Value_Down_ -= 8;
                                    if (row_Value_Down_ < 0)
                                        row_Value_Down_ += 8;
                                    if (row_Value_Down_ >= 0)
                                        Grids[row_Value_Down_].GetComponent<SpriteRenderer>().color = Color.green;

                                }
                                diagonal1--;
                                row_Value_Up_ = starting_Point;
                                row_Value_Down_ = starting_Point;
                            }
                        }
                    }

                    Grids[Vayu_Starting_Point].GetComponent<SpriteRenderer>().color = Color.red;
                    Grids[Agni_Starting_Point].GetComponent<SpriteRenderer>().color = Color.red;
                    Grids[Indra_Starting_Point].GetComponent<SpriteRenderer>().color = Color.red;
                    Grids[Sachi_Starting_Point].GetComponent<SpriteRenderer>().color = Color.red;
                    Grids[Prithvi_Starting_Point].GetComponent<SpriteRenderer>().color = Color.red;
                    Grids[Dayus_Starting_Point].GetComponent<SpriteRenderer>().color = Color.red;

                    //if (spawanHero[i].name== "Indra")
                    // {

                    //     //for loop for possible move count 
                    //     //x+j/x-j
                    //     //horizontally and vertical
                    //     //y+j/y-j
                    //     //vertically
                    //     //row -1//row+1(j-1)
                    //     //row-2//row+2(j-2)
                    //     //row-3//row+3(j-3)

                    // }
                }
                
            }
            catch (System.Exception)
            {

             
            }
        }
       
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log(gameObject.name);
        }
    }
    private int Max_possible_Moves(string Name)
    {
        int value=0;
        if (Name == "Indra")
            value = Indra_MaxMove;
        if (Name == "Agni")
            value = Agni_MaxMove;
        if (Name == "Dyaus")
            value = Dayus_MaxMove;
        if (Name == "Prithvi")
            value = Prithvi_MaxMove;
        if (Name == "Sachi")
            value = Sachi_MaxMove;
        if (Name == "Vayu")
            value = Vayu_MaxMove;

        return value;
    }
    private int Starting_Point(string Name)
    {
        int value=0;
        if (Name == "Indra")
            value = Indra_Starting_Point;
        if (Name == "Agni")
            value = Agni_Starting_Point;
        if (Name == "Dyaus")
            value = Dayus_Starting_Point;
        if (Name == "Prithvi")
            value = Prithvi_Starting_Point;
        if (Name == "Sachi")
            value = Sachi_Starting_Point;
        if (Name == "Vayu")
            value = Vayu_Starting_Point;

        return value;
    }

    private void OnMouseDown()
    {
        Debug.Log(this.gameObject.name);
    }

}
