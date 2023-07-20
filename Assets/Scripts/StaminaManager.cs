using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaManager : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager managerScript;

    private bool isRecharging;

    [SerializeField] private AudioSource blueAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        managerScript = gameManager.GetComponent<GameManager>();
        StartCoroutine(Regen());
    }

    IEnumerator Regen()
    {
        while (true)
        {
            if (managerScript.player1Busy == false && managerScript.roundActive == true && managerScript.gameOver == false)
            {
                if (managerScript.player1Stam <= 95)
                {
                    managerScript.player1Stam += 5;
                    isRecharging = true;
                }

                if (isRecharging && managerScript.player1Stam == 100)
                {
                    blueAudioSource.Play();
                    isRecharging = false;
                }
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
}
