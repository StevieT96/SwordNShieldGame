using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.SocialPlatforms.Impl;

public class CollisionSword1 : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager managerScript;

    public GameObject sword1;
    public GameObject sword2;

    public GameObject player1;
    public GameObject player2;

    public int player; // Assigned in Unity editor as either 1 or 2 depending on whose sword this script is attached to.

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
        if (other.gameObject.tag == "Sword" && gameObject.GetComponent<MeshRenderer>().material.color == Color.white && other.gameObject.GetComponent<MeshRenderer>().material.color == Color.white)
        {
            managerScript.player1Busy = true;
            managerScript.player2Busy = true;
            sword1.GetComponent<Renderer>().enabled = false;
            sword1.GetComponent<Collider>().enabled = false;
            sword2.GetComponent<Renderer>().enabled = false;
            sword2.GetComponent<Collider>().enabled = false;
            managerScript.player1Knock = true;
            managerScript.player2Knock = true;
            StartCoroutine(KnockbackS());
        }
        // The following if statement performs sound, knockback, etc. for when both shields clash (while they are both blue, meaning neither is a sword).
        if (other.gameObject.tag == "Sword" && other.gameObject.GetComponent<MeshRenderer>().material.color == Color.blue && gameObject.GetComponent<MeshRenderer>().material.color == Color.blue)
        {
            managerScript.player1Busy = true;
            managerScript.player2Busy = true;
            sword1.GetComponent<Renderer>().enabled = false;
            sword1.GetComponent<Collider>().enabled = false;
            sword2.GetComponent<Renderer>().enabled = false;
            sword2.GetComponent<Collider>().enabled = false;
            managerScript.player1Knock = true;
            managerScript.player2Knock = true;
            StartCoroutine(KnockbackS());
        }
        // The following two if statements perform sound, knockback, STUN, etc. for when a player sword hits an opponent's shield (which is actually a blue sword).
        if (other.gameObject.tag == "Sword" && other.gameObject.GetComponent<MeshRenderer>().material.color == Color.blue && gameObject.GetComponent<MeshRenderer>().material.color == Color.white && player == 1)
        {
            managerScript.player1Busy = true;
            sword1.GetComponent<Renderer>().enabled = false;
            sword1.GetComponent<Collider>().enabled = false;
            managerScript.player1Knock = true;
            managerScript.player1Stun = true;
            StartCoroutine(KnockbackB1());
        }
        if (other.gameObject.tag == "Sword" && other.gameObject.GetComponent<MeshRenderer>().material.color == Color.blue && gameObject.GetComponent<MeshRenderer>().material.color == Color.white && player == 2)
        {
            managerScript.player2Busy = true;
            sword2.GetComponent<Renderer>().enabled = false;
            sword2.GetComponent<Collider>().enabled = false;
            managerScript.player2Knock = true;
            managerScript.player2Stun = true;
            StartCoroutine(KnockbackB2());
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
    IEnumerator KnockbackS()
    {
        yield return new WaitForSeconds(0.15f);
        managerScript.player1Knock = false;
        managerScript.player2Knock = false;
        managerScript.player1Busy = false;
        managerScript.player2Busy = false;
    }

    IEnumerator KnockbackB1()
    {
        yield return new WaitForSeconds(0.15f);
        managerScript.player1Knock = false;
        yield return new WaitForSeconds(1.5f);
        managerScript.player1Busy = false;
        managerScript.player1Stun = false;
    }
    IEnumerator KnockbackB2()
    {
        yield return new WaitForSeconds(0.15f);
        managerScript.player2Knock = false;
        yield return new WaitForSeconds(1.5f);
        managerScript.player2Busy = false;
        managerScript.player2Stun = false;
    }
}