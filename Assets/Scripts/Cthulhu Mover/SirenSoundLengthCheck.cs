using System.Collections;
using System.Collections.Generic;
using ThirdBridge.Events;
using UnityEngine;

public class SirenSoundLengthCheck : MonoBehaviour
{

    public SimpleStateEvent endedSirenSound;
    
    [SerializeField] private AudioSource sirenAudioSource;

    public void CheckSirenSoundLenght()
    {
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(sirenAudioSource.clip.length - 0.3f);
        endedSirenSound?.Invoke();        
    }
    
}
