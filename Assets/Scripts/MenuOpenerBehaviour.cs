using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VHS;

public class MenuOpenerBehaviour : MonoBehaviour
{
    [SerializeField] private CharacterController playerCharacterController;
    [SerializeField] private FirstPersonController playerFps;
    [SerializeField] private InputHandler playerInputHandler;
    [SerializeField] private CameraController playerCameraController;
    

    // Start is called before the first frame update
    private void OnEnable()
    {
        
        playerFps.enabled = false;
        playerCameraController.enabled = false;
        playerInputHandler.enabled = false;
        playerCharacterController.enabled = false;
        playerCameraController.ChangeCursorLockState(false);
    }
    
    private void OnDisable()
    {
        playerFps.enabled = true;
        playerCameraController.enabled = true;
        playerInputHandler.enabled = true;
        playerCharacterController.enabled = true;
        playerCameraController.ChangeCursorLockState(true);
    }
}
