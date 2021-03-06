﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionList : MonoBehaviour
{
    public struct Action
    {
        //player Section
        public string Defence;
        public string Item;
        public string Runaway;

        public string Heal;
        public string HealAll;

        public string DefenceBoost;
        public string DefenceAllBoost;

        public string AttackBoost;
        public string AttackAllBoost;

        public string Revive;

        //enemy section
        public string LightingAttack;
        public string ThunderStrom;
        public string LightBoom;
        public string AirAttack;
        public string FireBall;
        public string Inferance;
        public string QuickEnd;
        public string Earthquake;


    }

    public string [] ActivePlayerActionsList;
    //public string[] InActivePlayerActionsList;
    public string[] EnemyActionsList;

    public string[] InActivePlayerActionList;


    public Transform[] Effect;



    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Instantiate(Effect[6], collision.transform.position, collision.transform.rotation);
    //}
}
