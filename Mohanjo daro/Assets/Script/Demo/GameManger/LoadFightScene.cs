using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFightScene : MonoBehaviour
{

    public GameObject currentPosition;
    public GameObject mainCamera;
    public GameObject cinemachine;

    public string SceneToLoad;
    private ActivePlayer AP;

   
    // Start is called before the first frame update
    void Start()
    {
        if (Globalvariable.NotDestroyed_Player != null)
        {
            currentPosition = Globalvariable.NotDestroyed_Player;
            mainCamera = Globalvariable.NotDestroyed_MainCamera;
            cinemachine = Globalvariable.NotDestroyed_CineMachine;
        }

        AP = FindObjectOfType<ActivePlayer>();
       
        
       

        currentPosition.SetActive(true);
        mainCamera.SetActive(true);
        cinemachine.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Globalvariable.Player_win == true)
        {
            Globalvariable.Player_win = false;
            currentPosition.transform.position = Globalvariable.Player_Position;

        }
        if (Globalvariable.Fight_Scene_Load_freqency>15)
        {
            Globalvariable.Player_Position = currentPosition.transform.position;
            Globalvariable.Current_Scene = SceneManager.GetActiveScene().name;

            Globalvariable.NotDestroyed_Player = currentPosition;
            Globalvariable.NotDestroyed_MainCamera = mainCamera;
            Globalvariable.NotDestroyed_CineMachine = cinemachine;

            currentPosition.SetActive(false);
            mainCamera.SetActive(false);
            cinemachine.SetActive(false);

           
            Globalvariable.Fight_Scene_Load_freqency = 0;
            SceneManager.LoadScene(SceneToLoad);
        }

    }
}
