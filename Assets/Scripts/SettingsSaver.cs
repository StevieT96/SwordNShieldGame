using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsSaver : MonoBehaviour
{
    public Slider SFXSlider;
    public Slider musicSlider;
        
    private float SFXValue;
    private float musicValue;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        SFXValue = SFXSlider.value;
        musicValue = musicSlider.value;
    }
}
