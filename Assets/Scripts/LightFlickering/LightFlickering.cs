using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;


public class LightFlickering : MonoBehaviour
{
    [SerializeField] private Light lampLight;
    [SerializeField] private SpriteRenderer spriteRender;
    [Range(0.01f, 0.5f)]
    [SerializeField] private float delayToFlick = 0.2f;
    [SerializeField] private bool flickLights;
    
    private float timer = 0;
    private float valor;
    
    private void FixedUpdate()
    {
        if (flickLights)
        {
            timer += Time.fixedDeltaTime;
            
            if (timer >= delayToFlick)
            {
                valor = Random.value;

                if (valor >= 0.5f)
                {
                    lampLight.intensity = 310.8f;
                    spriteRender.color = Color.white;
                }
                else
                {
                    lampLight.intensity = 0f;
                    spriteRender.color = Color.black;
                }

                timer = 0;
            }
        }
    }
}
