using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class OnReset : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager managerScript;

    public Button resetButton;

    public GameObject player1;
    public GameObject player2;
    public GameObject player1Graphic;
    public GameObject player2Graphic;

    public Transform player1Start;
    public Transform player2Start;

    // Start is called before the first frame update
    void Start()
    {
        managerScript = gameManager.GetComponent<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            OnButtonPressed();
            StartCoroutine(Resetting2());
        }
    }

    public void OnButtonPressed()
    {
        player1.GetComponent<CharacterController>().enabled = false;
        player2.GetComponent<CharacterController>().enabled = false;
        managerScript.gameOver = false;
        managerScript.roundActive = false;
        managerScript.player1Health = 3;
        managerScript.player2Health = 3;
        managerScript.player1Stam = 100;
        managerScript.player2Stam = 100;
        managerScript.player1Knock = false;
        managerScript.player2Knock = false;
        managerScript.player1Busy = true;
        managerScript.player2Busy = true;
        player1.transform.position = player1Start.position;
        player2.transform.position = player2Start.position;
        StartCoroutine(Resetting());
    }

    IEnumerator Resetting()
    {
        yield return new WaitForSeconds(2f);
        managerScript.player1Stam = 100;
        managerScript.player2Stam = 100;
        managerScript.gameOver = false;
        managerScript.player1Stun = false;
        managerScript.player2Stun = false;
        managerScript.player1Busy = false;
        managerScript.player2Busy = false;
        managerScript.roundActive = true;
        player1.transform.position = player1Start.position;
        player2.transform.position = player2Start.position;
        player1Graphic.transform.rotation = player1Start.rotation;
        player2Graphic.transform.rotation = player2Start.rotation;
        player1.GetComponent<CharacterController>().enabled = true;
        player2.GetComponent<CharacterController>().enabled = true;
    }

    IEnumerator Resetting2()
    {
        yield return new WaitForSeconds(2f);
    }
}
