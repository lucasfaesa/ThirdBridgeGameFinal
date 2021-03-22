using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSet : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetFloat("mouseSensivity", 150f);
    }
}
