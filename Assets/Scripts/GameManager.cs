using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Global variable storage script
    public bool roundActive = true;
    public bool gameOver = false;

    public int player1Health = 3;
    public int player2Health = 3;

    public int player1Stam = 100;
    public int player2Stam = 100;

    public bool player1Busy = false;
    public bool player2Busy = false;

    public bool player1Knock = false;
    public bool player2Knock = false;

    public bool player1Stun = false;
    public bool player2Stun = false;

    public bool player1Swing = false;
    public bool player1Stab = false;
    public bool player1Block = false;

    public bool player2Swing = false;
    public bool player2Stab = false;
    public bool player2Block = false;
}