using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private LoadScript LoadScreen;
    // Start is called before the first frame update

    void Update()
    {
        MeinScript.GameIsPause = true;
    }

    public void Resume()
    {
        VolumeManager.AllUnMute();
        MeinScript.GameIsPause = false;
        gameObject.SetActive(false);
    }

    public void BackToMenu()
    {
        MeinScript.GameIsPause = false;
        LoadScreen.Loading("Menu");
    }

    public void Restart()
    {
        MeinScript.GameIsPause = false;
        LoadScreen.Loading(SceneManager.GetActiveScene().name);
    }

    public void ChangeLvl()
    {
        MeinScript.GameIsPause = false;
        LoadScreen.Loading("ChooseLVL");
    }
}
