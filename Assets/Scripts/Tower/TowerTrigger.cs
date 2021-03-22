using System;
using System.Collections;
using System.Collections.Generic;
using ThirdBridge.Events;
using UnityEngine;


public class TowerTrigger : MonoBehaviour
{

    public SimpleStateEvent TowerTriggerStatus;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            TowerTriggerStatus?.Invoke();
            this.gameObject.SetActive(false);
            Debug.Log("Triggered");
        }
    }
    
}
