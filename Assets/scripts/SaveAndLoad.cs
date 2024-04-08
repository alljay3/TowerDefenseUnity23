 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad
{
    public static void SaveDate(string name)
    {

    }
    public static void SaveDateAll ()
    {
    }
    public static void LoadDate()
    {
        PlayerPrefs.SetFloat("SoundVolue", 0.2f);
        PlayerPrefs.SetFloat("MusicVolue", 0.2f);
        PlayerPrefs.SetInt("availableLevels", 12);
        PlayerPrefs.SetInt("FirstStart", 0);
        PlayerPrefs.SetInt("Lvl1", 0);
        PlayerPrefs.SetInt("Lvl2", 0);
        PlayerPrefs.SetInt("Lvl3", 0);
        PlayerPrefs.SetInt("Lvl4", 0);
        PlayerPrefs.SetInt("Lvl5", 0);
        PlayerPrefs.SetInt("Lvl6", 0);
        PlayerPrefs.SetInt("Lvl7", 0);
        PlayerPrefs.SetInt("Lvl8", 0);
        PlayerPrefs.SetInt("Lvl9", 0);
        PlayerPrefs.SetInt("Lvl10", 0);
        PlayerPrefs.SetInt("Lvl11", 0);
        PlayerPrefs.SetInt("Lvl12", 0);


        //12312

        if (PlayerPrefs.GetInt("MusicEnabled") != 0)
        {
            FirstMenuScript.MusicUnable = false;
        }
        else
        {
            FirstMenuScript.MusicUnable = true;
        }
    }
}
