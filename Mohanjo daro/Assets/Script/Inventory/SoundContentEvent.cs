using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class SoundContentEvent : MonoBehaviour
{
    public AudioManager AM;
    public AudioMixer audioMixer;
    public Slider volume;
    public Slider BGM;
    public Slider SFX;
    public Slider DialogueSound;
    float mainVolume;
    private bool sound_Active;

    public GameObject MainMenu;
    public GameObject OptionMenu;

    // Start is called before the first frame update

    protected void save_Data_Extract()
    {
        if (PlayerPrefs.HasKey("Menu_MainAudio"))
        {
            audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("Menu_MainAudio"));
            volume.value = PlayerPrefs.GetFloat("Menu_MainAudio");
        }
        if (PlayerPrefs.HasKey("Menu_BackGroundMusic"))
        {
            AM.audiosource.volume = PlayerPrefs.GetFloat("Menu_BackGroundMusic");
            BGM.value = PlayerPrefs.GetFloat("Menu_BackGroundMusic");
        }
        if (PlayerPrefs.HasKey("Menu_BackgroundSound"))
        {
            AM.sounds[0].volume = PlayerPrefs.GetFloat("Menu_BackgroundSound");
            SFX.value = PlayerPrefs.GetFloat("Menu_BackgroundSound");
        }
    }
    void Start()
    {
        save_Data_Extract();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region music optionsliders
    public void Set_Volume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        mainVolume = volume;
    }
    public void Set_BGM(float volume)
    {
        AM.audiosource.volume = volume;
    }
    public void Set_BGS(float volume)
    {
        AM.sounds[0].volume = volume;
        sound_Active = true;
    }
   
    #endregion

    public void Save_Button_click()
    {
        AM.play("buttonClick");

        PlayerPrefs.SetFloat("Menu_MainAudio", mainVolume);
        PlayerPrefs.SetFloat("Menu_BackGroundMusic", AM.audiosource.volume);
        PlayerPrefs.SetFloat("Menu_BackgroundSound", AM.sounds[0].volume);
    }
    public void  Default_Button_Click()
    {
        AM.play("buttonClick");
        PlayerPrefs.SetFloat("Menu_MainAudio", 5);
        PlayerPrefs.SetFloat("Menu_BackGroundMusic", 0.5f);
        PlayerPrefs.SetFloat("Menu_BackgroundSound", 0.5f);
        save_Data_Extract();

    }
    public void Back_Button_Click()
    {
        save_Data_Extract();
        MainMenu.SetActive(true);
        OptionMenu.SetActive(false);
        AM.play("buttonClick");
    }

    private void LateUpdate()
    {
        if (sound_Active == true)
        {
            sound_Active = false;
            AM.Sound_Change();
        }
    }
}
