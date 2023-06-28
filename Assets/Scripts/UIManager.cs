using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager managerScript;

    public PropertyMeter stamMeter;
    public PropertyMeter stamMeter2;

    public Text p1HP;
    public Text p2HP;
    public Text p1Stam;
    public Text p2Stam;
    public Text GameOver;
    public Text Prompt;

    private bool promptUp = true;
    private void Start()
    {
        managerScript = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        stamMeter.UpdateMeter(managerScript.player1Stam, 100);
        stamMeter2.UpdateMeter(managerScript.player2Stam, 100);
        p1HP.text = managerScript.player1Health.ToString();
        p2HP.text = managerScript.player2Health.ToString();
        p1Stam.text = managerScript.player1Stam.ToString();
        p2Stam.text = managerScript.player2Stam.ToString();
        if (managerScript.player1Busy == true)
        {
            p1Stam.color = Color.red;
        }
        else if (managerScript.player1Busy == false)
        {
            p1Stam.color = Color.white;
        }
        if (managerScript.player2Busy == true)
        {
            p2Stam.color = Color.red;
        }
        else if (managerScript.player2Busy == false)
        {
            p2Stam.color = Color.white;
        }
        if (managerScript.gameOver == true && managerScript.player1Health == 0)
        {
            GameOver.color = Color.red;
            GameOver.text = "GAME OVER\nP2 Wins!";
        }
        else if (managerScript.gameOver == true && managerScript.player2Health == 0)
        {
            GameOver.color = Color.blue;
            GameOver.text = "GAME OVER\nP1 Wins!";
        }
        else if (managerScript.gameOver == false)
        {
            GameOver.text = "";
        }
        if (Input.GetKeyDown(KeyCode.Backspace) && promptUp == true)
        {
            Prompt.text = "";
            promptUp = false;
        }
        else if (Input.GetKeyDown(KeyCode.Backspace) && promptUp == false)
        {
            promptUp = true;
            Prompt.text = "Move: WASD / Arrow Keys\r\n\r\nSlash: B / Left Click (-30)\r\nStab: N / Right Click (-20)\r\nBlock: M / Middle Click (-30)\r\nFumo: H / Right Ctrl (-35)\r\n\r\nReset: Right Shift\r\n\r\nHide/Show This: Backspace";
        }
    }
}
