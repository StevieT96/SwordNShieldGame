using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement2 : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager managerScript;
    public KeyCode forward2;
    public KeyCode back2;
    public KeyCode left2;
    public KeyCode right2;
    public CharacterController charController2;
    public float movementSpeed2 = 8f;
    public float dashSpeed2 = 10f;
    private float finalSpeed2 = 0;
    public GameObject target;
    public Transform player2Trans;
    public Transform player2Graphic;

    // Awake  is called before Start 
    void Awake()
    {
        finalSpeed2 = movementSpeed2;
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
            if (managerScript.roundActive == true && managerScript.player2Busy == false)
            {
                MoveInputCheck2();
            }
            if (managerScript.player2Knock == true)
            {
                KnockPlayer2(target.transform.position);
            }
            if (managerScript.player2Stab == true)
            {
                DashPlayer2(player2Graphic.transform.forward);
            }
        }
    }

    void MoveInputCheck2()
    {
        float x2 = Input.GetAxis("Horizontal");  
        float z2 = Input.GetAxis("Vertical");  
        Vector3 move2 = Vector3.zero;

        if (Input.GetKey(forward2) || Input.GetKey(back2) || Input.GetKey(left2) || Input.GetKey(right2))
        {
            move2 = transform.right * x2 + transform.forward * z2;          
        }

        move2 = Vector3.ClampMagnitude(move2, 1f);

        MovePlayer2(move2); 
    }

    void MovePlayer2(Vector3 move2)
    {
        charController2.Move(move2 * finalSpeed2 * Time.deltaTime);
    }

    void DashPlayer2(Vector3 move)
    {
        charController2.Move(move * dashSpeed2 * Time.deltaTime);
    }

    void KnockPlayer2(Vector3 targetvector)
    {
        var offset = targetvector - player2Trans.position;
        if (offset.magnitude > .1f)
        {
            offset = offset.normalized * -13f;
            charController2.Move(offset * Time.deltaTime);
        }
    }
}