using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenuEvent : MonoBehaviour
{
    public GameObject MusicPanel;
    public GameObject DisplayPanel;
    public GameObject GamePlayPanel;
    public AudioManager AM;
    private void Start()
    {
        MusicPanel.SetActive(true);
        DisplayPanel.SetActive(false);
        GamePlayPanel.SetActive(false);
    }
    public void MusicButton_Click()
    {
        AM.play("buttonClick");
        MusicPanel.SetActive(true);
        DisplayPanel.SetActive(false);
        GamePlayPanel.SetActive(false);
    }
    public void DiaplayButton_Click()
    {
        AM.play("buttonClick");
        MusicPanel.SetActive(false);
        DisplayPanel.SetActive(true);
        GamePlayPanel.SetActive(false);
    }
    public void GamePlayButton_Click()
    {
        AM.play("buttonClick");
        MusicPanel.SetActive(false);
        DisplayPanel.SetActive(false);
        GamePlayPanel.SetActive(true);
    }
   
}
