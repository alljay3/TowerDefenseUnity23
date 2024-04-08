using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMenuScript : MonoBehaviour
{
    static public bool MusicUnable = true;

    [SerializeField] private string NameLoadScene;
    [SerializeField] private LoadScript LoadScreen;
    void Start()
    {
        AddScript.GetPlayer();
        PlayerPrefs.SetFloat("SoundVolue", 0.2f);
        PlayerPrefs.SetFloat("MusicVolue", 0.2f);
        SaveAndLoad.LoadDate();
        Application.ExternalCall("Keke");
        LoadScreen.Loading(NameLoadScene);
        AddScript.Show();
    }

    void Kek(string f)
    {
        Debug.Log(f);
        //LoadScreen.Loading(NameLoadScene);
    }

}
