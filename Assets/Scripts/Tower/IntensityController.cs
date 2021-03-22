using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntensityController : MonoBehaviour
{

    [SerializeField] private Light towerLight;
    [SerializeField] private Renderer cylinder;
    [SerializeField] private float delayTime;
    
    


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoseIntensity());
    }

    private IEnumerator LoseIntensity()
    {
        float elapsedTime = 0;
        float targetIntensity = 0;
        float startIntensity = towerLight.intensity;
        float startColor = 1f;
        float targetColor = 0f;
        while (elapsedTime < delayTime)
        {
            elapsedTime += Time.deltaTime;
            
            towerLight.intensity = Mathf.Lerp(startIntensity, targetIntensity, elapsedTime/delayTime);
            cylinder.material.SetColor("_EmissionColor", new Color(Mathf.Lerp(startColor, targetColor, elapsedTime/delayTime), 0f, 0f, 1f));
            
            yield return null;
        }

        StartCoroutine(GainIntensity());
    }
    
    private IEnumerator GainIntensity()
    {
        float elapsedTime = 0;
        float targetIntensity = 50;
        float startIntensity = towerLight.intensity;
        float startColor = 0f;
        float targetColor = 1f;
        
        while (elapsedTime < delayTime)
        {
            elapsedTime += Time.deltaTime;
            
            towerLight.intensity = Mathf.Lerp(startIntensity, targetIntensity, elapsedTime/delayTime);
            cylinder.material.SetColor("_EmissionColor", new Color(Mathf.Lerp(startColor, targetColor, elapsedTime/delayTime), 0f, 0f, 1f));
            
            yield return null;
        }

        StartCoroutine(LoseIntensity());
    }


    public void ChangeFlick()
    {
        StartCoroutine(ChangeLightFlick());
    }
    
    private IEnumerator ChangeLightFlick()
    {
        yield return new WaitForSeconds(21.6f);
        delayTime = 0.05f;
    }
}
