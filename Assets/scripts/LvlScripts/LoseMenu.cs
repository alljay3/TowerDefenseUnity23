using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    [SerializeField] private LoadScript LoadScreen;
    void Update()
    {
        MeinScript.GameIsPause = true;
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
