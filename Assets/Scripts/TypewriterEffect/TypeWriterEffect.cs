using System.Collections;
using System.Collections.Generic;
using ThirdBridge.Events;
using TMPro;
using UnityEngine;

public class TypeWriterEffect : MonoBehaviour
{
    public SimpleStateEvent nextCredits;
    
    [SerializeField] private TextMeshProUGUI txt;
    [SerializeField] private string text;
    
    
    void Awake () 
    {
        text = txt.text;
        
        txt.text = "";

        // TODO: add optional delay when to start
        StartCoroutine ("PlayText");
    }

    IEnumerator PlayText()
    {
        foreach (char c in text) 
        {
            txt.text += c;
            yield return new WaitForSeconds (0.125f);
        }

        yield return new WaitForSeconds(1.4f);
        
        
        nextCredits?.Invoke();
    }

}
