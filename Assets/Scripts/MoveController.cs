using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveController : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager managerScript;
    public KeyCode swing;
    public KeyCode stab;
    public KeyCode block;
    public Animation swingAnim;
    public GameObject sword;

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
            // The following if statements perform animation, 'busy' status updates, sound, stamina depletion, etc. for when a player inputs one of their 3 Moves.
            if (managerScript.player1Busy == false && Input.GetKeyDown(swing) && managerScript.player1Stam >= 30)
            {
                managerScript.player1Busy = true;
                managerScript.player1Swing = true;
                managerScript.player1Stam -= 30;
                sword.GetComponent<Renderer>().enabled = true;
                sword.GetComponent<Collider>().enabled = true;
                StartCoroutine(SwingTime1());
            }
            if (managerScript.player1Busy == false && Input.GetKeyDown(stab) && managerScript.player1Stam >= 20)
            {
                managerScript.player1Busy = true;
                managerScript.player1Stab = true;
                managerScript.player1Stam -= 20;
                sword.GetComponent<Renderer>().enabled = true;
                sword.GetComponent<Collider>().enabled = true;
                StartCoroutine(StabTime1());
            }
            if (managerScript.player1Busy == false && Input.GetKeyDown(block) && managerScript.player1Stam >= 30)
            {
                managerScript.player1Busy = true;
                managerScript.player1Block = true;
                managerScript.player1Stam -= 30;
                sword.GetComponent<MeshRenderer>().material.color = Color.blue;
                sword.GetComponent<Renderer>().enabled = true;
                sword.GetComponent<Collider>().enabled = true;
                StartCoroutine(BlockTime1());
            }
        }
    }
    // The following IEnumerators perform animation timings, 'busy' status update timings, etc. for the respective above checks.
    IEnumerator SwingTime1()
    {
        swingAnim.Play("Swing");
        yield return new WaitForSeconds(0.333f);
        sword.GetComponent<Renderer>().enabled = false;
        sword.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(0.15f);
        if (managerScript.player1Stun == false)
        {
            managerScript.player1Busy = false;
        }
        managerScript.player1Swing = false;
    }
    IEnumerator StabTime1()
    {
        swingAnim.Play("Stab");
        yield return new WaitForSeconds(0.2f);
        sword.GetComponent<Renderer>().enabled = false;
        sword.GetComponent<Collider>().enabled = false;
        managerScript.player1Stab = false;
        yield return new WaitForSeconds(0.15f);
        if (managerScript.player1Stun == false)
        {
            managerScript.player1Busy = false;
        }
    }
    IEnumerator BlockTime1()
    {
        swingAnim.Play("Block");
        yield return new WaitForSeconds(0.3f);
        sword.GetComponent<Renderer>().enabled = false;
        sword.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(0.4f);
        if (managerScript.player1Stun == false)
        {
            managerScript.player1Busy = false;
        }
        managerScript.player1Block = false;
        sword.GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
