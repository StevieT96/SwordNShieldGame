using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreenUI : MonoBehaviour
{
    public GameObject purplePanel;
    public GameObject redWinText;
    public GameObject blueWinText;
    public GameObject replayButton;
    public GameObject exitButton;

    public Transform purplePanelBluePos;
    public Transform purplePanelRedPos;
    public Transform replayButtonBluePos;
    public Transform replayButtonRedPos;
    public Transform exitButtonBluePos;
    public Transform exitButtonRedPos;

    void Update()
    {
        bool blueHasWon = GameObject.Find("Win Screen Camera").GetComponent<WinScreenChanger>().hasBlueWon;

        if (blueHasWon)
        {
            blueWinText.SetActive(true);
            redWinText.SetActive(false);

            purplePanel.transform.position = purplePanelBluePos.transform.position;
            purplePanel.transform.rotation = purplePanelBluePos.transform.rotation;
            replayButton.transform.position = replayButtonBluePos.transform.position;
            exitButton.transform.position = exitButtonBluePos.transform.position;
        }

        else
        {
            blueWinText.SetActive(false);
            redWinText.SetActive(true);

            purplePanel.transform.position = purplePanelRedPos.transform.position;
            purplePanel.transform.rotation = purplePanelRedPos.transform.rotation;
            replayButton.transform.position = replayButtonRedPos.transform.position;
            exitButton.transform.position = exitButtonRedPos.transform.position;
        }
    }

    public void RematchSceneLoad()
    {
        Destroy(GameObject.Find("Win Screen Camera"));
        Destroy(GameObject.Find("Win Screen Transforms"));
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitSceneLoad()
    {
        Destroy(GameObject.Find("Win Screen Camera"));
        Destroy(GameObject.Find("Win Screen Transforms"));
        SceneManager.LoadScene("MainMenu");
    }
}
