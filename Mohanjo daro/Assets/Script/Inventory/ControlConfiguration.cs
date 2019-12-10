using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class ControlConfiguration : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioManager AM;
    public AudioMixer audioMixer;
    public  TMP_Dropdown resolutionDropdown;
    Resolution[] resolution_List;
    //set save value in the ui
    public Toggle fullscreen;
    public TMP_Dropdown Graphic;
    public Slider volume;
    public Slider BGM;
    public Slider BGS;
    private int reset_Resulution;
    private bool sound_Active;

    private void Awake()
    {
        
    }
    private void Start()
    {
        resolution_List = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        int currentScreenResolutionIndex = 0;
        List<string> list = new List<string>();
        for (int i = 0; i < resolution_List.Length; i++)
        {
            //if(resolution_List[i].width >= Screen.currentResolution.width && resolution_List[i].height >= Screen.currentResolution.height)
            //{
            string item = resolution_List[i].width + "X" + resolution_List[i].height;         //"Width" + "X" + "Height";
            list.Add(item);
            //}           

            if (resolution_List[i].width == Screen.currentResolution.width && resolution_List[i].height == Screen.currentResolution.height)
            {
                currentScreenResolutionIndex = i;
                reset_Resulution = i;
                if (PlayerPrefs.HasKey("Menu_Resolution"))
                {
                    currentScreenResolutionIndex = PlayerPrefs.GetInt("Menu_Resolution");
                }
            }
        }

        resolutionDropdown.AddOptions(list);
        resolutionDropdown.value = currentScreenResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        //
        if (PlayerPrefs.HasKey("Menu_MainAudio"))
        {
            audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("Menu_MainAudio"));
            volume.value = PlayerPrefs.GetFloat("Menu_MainAudio");
            //Debug.Log("Menu_MainAudio=" + PlayerPrefs.GetFloat("Menu_MainAudio"));
        }
        if (PlayerPrefs.HasKey("Menu_Graphic"))
        {
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Menu_Graphic"));
            Graphic.value = PlayerPrefs.GetInt("Menu_Graphic");
            //Debug.Log("Menu_Graphic=" + PlayerPrefs.GetFloat("Menu_Graphic"));
        }
        if (PlayerPrefs.HasKey("Menu_FullScreen"))
        {
            if (PlayerPrefs.GetString("Menu_FullScreen") == "true" || PlayerPrefs.GetString("Menu_FullScreen") == "True")
            {
                Screen.fullScreen = true;
                fullscreen.isOn = true;
            }                         
            else
            {
                Screen.fullScreen = false;
                fullscreen.isOn = false;
            }
                
        }

        if (PlayerPrefs.HasKey("Menu_BackGroundMusic"))
        {
            AM.audiosource.volume = PlayerPrefs.GetFloat("Menu_BackGroundMusic");
            BGM.value = PlayerPrefs.GetFloat("Menu_BackGroundMusic");
            //Debug.Log("Menu_Graphic=" + PlayerPrefs.GetFloat("Menu_Graphic"));
        }
        if (PlayerPrefs.HasKey("Menu_BackgroundSound"))
        {

            AM.sounds[0].volume = PlayerPrefs.GetFloat("Menu_BackgroundSound");
            BGS.value = PlayerPrefs.GetFloat("Menu_BackgroundSound");
        }


    }
    public void Set_Volume(float volume)
    {
        //Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("Menu_MainAudio",volume);
    }

    public void Set_Graphic(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("Menu_Graphic", qualityIndex);
    }

    public void Set_FullScreen(bool IsFullScreen)
    {
        Screen.fullScreen = IsFullScreen;
        PlayerPrefs.SetString("Menu_FullScreen", IsFullScreen.ToString());
    }

    public void Set_Resolution(int resolutionIndex)
    {
        Resolution resolution = resolution_List[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("Menu_Resolution", resolutionIndex);
    }

    public void Reset_Button()
    {
        PlayerPrefs.SetFloat("Menu_MainAudio", 5);
        PlayerPrefs.SetInt("Menu_Graphic", 5);
        PlayerPrefs.SetString("Menu_FullScreen", "true");
        PlayerPrefs.SetInt("Menu_Resolution", reset_Resulution);

        PlayerPrefs.SetFloat("Menu_BackGroundMusic", 0.5f);
        PlayerPrefs.SetFloat("Menu_BackgroundSound", 0.5f);

        resolutionDropdown.value = reset_Resulution;
        if (PlayerPrefs.HasKey("Menu_MainAudio"))
        {
            audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("Menu_MainAudio"));
            volume.value = PlayerPrefs.GetFloat("Menu_MainAudio");
        }
        if (PlayerPrefs.HasKey("Menu_Graphic"))
        {
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Menu_Graphic"));
            Graphic.value = PlayerPrefs.GetInt("Menu_Graphic");
        }
        if (PlayerPrefs.HasKey("Menu_FullScreen"))
        {
            if (PlayerPrefs.GetString("Menu_FullScreen") == "true" || PlayerPrefs.GetString("Menu_FullScreen") == "True")
            {
                Screen.fullScreen = true;
                fullscreen.isOn = true;
            }
            else
            {
                Screen.fullScreen = false;
                fullscreen.isOn = false;
            }

        }
        if (PlayerPrefs.HasKey("Menu_BackGroundMusic"))
        {
            AM.audiosource.volume = PlayerPrefs.GetFloat("Menu_BackGroundMusic");
            BGM.value = PlayerPrefs.GetFloat("Menu_BackGroundMusic");           
        }
        if (PlayerPrefs.HasKey("Menu_BackgroundSound"))
        {
            AM.sounds[0].volume = PlayerPrefs.GetFloat("Menu_BackgroundSound");
            BGS.value = PlayerPrefs.GetFloat("Menu_BackgroundSound");
        }

    }

    public void Set_BGM(float volume)
    {
        AM.audiosource.volume = volume;
        PlayerPrefs.SetFloat("Menu_BackGroundMusic", volume);
    }
    public void Set_BGS(float volume)
    {
        AM.sounds[0].volume = volume;
        sound_Active = true;
        //AM.Sound_Change();
        PlayerPrefs.SetFloat("Menu_BackgroundSound", volume);
    }

    private void LateUpdate()
    {
        if(sound_Active==true)
        {
            sound_Active = false;
            AM.Sound_Change();

        }
    }

}
