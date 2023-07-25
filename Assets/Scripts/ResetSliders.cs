using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetSliders : MonoBehaviour
{
    public Slider sfxSlider;
    public Slider musicSlider;

    public float sfxSliderValue;
    public float musicSliderValue;
    
    public void OnClickResetSliders()
    {
        sfxSlider.value = sfxSliderValue;
        musicSlider.value = musicSliderValue;
    }
}
