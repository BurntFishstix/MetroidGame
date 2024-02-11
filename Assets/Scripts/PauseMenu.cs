using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject PauseButton;
    public GameObject ControlButton;
    public GameObject ControlScreen;
    public static bool GameIsPaused = false;

    void Start()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
        PauseButton.SetActive(false);
        ControlButton.SetActive(false);
        ControlScreen.SetActive(false);
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
        PauseButton.SetActive(true);
        ControlButton.SetActive(true);
    }
    
    public void Options()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void Controls()
    {
        ControlButton.SetActive(false);
        ControlScreen.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Continue();
            ControlScreen.SetActive(false);
        }
        else{
            
        }

    }
    public void Exit()
    {
        Debug.Log("Returning to Main Menu...");
        SceneManager.LoadScene("MainMenu");
    }
}
