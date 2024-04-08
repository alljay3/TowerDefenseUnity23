using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager: MonoBehaviour
{
    [SerializeField] Sprite SpriteEnable;
    [SerializeField] Sprite SpriteDisable;
    public void Start()
    {
        if (FirstMenuScript.MusicUnable)
        {
            gameObject.GetComponent<Image>().sprite = SpriteEnable;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = SpriteDisable;
        }
    }
    public static void AllMute()
    {
        VolumeScript[] audioSources = GameObject.FindObjectsOfType<VolumeScript>();
        foreach (VolumeScript i in audioSources)
        {
            i.AllMute();
        }
    }


    public static void AllUnMute()
    {
        VolumeScript[] audioSources = GameObject.FindObjectsOfType<VolumeScript>();
        foreach (VolumeScript i in audioSources)
        {
            i.ChangeVolume();
        }
    }


    public void ButtonPress()
    {
        FirstMenuScript.MusicUnable = !FirstMenuScript.MusicUnable;
        if (FirstMenuScript.MusicUnable)
        {
            AllUnMute();
            gameObject.GetComponent<Image>().sprite = SpriteEnable;
            PlayerPrefs.SetInt("MusicEnabled", 0);
        }
        else
        {
            AllMute();
            gameObject.GetComponent<Image>().sprite = SpriteDisable;
            PlayerPrefs.SetInt("MusicEnabled", 1);
        }
    }

}
