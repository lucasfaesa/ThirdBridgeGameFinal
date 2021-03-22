using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaLerp : MonoBehaviour
{
    [SerializeField] private Image imageToChangeAlpha;  
    [SerializeField] private float lerpTime = 0.15f;
    
    [Range(0.0f, 1.0f)]
    [SerializeField] private float startAlpha = 0f;

    [Range(0.0f, 1.0f)]
    [SerializeField] private float targetAlpha = 1f;
    
    private bool makeOpaque;
    private Coroutine goRoutine;
    private Coroutine returnRoutine;

    private void Start()
    {
        ChangeAlphaOfImage();
    }

    public void ChangeAlphaOfImage()
    {
        makeOpaque = !makeOpaque;
        
        if (makeOpaque)
        {
            if (returnRoutine != null)
            {
                StopCoroutine(returnRoutine);
            }

            goRoutine = StartCoroutine(LerpToAlpha(imageToChangeAlpha, lerpTime, targetAlpha));
        }
        else
        {
            if (goRoutine != null)
            {
                StopCoroutine(goRoutine);
            }

            returnRoutine = StartCoroutine(LerpToAlpha(imageToChangeAlpha, lerpTime, startAlpha));
        }
    }

    private IEnumerator LerpToAlpha(Image image, float timeToLerp, float targetAlpha)
    {
        float elapsedTime = 0;
        float actualAlpha = image.color.a;
        
        while (elapsedTime < timeToLerp)
        {
            elapsedTime += Time.deltaTime;

            image.color = new Color(image.color.r, image.color.g, image.color.b, (Mathf.Lerp(actualAlpha, targetAlpha, elapsedTime / timeToLerp)));

            yield return null;
        }
        
        this.gameObject.SetActive(false);
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
    }
}