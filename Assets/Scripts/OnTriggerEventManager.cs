using System;
using System.Collections;
using System.Collections.Generic;
using ThirdBridge.Events;
using UnityEngine;

public class OnTriggerEventManager : MonoBehaviour
{

    public SimpleStateEvent TriggerEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerEvent?.Invoke();
        }
    }
}
