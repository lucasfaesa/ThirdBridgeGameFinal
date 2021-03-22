using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceFadeOut : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    
    public void FadeOut()
    {
        StartCoroutine(FadeInFadeOut());
    }
    
    private IEnumerator FadeInFadeOut()
    {
        float currentTime = 0;

        while (currentTime < 4f)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(1f, 0f, currentTime / 4f);
            yield return null;
        }
        
    }
}
