using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DisplayContentEvent : MonoBehaviour
{
    public AudioManager AM;
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolution_List;
    //set save value in the ui
    public Toggle fullscreen;
    public TMP_Dropdown Graphic;
    private int reset_Resulution;

    public GameObject MainMenu;
    public GameObject OptionMenu;

    private int qualityindexvalue;
    private bool FullScreenValue;
    private int resolutionIndexvalue;
    // Start is called before the first frame update

    protected void save_Data_Extract()
    {
        resolution_List = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        int currentScreenResolutionIndex = 0;
        List<string> list = new List<string>();
        for (int i = 0; i < resolution_List.Length; i++)
        {
            string item = resolution_List[i].width + "X" + resolution_List[i].height;         //"Width" + "X" + "Height";
            list.Add(item);

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
    }
    void Start()
    {
        save_Data_Extract();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Set_Graphic(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        qualityindexvalue = qualityIndex;
      
    }

    public void Set_FullScreen(bool IsFullScreen)
    {
        Screen.fullScreen = IsFullScreen;
        FullScreenValue = IsFullScreen;
        
    }

    public void Set_Resolution(int resolutionIndex)
    {
        Resolution resolution = resolution_List[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        resolutionIndexvalue = resolutionIndex;
       
    }

    public void Save_Button_click()
    {
        AM.play("buttonClick");
        PlayerPrefs.SetInt("Menu_Graphic", qualityindexvalue);
        PlayerPrefs.SetString("Menu_FullScreen", FullScreenValue.ToString());
        PlayerPrefs.SetInt("Menu_Resolution", resolutionIndexvalue);

    }
    public void Default_Button_Click()
    {
        AM.play("buttonClick");
        PlayerPrefs.SetFloat("Menu_MainAudio", 5);
        PlayerPrefs.SetString("Menu_FullScreen", "true");
        PlayerPrefs.SetInt("Menu_Resolution", reset_Resulution);
        save_Data_Extract();

    }
    public void Back_Button_Click()
    {
        AM.play("buttonClick");
        save_Data_Extract();
        MainMenu.SetActive(true);
        OptionMenu.SetActive(false);
     
    }


}
