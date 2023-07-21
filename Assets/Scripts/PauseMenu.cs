using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject gameUIObject;
    public GameObject pauseScreenObject;

    public bool menuOpen;
    
    // Start is called before the first frame update
    void Start()
    {
        gameUIObject.SetActive(true);
        pauseScreenObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menuOpen)
            {
                menuOpen = true;
                gameUIObject.SetActive(false);
                pauseScreenObject.SetActive(true);
                Time.timeScale = 0f;
                audioMixer.SetFloat("MusicLowpass", 875.00f);

                //To Do: Disable all player input during pause (by adding if !menuOpen to input conditional statements)
            }

            else
            {
                menuOpen = false;
                gameUIObject.SetActive(true);
                pauseScreenObject.SetActive(false);
                Time.timeScale = 1f;
                audioMixer.SetFloat("MusicLowpass", 22000.00f);
            }
        }
    }
}
