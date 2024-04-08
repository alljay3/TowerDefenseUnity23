using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    [SerializeField] private LoadScript LoadScreen;
    [SerializeField] private bool LastLevel = false;
    [SerializeField] private int NumLevel = 1;
    private void Start()
    {
        int availableLevels = PlayerPrefs.GetInt("availableLevels");
        int CurCountStars = PlayerPrefs.GetInt("Lvl" + NumLevel);
        int NewCountStars = countNumberStars();
        if (availableLevels <= NumLevel)
        {
            PlayerPrefs.SetInt("availableLevels",NumLevel);
        }
        Debug.Log(CurCountStars);

        if (CurCountStars < NewCountStars)
            PlayerPrefs.SetInt("Lvl" + NumLevel, NewCountStars);
        Debug.Log(PlayerPrefs.GetInt("Lvl" + NumLevel));
        gameObject.GetComponent<StarsSet>().SetStarImage(NumLevel); // Устанавливает конечные звезды
    }


    void Update()
    {
        MeinScript.GameIsPause = true;
    }

    public void NextLvl()
    {
        if (!LastLevel)
        {
            MeinScript.GameIsPause = false;
            LoadScreen.Loading(SceneManager.GetActiveScene().buildIndex + 1);
        }
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

    private int countNumberStars()
    {
        if (MeinScript.Curhp == 20)
            return 3;
        else if (MeinScript.Curhp < 20 && MeinScript.Curhp >=  15)
            return 2;
        else if (MeinScript.Curhp < 15 && MeinScript.Curhp >= 5)
            return 1;
        return 0;

    }
}
