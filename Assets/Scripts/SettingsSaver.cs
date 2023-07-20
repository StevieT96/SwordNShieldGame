using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsSaver : MonoBehaviour
{
    public AudioMixer audioMixer;
    public string audioType;

    private void Start()
    {
        float soundLevel;
        audioMixer.GetFloat(audioType, out soundLevel);
        this.GetComponent<Slider>().value = soundLevel;
    }

    public void SetSound(float soundLevel)
    {
        audioMixer.SetFloat(audioType, soundLevel);
    }
}
