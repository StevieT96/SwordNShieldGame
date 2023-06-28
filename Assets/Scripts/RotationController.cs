using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RotationController : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager managerScript;
    public Transform target; // This is the "Graphic" child object of the opponent.
    public float speed = 2.0f;

    public int player; // Assigned in Unity editor as either 1 or 2 depending on whose sword this script is attached to.
    private void Start()
    {
        managerScript = gameManager.GetComponent<GameManager>();
    }
    void Update()
    {
        if (managerScript.roundActive == true && managerScript.player1Busy == false && player == 1)
        {
            RotateSteady();
        }
        if (managerScript.roundActive == true && managerScript.player2Busy == false && player == 2)
        {
            RotateSteady();
        }
    }
    // This function performs the gradual rotation of a player's "Graphic" child object (which also contains their weapon) towards their opponent while they are not "busy".
    void RotateSteady()
    {
        float step = speed * Time.deltaTime;

        Vector3 targetDirection = target.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }
}