using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider slider;
    public Image redScreen;
    public Image backgroundImage;
    public Sprite backgroundSprite;
    public Sprite balenaSprite;
    public Sprite ranaSprite;
    public Sprite seppiaSprite;

    private void Update()
    {
        backgroundImage.sprite = backgroundSprite;
    }

    public void UpdateHealthBar(int currentValue, int maxValue)
    {
        slider.maxValue = maxValue;

        slider.minValue = 0;

        slider.value = currentValue;
    }
}
