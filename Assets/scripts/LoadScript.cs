using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScript : MonoBehaviour
{
    [SerializeField] private Slider Scale;
    [SerializeField] private GameObject LoadingScreen;
    // Start is called before the first frame update
    public void Loading(string nameScene)
    {
        LoadingScreen.SetActive(true);
        StartCoroutine(LoadAsync(nameScene));
    }

    IEnumerator LoadAsync(string nameScene)
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(nameScene);
        loadAsync.allowSceneActivation = false;
        while (!loadAsync.isDone)
        {
            Scale.value = loadAsync.progress;
            if (loadAsync.progress <= .99f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(0);
                loadAsync.allowSceneActivation = true;
            }
            yield return null;
        }    
    }


    public void Loading(int numberScene)
    {
        LoadingScreen.SetActive(true);
        StartCoroutine(LoadAsync(numberScene));
    }

    IEnumerator LoadAsync(int numberScene)
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(numberScene);
        loadAsync.allowSceneActivation = false;
        while (!loadAsync.isDone)
        {
            Scale.value = loadAsync.progress;
            Debug.Log(loadAsync.progress);
            if (loadAsync.progress <= .99f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(0);
                loadAsync.allowSceneActivation = true;
            }
            yield return null;
        }
    }


}
