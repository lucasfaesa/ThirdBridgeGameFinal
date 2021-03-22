using System;
using System.Collections;
using System.Collections.Generic;
using ThirdBridge.Events;
using UnityEngine;


public class TrainTrigger : MonoBehaviour
{

    public SimpleStateEvent TrainTriggerStatus;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            TrainTriggerStatus?.Invoke();
            this.gameObject.SetActive(false);
            Debug.Log("Triggered");
        }
    }
    
}
