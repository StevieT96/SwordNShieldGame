using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenChanger : MonoBehaviour
{
    public bool hasBlueWon;

    public Transform redWinScreen;
    public Transform blueWinScreen;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (hasBlueWon)
        {
            transform.rotation = blueWinScreen.transform.rotation;
        }

        else
        {
            transform.rotation = redWinScreen.transform.rotation;
        }
    }
}
