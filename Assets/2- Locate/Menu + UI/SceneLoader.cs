using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    private AsyncOperation loadingOperation;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PreloadScene(2);
    }

    public void PreloadScene(int sceneIndex)
    {
        StartCoroutine(LoadSceneCoroutine(sceneIndex));
    }

    private IEnumerator LoadSceneCoroutine(int sceneIndex)
    {
        loadingOperation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingOperation.allowSceneActivation = false;

        while (loadingOperation.progress < 0.9f)
        {
            yield return null;
        }
    }

    
    public void ActivateScene()
    {
        if (loadingOperation != null)
        {
            loadingOperation.allowSceneActivation = true;
        }
        else
        {
            Debug.LogWarning("—цена ещЄ не загружена!");
        }
    }
}