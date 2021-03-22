using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsController : MonoBehaviour
{
    [SerializeField] private GameObject menuObject;

    [SerializeField] private bool showMenu = true;
    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ShowHideMenu();
        }
    }

    public void ShowHideMenu()
    {
        showMenu = !showMenu;
        menuObject.SetActive(showMenu);
    }
}
