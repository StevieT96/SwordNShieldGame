using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalBlowManager : MonoBehaviour
{
    public AudioSource battleMusicSource;
    public AudioSource finalBlowSource;
    public GameObject blueAudioSources;
    public GameObject blueMetaAudioSources;
    public GameObject redAudioSources;
    public GameObject redMetaAudioSources;
    public GameObject winScreenCamera;

    private bool finalBlowActive;
    private bool blueHasWonReference;
    
    public void FinalBlow(bool blueHasWon)
    {
        finalBlowActive = true;
        blueHasWonReference = blueHasWon;
        
        battleMusicSource.Stop();
        blueAudioSources.SetActive(false);
        blueMetaAudioSources.SetActive(false);
        redAudioSources.SetActive(false);
        redMetaAudioSources.SetActive(false);

        finalBlowSource.Play();

        Debug.Log("Sounds Done!");
    }

    private void Update()
    {
        if (finalBlowActive)
        {
            if (!finalBlowSource.isPlaying)
            {
                winScreenCamera.SetActive(true);
                winScreenCamera.GetComponent<WinScreenChanger>().hasBlueWon = blueHasWonReference;

                SceneManager.LoadScene("Win Screen");
            }
        }
    }

    /* Add coroutine that when either player dies:
     *      - Stops player movement
     *      - Slows down time
     *      - Plays the final hit noise
     *      - Waits a few seconds
     *      - Shows game over text
     *      - Plays fanfare and crowd cheering sfx
     *      - Waits a few seconds
     *      - Gives prompt to reset or go to main menu
     */
}
