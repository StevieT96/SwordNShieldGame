using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager managerScript;

    public Transform m_char2;

    [SerializeField] private AudioSource knockbackSource;

    // Start is called before the first frame update
    void Start()
    {
        managerScript = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (managerScript.player2Knock == true)
        {
            m_char2.Translate(Vector3.forward * Time.deltaTime * 50);
            knockbackSource.Play();
        }
    }
}
