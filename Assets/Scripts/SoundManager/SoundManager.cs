using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    [SerializeField] public AudioSource audioSource;
    [SerializeField] private AudioSource audioLoop;
    [SerializeField] private AudioClip[] soundEffectsArray;
    
    private enum Sounds
    {
        Search = 0, ColdKiss = 1, TheTide = 2, ArmyBack = 3, UnseenPresence = 4, CleanSoul = 5,
        HardIronHit = 6, trailerHit = 7
    }

    public void PlayHardIronHit()
    {
        PlaySound(Sounds.HardIronHit);
        
    }

    public void PlayTrailerHit()
    {
        PlaySound(Sounds.trailerHit);
    }
    
    private void PlaySound(Sounds sound)
    {
        audioSource.PlayOneShot(soundEffectsArray[(int)sound]);
    }

    public void MenuMusicToSceneMusic(AudioClip audioClipToFadeIn)
    {
        audioLoop.clip = audioClipToFadeIn;

        StartCoroutine(FadeInFadeOut(audioSource, audioLoop, 1.5f, 0, 1));
    }

    private IEnumerator FadeInFadeOut(AudioSource audioSourceFadeOut, AudioSource audioSourceFadeIn, float duration, float targetVolumeFadeOut, float targetVolumeFadeIn)
    {
        float currentTime = 0;
        float audioSourceFadeOutVolume = audioSource.volume;
        float audioSourceFadeInVolume = audioLoop.volume;  
       // audioSourceFadeOut.Play();
        audioSourceFadeIn.Play();
        audioLoop.loop = true;
        
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSourceFadeOut.volume = Mathf.Lerp(audioSourceFadeOutVolume, targetVolumeFadeOut, currentTime / duration);
            audioSourceFadeIn.volume = Mathf.Lerp(audioSourceFadeInVolume, targetVolumeFadeIn, currentTime / duration);
            yield return null;
        }

        audioSourceFadeOut.clip = null;
        audioSourceFadeOut.volume = 1f; //reset the volume
    }
}
