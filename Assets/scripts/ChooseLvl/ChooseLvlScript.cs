using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLvlScript : MonoBehaviour
{
    [SerializeField] private GameObject Lvls;
    [SerializeField] private LoadScript LoadScreen;
    private int _availableLevels;
    void Start()
    {
        AddScript.Show();
        _availableLevels = PlayerPrefs.GetInt("availableLevels") ;
        for (int curLvl = 0; curLvl < Lvls.transform.childCount; curLvl++)
        {
            if (curLvl <= _availableLevels)
            {
                Lvls.transform.GetChild(curLvl).gameObject.SetActive(true);
                Lvls.transform.GetChild(curLvl).gameObject.GetComponent<StarsSet>().SetStarImage(curLvl + 1);
            }
            else 
                Lvls.transform.GetChild(curLvl).gameObject.SetActive(false);
        }
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
