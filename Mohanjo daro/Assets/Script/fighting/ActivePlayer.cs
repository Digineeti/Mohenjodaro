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
    public GameObject Winningpanel;

    
    private int Hero;
    private int enemy;
    private GameObject[] spawanHero;
    private bool fixedHeroandenemy;



    // Start is called before the first frame update
    void Start()
    {      
        fixedHeroandenemy = true;
      
        Globalvariable.WinningLosing = true;
    }

    // Update is called once per frame
    void Update()
    {
        spawanHero = GameObject.FindGameObjectsWithTag("Player");

        Hero = 0;
        enemy = 0;
        for (int i = 0; i < spawanHero.Length; i++)
        {
            try
            {
                if (spawanHero[i].GetComponent<PA>().DeathPlayer.ToString() == "Active")
                {
                    Hero++;
                }
            }
            catch (System.Exception)
            {
                enemy++;

            }

        }
        if (Globalvariable.WinningLosing)
        {
            Winningpanel.SetActive(false);
            Globalvariable.WinningLosing = false;         
           
            if (fixedHeroandenemy)
            {
                NoOfEnemy.text = enemy.ToString();
                NoOfHero.text = Hero.ToString();
                fixedHeroandenemy = false;
                NoOfActiveEnemy.text = enemy.ToString();
                NoOfActiveHero.text = Hero.ToString();

            }            
        }

        NoOfActiveEnemy.text = (enemy).ToString();
        NoOfActiveHero.text = (Hero).ToString();
        if (Hero <= 0)
        {
            Winningpanel.SetActive(true);
            TMP_Text ActiveHero = Winningpanel.GetComponentInChildren<TMP_Text>();
            ActiveHero.text = "Enemy wins";
        }
        if (enemy <= 0)
        {
            Winningpanel.SetActive(true);
            TMP_Text ActiveHero = Winningpanel.GetComponentInChildren<TMP_Text>();
          
            ActiveHero.text = "Player wins";
        }
    }
}
