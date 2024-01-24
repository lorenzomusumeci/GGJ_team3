using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider slider;

    public void UpdateHealthBar(int currentValue, int maxValue)
    {
        slider.maxValue = maxValue;

        slider.minValue = 0;

        slider.value = currentValue;
    }
}
