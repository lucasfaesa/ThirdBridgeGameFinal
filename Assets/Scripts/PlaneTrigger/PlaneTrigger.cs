using System;
using System.Collections;
using System.Collections.Generic;
using ThirdBridge.Events;
using UnityEngine;


public class PlaneTrigger : MonoBehaviour
{

    public SimpleStateEvent PlaneTriggerStatus;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlaneTriggerStatus?.Invoke();
            this.gameObject.SetActive(false);
            Debug.Log("Triggered");
        }
    }
}
