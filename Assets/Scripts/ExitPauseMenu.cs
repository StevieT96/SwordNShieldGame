using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ExitPauseMenu : MonoBehaviour
{
    public GameObject gameUIParent;
    public GameObject pauseScreenParent;
    public AudioMixer audioMixer;
    public bool isExitButton;
    
    public void ExitMenuOnClick()
    {
        Time.timeScale = 1.0f;
        gameUIParent.SetActive(true);
        pauseScreenParent.SetActive(false);
        audioMixer.SetFloat("MusicLowpass", 22000.00f);

        if (isExitButton)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
