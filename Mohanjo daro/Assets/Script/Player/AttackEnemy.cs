using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    private float timeBtwAttack;                                //declare float variable time between attack
    public float startTimeBtwAttack;                            //declare float variable start time between attack
    public Transform AttackPos;                                 //declare transform variable attack position
    public LayerMask whatIsEnemies;                             //declare layermask variable what is enemies
    public float attackRange;                                   //declare float variable attack range
    public int damage;                                          //declare int variable damage
    PlayerInput Input;                                          //call player input file 
    //public Animator camamin;
    // Start is called before the first frame update
    void Start()
    {
        Input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.kick)
            {
                //camamin.SetTrigger("shake");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(AttackPos.position, attackRange, whatIsEnemies);         //check enemy in the damaged range or not 
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyHealth>().TakeDamage(damage);                                                 //enemy receive the damaged 
                    timeBtwAttack = startTimeBtwAttack;                                                                          //set time between time to start attack time
                }

            }

        }
        else
        {
            timeBtwAttack -= Time.deltaTime;                                                                                    //reduce time between time with delta time
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;                                                                                               //set gizmos color to red
        Gizmos.DrawWireSphere(AttackPos.position, attackRange);                                                                  //draw a sphere gizmos
    }
}
