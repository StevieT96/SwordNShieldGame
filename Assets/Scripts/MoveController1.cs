using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveController1 : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager managerScript;
    public KeyCode swing;
    public KeyCode stab;
    public KeyCode block;
    public Animation swingAnim;
    public GameObject sword;
    public AudioSource NoEnergy;

    // Start is called before the first frame update
    private void Start()
    {
        sword.GetComponent<Renderer>().enabled = false;
        sword.GetComponent<Collider>().enabled = false;
        managerScript = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (managerScript.gameOver == false)
        {
            if (managerScript.player2Busy == false && Input.GetKeyDown(swing) && managerScript.player2Stam >= 30)
            {
                managerScript.player2Busy = true;
                managerScript.player2Swing = true;
                managerScript.player2Stam -= 30;
                sword.GetComponent<Renderer>().enabled = true;
                sword.GetComponent<Collider>().enabled = true;
                StartCoroutine(SwingTime2());
            }
            {
                if (managerScript.player1Busy == false && Input.GetKeyDown(swing) && managerScript.player2Stam <= 30)
                {
                    NoEnergy.Play();
                }
;

            }
            if (managerScript.player2Busy == false && Input.GetKeyDown(stab) && managerScript.player2Stam >= 20)
            {
                managerScript.player2Busy = true;
                managerScript.player2Stab = true;
                managerScript.player2Stam -= 20;
                sword.GetComponent<Renderer>().enabled = true;
                sword.GetComponent<Collider>().enabled = true;
                StartCoroutine(StabTime2());
            }
            {
                if (managerScript.player1Busy == false && Input.GetKeyDown(stab) && managerScript.player2Stam <= 30)
                {
                    NoEnergy.Play();
                }
;

            }
            if (managerScript.player2Busy == false && Input.GetKeyDown(block) && managerScript.player2Stam >= 30)
            {
                managerScript.player2Busy = true;
                managerScript.player2Block = true;
                managerScript.player2Stam -= 30;
                sword.GetComponent<MeshRenderer>().material.color = Color.blue;
                sword.GetComponent<Renderer>().enabled = true;
                sword.GetComponent<Collider>().enabled = true;
                StartCoroutine(BlockTime2());
            }
            {
                if (managerScript.player1Busy == false && Input.GetKeyDown(block) && managerScript.player2Stam <= 30)
                {
                    NoEnergy.Play();
                }
;

            }
        }        
    }
    IEnumerator SwingTime2()
    {
        swingAnim.Play("Swing");
        yield return new WaitForSeconds(0.333f);
        sword.GetComponent<Renderer>().enabled = false;
        sword.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(0.15f);
        if (managerScript.player2Stun == false)
        {
            managerScript.player2Busy = false;
        }
        managerScript.player2Swing = false;
    }
    IEnumerator StabTime2()
    {
        swingAnim.Play("Stab");
        yield return new WaitForSeconds(0.2f);
        sword.GetComponent<Renderer>().enabled = false;
        sword.GetComponent<Collider>().enabled = false;
        managerScript.player2Stab = false;
        yield return new WaitForSeconds(0.15f);
        if (managerScript.player2Stun == false)
        {
            managerScript.player2Busy = false;
        }
    }
    IEnumerator BlockTime2()
    {
        swingAnim.Play("Block");
        yield return new WaitForSeconds(0.3f);
        sword.GetComponent<Renderer>().enabled = false;
        sword.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(0.4f);
        if (managerScript.player2Stun == false)
        {
            managerScript.player2Busy = false;
        }
        managerScript.player2Block = false;
        sword.GetComponent<MeshRenderer>().material.color = Color.white;
    }
}