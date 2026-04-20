using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader 
{
    public static IEnumerator LoadAsync(int sceneName)
    {
        yield return new WaitForSeconds(2f);
        AsyncOperation waitLoading = SceneManager.LoadSceneAsync(sceneName);
        yield return new WaitUntil(() => waitLoading.isDone);
    }
}