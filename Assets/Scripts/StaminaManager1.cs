using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaManager1 : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager managerScript;
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
            if (managerScript.player2Busy == false && managerScript.roundActive == true && managerScript.gameOver == false)
            {
                if (managerScript.player2Stam <= 95)
                {
                    managerScript.player2Stam += 5;
                }

                //----If the stamina is equal to 100, play energy full sound----
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
}
