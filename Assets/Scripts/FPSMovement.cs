using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager managerScript;
    public KeyCode forward;
    public KeyCode back;
    public KeyCode left;
    public KeyCode right;
    public CharacterController charController;
    public float movementSpeed = 8f;
    public float dashSpeed = 10f;
    private float finalSpeed = 0;
    public GameObject target;
    public Transform playerTrans;
    public Transform playerGraphic;

    // Awake is called before Start 
    void Awake()
    {
        finalSpeed = movementSpeed;
    }

    private void Start()
    {
        managerScript = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame 
    void Update()
    {
        if (managerScript.gameOver == false)
        {
            if (managerScript.roundActive == true && managerScript.player1Busy == false)
            {
                MoveInputCheck();
            }
            if (managerScript.player1Knock == true)
            {
                KnockPlayer(target.transform.position);
            }
            if (managerScript.player1Stab == true)
            {
                DashPlayer(playerGraphic.transform.forward);
            }
        }
    }

    void MoveInputCheck()
    {
        float x = Input.GetAxis("Horizontal2"); 
        float z = Input.GetAxis("Vertical2");
        Vector3 move = Vector3.zero; 

        if (Input.GetKey(forward) || Input.GetKey(back) || Input.GetKey(left) || Input.GetKey(right)) 
        { 
            move = transform.right * x + transform.forward * z;        
        } 

        move = Vector3.ClampMagnitude(move, 1f); // Removes diagonal movement being faster.

        MovePlayer(move); 
    }

    void MovePlayer(Vector3 move)
    {
        charController.Move(move * finalSpeed * Time.deltaTime);
    }

    void DashPlayer(Vector3 move)
    {
        charController.Move(move * dashSpeed * Time.deltaTime);
    }

    void KnockPlayer(Vector3 targetvector)
    {
        var offset = targetvector - playerTrans.position;
        if (offset.magnitude > .1f)
        {
            offset = offset.normalized * -13f;
            charController.Move(offset * Time.deltaTime);
        }
        // While a player's Knock value is 'true' this function will translate them away from their opponent.
    }
}