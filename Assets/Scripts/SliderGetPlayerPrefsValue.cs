using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderGetPlayerPrefsValue : MonoBehaviour
{
    [SerializeField] private Slider sliderSensivity;
    private void OnEnable()
    {
        sliderSensivity.value = PlayerPrefs.GetFloat("mouseSensivity");
    }
}
