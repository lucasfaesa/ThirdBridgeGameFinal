using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatSineWave : MonoBehaviour
{
    Vector3 startPos;
 
    [SerializeField] private float amplitude = 0.6f;
    [SerializeField] private float period = 5f;
    
    private float timer;
    private bool canFloat;
    void Start() {
        startPos = transform.position;
        amplitude = Random.Range(0.3f, 0.8f);
        period = Random.Range(4f, 7f);

        StartCoroutine(BoolChange());
    }
 
    void FixedUpdate() {

        if (canFloat)
        {
            timer += Time.deltaTime;
            float theta = timer / period;
            float distance = amplitude * Mathf.Sin(theta);
            
            transform.position = startPos + Vector3.up * distance;
        }
    }

    IEnumerator BoolChange()
    {
        float time = Random.Range(0, 8);
        
        yield return new WaitForSeconds(time);

        canFloat = true;
    }
}
