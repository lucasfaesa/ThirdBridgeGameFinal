using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{

    [SerializeField] private GameObject canvasObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasObject.SetActive(true);
        }
    }
}
