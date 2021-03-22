using UnityEngine;
using System.Collections;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class CameraShake : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;
	
    // How long the object should shake for.
    public float shakeDuration = 0f;
	
    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
	
    Vector3 originalPos;
    
	
    void OnEnable()
    {
        originalPos = camTransform.localPosition;
        StartCoroutine(IncreaseShake());
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }

    private IEnumerator IncreaseShake()
    {
        float elapsedTime = 0;

        while (elapsedTime < 10f)
        {
            elapsedTime += Time.deltaTime;

                shakeAmount = Mathf.Lerp(0.01f, 0.12f, elapsedTime/10f);

            yield return null;
        } 
    }
}