using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SceneBackgroundLoad : MonoBehaviour
{
    public Sprite [] Background;
    public SpriteRenderer BackgroundImage;
    //public string[] ScenenName;
    //public Image BackgroundImage;
    //public GameObject test;

    // Start is called before the first frame update
    void Start()
    {
        int v = Random.Range(1, Background.Length);
        BackgroundImage.sprite = Background[v];
        //BackgroundImage.sprite = Background[PlayerPrefs.GetInt("CurrentScene")];
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
