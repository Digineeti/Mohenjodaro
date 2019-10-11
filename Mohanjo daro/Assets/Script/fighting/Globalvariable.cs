
public class Globalvariable
{
    private static int _index;
    public static int Index
    {
        get        {return _index;}
        set        {_index = value;}
    }

    private static bool _playerUi;
    public static bool PlayerUi
    {
        get        {return _playerUi;}
        set        {_playerUi = value;}
    }

    private static bool _AttackUi;
    public static bool AttackUi
    {
        get        {return _AttackUi;}
        set        {_AttackUi = value;}
    }

    private static float _currentTime;
    public static float currentTime
    {
        get        {return _currentTime;}
        set        {_currentTime = value;}
    }

    private static float _nextTime;
    public static float nextTime
    {
        get        {return _nextTime;}
        set        {_nextTime = value;}
    }

    private static float _Heal;
    public static float Heal
    {
        get        {return _Heal;}
        set        {_Heal = value;}
    }

    private static bool _turnUi;
    public static bool turnUi
    {
        get        {return _turnUi;}
        set        {_turnUi = value;}
    }

    private static bool _Active_Player_Action;
    public static bool Active_Player_Action
    {
        get        {return _Active_Player_Action;}
        set        { _Active_Player_Action = value;}
    }

    private static string _Active_Player_Animation_Parameter;
    public static string Active_Player_Animation_Parameter
    {
        get       { return _Active_Player_Animation_Parameter; }
        set       { _Active_Player_Animation_Parameter = value; }
    }

    private static bool _All_Player_Hoverbutton;
    public static bool All_Player_Hoverbutton
    {
        get { return _All_Player_Hoverbutton; }
        set { _All_Player_Hoverbutton = value; }
    }
    private static bool _All_Enemy_Hoverbutton;
    public static bool All_Enemy_Hoverbutton
    {
        get { return _All_Enemy_Hoverbutton; }
        set { _All_Enemy_Hoverbutton = value; }
    }
}
