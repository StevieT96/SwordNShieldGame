using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public GameObject mainMenuParent;
    public GameObject settingsMenuParent;
    
    public void OnSettingsActivate()
    {
        mainMenuParent.SetActive(false);
        settingsMenuParent.SetActive(true);
    }

    public void OnSettingsExit()
    {
        mainMenuParent.SetActive(true);
        settingsMenuParent.SetActive(false);
    }
}
