using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private float delay = 0f;
    
    public void GoToSceneAssync(string sceneName) {
        StartCoroutine(LoadYourAsyncScene(sceneName));
    }

    IEnumerator LoadYourAsyncScene(string sceneName)
    {
        yield return new WaitForSeconds(delay);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
    }
}
