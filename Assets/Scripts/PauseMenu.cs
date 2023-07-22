using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject gameUIObject;
    public GameObject pauseBackground;
    public GameObject pauseScreenObject;
    public GameObject settingsMenuObject;

    public bool menuOpen;
    
    // Start is called before the first frame update
    void Start()
    {
        gameUIObject.SetActive(true);
        pauseBackground.SetActive(false);
        pauseScreenObject.SetActive(false);
        settingsMenuObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menuOpen)
            {
                menuOpen = true;
                gameUIObject.SetActive(false);
                pauseBackground.SetActive(true);
                pauseScreenObject.SetActive(true);
                Time.timeScale = 0f;
                audioMixer.SetFloat("MusicLowpass", 875.00f);
            }

            else
            {
                ResumeGame();
            }
        }
    }

    public void SettingsMenuOpen()
    {
        pauseScreenObject.SetActive(false);
        settingsMenuObject.SetActive(true);
    }

    public void SettingsMenuClose()
    {
        pauseScreenObject.SetActive(true);
        settingsMenuObject.SetActive(false);
    }

    public void ResumeGame()
    {
        menuOpen = false;
        gameUIObject.SetActive(true);
        pauseBackground.SetActive(false);
        pauseScreenObject.SetActive(false);
        settingsMenuObject.SetActive(false);
        Time.timeScale = 1f;
        audioMixer.SetFloat("MusicLowpass", 22000.00f);
    }
}
