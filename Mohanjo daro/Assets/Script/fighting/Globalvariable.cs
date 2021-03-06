﻿using UnityEngine;
public class Globalvariable
{
    private static int _index;
    public static int Index
    {
        get { return _index; }
        set { _index = value; }
    }

    private static bool _playerUi;
    public static bool PlayerUi
    {
        get { return _playerUi; }
        set { _playerUi = value; }
    }

    private static bool _AttackUi;
    public static bool AttackUi
    {
        get { return _AttackUi; }
        set { _AttackUi = value; }
    }

    private static float _currentTime;
    public static float currentTime
    {
        get { return _currentTime; }
        set { _currentTime = value; }
    }

    private static float _nextTime;
    public static float nextTime
    {
        get { return _nextTime; }
        set { _nextTime = value; }
    }

    private static float _Heal;
    public static float Heal
    {
        get { return _Heal; }
        set { _Heal = value; }
    }

    private static bool _turnUi;
    public static bool turnUi
    {
        get { return _turnUi; }
        set { _turnUi = value; }
    }

    //for player animation
    private static bool _Active_Player_Action;
    public static bool Active_Player_Action
    {
        get { return _Active_Player_Action; }
        set { _Active_Player_Action = value; }
    }

   
    private static string _Active_Player_Animation_Parameter;
    public static string Active_Player_Animation_Parameter
    {
        get { return _Active_Player_Animation_Parameter; }
        set { _Active_Player_Animation_Parameter = value; }
    }

    //for enemy animation
    private static bool _Effet_On_enemy;
    public static bool Effect_On_Enemy
    {
        get { return _Effet_On_enemy; }
        set { _Effet_On_enemy = value; }
    }

    private static string _Effect_Animation_On_Enemy;
    public static string Effect_Animation_On_Enemy
    {
        get { return _Effect_Animation_On_Enemy; }
        set { _Effect_Animation_On_Enemy = value; }
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

    private static bool _WinningLosing;
    public static bool WinningLosing
    {
        get { return _WinningLosing; }
        set { _WinningLosing = value; }
    }

    private static bool _Hang;
    public static bool Hang
    {
        get { return _Hang; }
        set { _Hang = value; }
    }

    private static string[] _SP;
    public static string[] SP
    {
        get { return _SP; }
        set { _SP = value; }
    }

    private static string[] _SP_Hero;
    public static string[] SP_Hero
    {
        get { return _SP_Hero; }
        set { _SP_Hero = value; }
    }

    private static bool _Dialogue_Open;
    public static bool Dialogue_Open
    {
        get { return _Dialogue_Open; }
        set { _Dialogue_Open = value; }
    }

    private static float _Fight_Scene_Load_frequency;
    public static float Fight_Scene_Load_freqency
    {
        get { return _Fight_Scene_Load_frequency; }
        set { _Fight_Scene_Load_frequency = value; }
    }

    private static Vector3 _player_Potion;
    public static Vector3 Player_Position
    {
        get { return _player_Potion; }
        set { _player_Potion = value; }
    }

    private static string _current_Scene;
    public static string Current_Scene
    {
        get { return _current_Scene; }
        set { _current_Scene = value;
 }
    }

    private static bool _Player_Win;
    public static bool Player_win
    {
        get { return _Player_Win; }
        set { _Player_Win = value; }
    }

    private static GameObject _NotDestroyed_player;
    public static GameObject NotDestroyed_Player
    {
        get { return _NotDestroyed_player; }
        set { _NotDestroyed_player = value; }
    }

    private static GameObject _NotDestroyed_MainCamera;
    public static GameObject NotDestroyed_MainCamera
    {
        get { return _NotDestroyed_MainCamera; }
        set { _NotDestroyed_MainCamera = value; }
    }

    private static GameObject _NotDestroyed_CineMachine;
    public static GameObject NotDestroyed_CineMachine
    {
        get { return _NotDestroyed_CineMachine; }
        set { _NotDestroyed_CineMachine = value; }
    }

    
    public static Vector3 []TargetPosition;
    public static string[] TargetName;



    private static bool load_game_open;
    public static bool LoadGameOpen
    {
        get{ return load_game_open; }
        set { load_game_open = value; }
    }
    private static string load_file;
    public static string LoadfileOpen
    {
        get { return load_file; }
        set { load_file = value; }
    }



    private static bool walkable_Area;
    public static bool Walkable_Area
    {
        get { return walkable_Area; }
        set { walkable_Area = value; }
    }

    private static int gold;
    public static int Gold
    {
        get { return gold; }
        set { gold = value; }
    }
}
