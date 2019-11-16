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
    private bool game_over_Exp;


    // Start is called before the first frame update
    void Start()
    {      
        fixedHeroandenemy = true;
        game_over_Exp = true;
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
                Globalvariable.SP = new string[enemy];
                Globalvariable.SP_Hero = new string[Hero];
                int j = 0;
                int z = 0;
                for (int i = 0; i < spawanHero.Length; i++)
                {
                    try
                    {
                        if (spawanHero[i].GetComponent<PA>().state.ToString() == "waitingforinput"  || spawanHero[i].GetComponent<PA>().state.ToString() == "busy")
                        {
                            Globalvariable.SP_Hero[z] = spawanHero[i].name;
                            z++;
                        }
                    }
                    catch (System.Exception)
                    {
                        Globalvariable.SP[j] = spawanHero[i].name;
                        j++;
                    }
                }
                NoOfEnemy.text = enemy.ToString();
                NoOfHero.text = Hero.ToString();
                fixedHeroandenemy = false;
                NoOfActiveEnemy.text = enemy.ToString();
                NoOfActiveHero.text = Hero.ToString();

            }            
        }
        
        NoOfActiveEnemy.text = (enemy).ToString();
        NoOfActiveHero.text = (Hero).ToString();
        float ExPValue = 0;
        if (Hero <= 0)
        {
            Winningpanel.SetActive(true);
            TMP_Text ActiveHero = Winningpanel.GetComponentInChildren<TMP_Text>();
            Globalvariable.Hang = false;
            ActiveHero.text = "Enemy wins";
        }
        if (enemy <= 0)
        {
            Winningpanel.SetActive(true);
            Globalvariable.Hang = false;
            TMP_Text ActiveHero = Winningpanel.GetComponentInChildren<TMP_Text>();
          
            ActiveHero.text = "Player wins";
            //allplayer get the experience......
            for(int i=0;i<Globalvariable.SP.Length;i++)
            {
                ExPValue+= PlayerPrefs.GetFloat(Globalvariable.SP[i] +"_Exp");
            }
        }
        if(game_over_Exp==true)
        {
            if (ExPValue > 0)
            {
                //Debug.Log("Each Player Get Exp" + ExPValue / int.Parse(NoOfHero.text));
                float Exp_Receive = ExPValue / int.Parse(NoOfHero.text);
                for (int i = 0; i < Globalvariable.SP_Hero.Length; i++)
                {
                    if (PlayerPrefs.HasKey(Globalvariable.SP_Hero[i] + "_Exp"))
                    {
                        float Current_Value = PlayerPrefs.GetFloat(Globalvariable.SP_Hero[i] + "_Exp");
                        Debug.Log(Globalvariable.SP_Hero[i] + " Current Exp=" + Current_Value);
                        Current_Value += Exp_Receive;
                        if(Current_Value>=100)
                        {

                            //player level up if exp in greater then or equl to 100.
                            PlayerPrefs.SetFloat(Globalvariable.SP_Hero[i] + "_Exp", 0);
                            float level=PlayerPrefs.GetFloat(Globalvariable.SP_Hero[i] + "_Level");
                            level++;

                            PlayerPrefs.SetFloat(Globalvariable.SP_Hero[i] + "_Level", level);

                        }
                        else
                        {
                            PlayerPrefs.SetFloat(Globalvariable.SP_Hero[i] + "_Exp", Current_Value);
                        }
                       
                        Debug.Log(Globalvariable.SP_Hero[i] + " Update Exp=" + Current_Value);
                    }
                    else
                    {

                        PlayerPrefs.SetFloat(Globalvariable.SP_Hero[i] + "_Exp", Exp_Receive);
                        Debug.Log(Globalvariable.SP_Hero[i] + " New Exp=" + Exp_Receive);

                    }
                }
                game_over_Exp = false;
            }
            
        }
       
    }
}
