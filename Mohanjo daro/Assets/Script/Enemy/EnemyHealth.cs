using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    public int health;                                          //set the enemy health                                         
    public GameObject bloodEffect;                              //partical system of blood effect
    //EnemyPatrol patrolEnemy;                                    //call the patrol Enemy page 
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
 
        //transform.Translate(Vector2.left * patrolEnemy.speed * Time.deltaTime);//enemy patrolling 

    }
    public void TakeDamage(int Damage)
    {        
        health -= Damage;
    }

   
}
