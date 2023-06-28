using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropertyMeter : MonoBehaviour
{
    public Slider meterSlider; // Slider is a Unity class.
    public void UpdateMeter(float currentValue, float maxValue)
    {
        float percentageResult = currentValue / maxValue;
        meterSlider.value = percentageResult;
    }
}
