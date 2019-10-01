using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandSpawn : MonoBehaviour
{
    public GameObject position;
    public GameObject[] EnemyListFront;
    public GameObject[] EnemyListBack;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<4;i++)
        {
            int rand = Random.Range(1, 4);
            EnemyListFront[i].SetActive(false);
            EnemyListFront[rand].SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
