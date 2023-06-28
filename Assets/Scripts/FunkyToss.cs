using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FunkyToss : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager managerScript;
    public KeyCode toss;
    public KeyCode toss2;
    public Animation tossAnim;
    public GameObject funky;
    public int player;

    // Start is called before the first frame update
    void Start()
    {
        funky.GetComponent<Renderer>().enabled = false;
        funky.GetComponent<Collider>().enabled = false;
        managerScript = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (managerScript.gameOver == false)
        {
            if (managerScript.player1Busy == false && Input.GetKeyDown(toss) && managerScript.player1Stam >= 35 && player == 1)
            {
                managerScript.player1Busy = true;
                managerScript.player1Swing = true;
                managerScript.player1Stam -= 35;
                funky.GetComponent<Renderer>().enabled = true;
                funky.GetComponent<Collider>().enabled = true;
                StartCoroutine(Tossing());
            }
            if (managerScript.player2Busy == false && Input.GetKeyDown(toss2) && managerScript.player2Stam >= 35 && player == 2)
            {
                managerScript.player2Busy = true;
                managerScript.player2Swing = true;
                managerScript.player2Stam -= 35;
                funky.GetComponent<Renderer>().enabled = true;
                funky.GetComponent<Collider>().enabled = true;
                StartCoroutine(Tossing2());
            }
        }
    }

    IEnumerator Tossing()
    {
        tossAnim.Play("FunkyToss");
        yield return new WaitForSeconds(0.6f);
        funky.GetComponent<Renderer>().enabled = false;
        funky.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(0.15f);
        if (managerScript.player1Stun == false)
        {
            managerScript.player1Busy = false;
        }
        managerScript.player1Swing = false;
    }

    IEnumerator Tossing2()
    {
        tossAnim.Play("FunkyToss");
        yield return new WaitForSeconds(0.6f);
        funky.GetComponent<Renderer>().enabled = false;
        funky.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(0.15f);
        if (managerScript.player2Stun == false)
        {
            managerScript.player2Busy = false;
        }
        managerScript.player2Swing = false;
    }
}