using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalBlowManager : MonoBehaviour
{
    public GameObject winScreenCamera;
    
    public IEnumerator FinalBlow(bool blueHasWon)
    {
        yield return new WaitForSeconds(1f);

        winScreenCamera.SetActive(true);
        winScreenCamera.GetComponent<WinScreenChanger>().hasBlueWon = blueHasWon;

        SceneManager.LoadScene("Win Screen");
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
