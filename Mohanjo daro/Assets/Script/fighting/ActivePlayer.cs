using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActivePlayer : MonoBehaviour
{

    public TMP_Text NoOfHero;
    public TMP_Text NoOfActiveHero;
    public TMP_Text NoOfEnemy;
    public TMP_Text NoOfActiveEnemy;

    public EnemSpawner ES;
    int Hero;
    int total;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        total = GameObject.FindGameObjectsWithTag("Player").Length;
        NoOfEnemy.text = (ES.Melee + ES.Range).ToString();
        NoOfActiveEnemy.text = NoOfEnemy.text;

        NoOfHero.text = (total - (ES.Melee + ES.Range)).ToString();
        NoOfActiveHero.text = NoOfHero.text;
    }
}
