using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpwanningEnemyFront : MonoBehaviour
{
    public GameObject[] EnemyList;
    public GameObject parent; 
    public float EnemyScale = .5f;
    public EnemyAction EA;
    //private int count = 0;
    private void Start()
    {
        int NoOfEnemy = Random.Range(1, EnemyList.Length);
        EnemyList[NoOfEnemy] = Instantiate(EnemyList[NoOfEnemy], gameObject.transform.position, Quaternion.identity);
        EnemyList[NoOfEnemy].transform.SetParent(parent.transform, true);
        int id = EnemyList[NoOfEnemy].name.IndexOf("(");
        EnemyList[NoOfEnemy].name = EnemyList[NoOfEnemy].name.Substring(0, id);
       
        EnemyList[NoOfEnemy].transform.localScale = new Vector3(EnemyScale, EnemyScale, 1);
    }


}
