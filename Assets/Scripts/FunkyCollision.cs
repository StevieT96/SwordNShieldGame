using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.SocialPlatforms.Impl;

public class FunkyCollision : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager managerScript;

    public GameObject sword1;
    public GameObject sword2;

    public GameObject player1;
    public GameObject player2;

    public int player; // Assigned in Unity editor as either 1 or 2 depending on whose sword this script is attached to.

    public AudioSource fumoHitSource;

    // Start is called before the first frame update
    void Start()
    {
        managerScript = gameManager.GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // The following two if statements perform damage, round active state update, sound, knockback, etc. for when a player weapon hits a player.
        if (other.gameObject.tag == "Player2" && player == 1)
        {
            if (managerScript.player2Health >= 1)
            {
                managerScript.player2Health -= 1;
            }
            fumoHitSource.Play();
            managerScript.roundActive = false;
            managerScript.player1Busy = true;
            managerScript.player2Busy = true;
            sword1.GetComponent<Renderer>().enabled = false;
            sword1.GetComponent<Collider>().enabled = false;
            sword2.GetComponent<Renderer>().enabled = false;
            sword2.GetComponent<Collider>().enabled = false;
            managerScript.player2Knock = true;
            StartCoroutine(Knockback2());
        }
        if (other.gameObject.tag == "Player1" && player == 2)
        {
            if (managerScript.player1Health >= 1)
            {
                managerScript.player1Health -= 1;
            }
            fumoHitSource.Play();
            managerScript.roundActive = false;
            managerScript.player1Busy = true;
            managerScript.player2Busy = true;
            sword1.GetComponent<Renderer>().enabled = false;
            sword1.GetComponent<Collider>().enabled = false;
            sword2.GetComponent<Renderer>().enabled = false;
            sword2.GetComponent<Collider>().enabled = false;
            managerScript.player1Knock = true;
            StartCoroutine(Knockback1());
        }
        // The following if statement performs sound, knockback, etc. for when both swords clash (while they are both white, meaning neither is a shield).
        if (other.gameObject.tag == "Sword")
        {
            managerScript.player1Busy = true;
            managerScript.player2Busy = true;
            sword1.GetComponent<Renderer>().enabled = false;
            sword1.GetComponent<Collider>().enabled = false;
            sword2.GetComponent<Renderer>().enabled = false;
            sword2.GetComponent<Collider>().enabled = false;
            StartCoroutine(KnockbackS());
        }
        // The following two if statements check if either player is dead, triggering a Game Over.
        if (managerScript.player1Health == 0)
        {
            managerScript.roundActive = false;
            managerScript.gameOver = true;
        }
        if (managerScript.player2Health == 0)
        {
            managerScript.roundActive = false;
            managerScript.gameOver = true;
        }
    }
    //The following IEnumerators are all knockback and stun timing sequences for the various checks performed above.
    IEnumerator KnockbackS()
    {
        yield return new WaitForSeconds(0.2f);
        managerScript.roundActive = true;
        managerScript.player1Busy = false;
        managerScript.player2Busy = false;
    }

    IEnumerator Knockback1()
    {
        yield return new WaitForSeconds(0.333f);
        managerScript.player1Knock = false;
        yield return new WaitForSeconds(0.2f);
        managerScript.roundActive = true;
        managerScript.player1Busy = false;
        managerScript.player2Busy = false;
    }

    IEnumerator Knockback2()
    {
        yield return new WaitForSeconds(0.333f);
        managerScript.player2Knock = false;
        yield return new WaitForSeconds(0.2f);
        managerScript.roundActive = true;
        managerScript.player1Busy = false;
        managerScript.player2Busy = false;
    }
}