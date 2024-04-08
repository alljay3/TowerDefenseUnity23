using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    [SerializeField] private LoadScript LoadScreen;
    [SerializeField] private GameObject PlotPanel;
    private void Start()
    {
        if (PlayerPrefs.GetInt("FirstStart") == 0)
        {
            PlotPanel.SetActive(true);
        }
        PlayerPrefs.SetInt("FirstStart", 1);
    }
    public void ChooseScene(string nameScene)
    {
        LoadScreen.Loading(nameScene);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
