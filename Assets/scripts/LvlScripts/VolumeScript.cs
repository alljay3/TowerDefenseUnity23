using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolumeScript : MonoBehaviour
{
    [SerializeField] float volume = 1;
    private static bool MusicOn = false;
    private void Start()
    {
        if (FirstMenuScript.MusicUnable)
            ChangeVolume();
        else
        {
            AllMute();
        }

    }

    private void Awake()
    {
        if (gameObject.tag == "MenuMusic")
            if (MusicOn == false)
            {
                DontDestroyOnLoad(gameObject);
                MusicOn = true;    
            }
            else
                Destroy(gameObject);
    }

    public void ChangeVolume()
    {
        if (gameObject.GetComponent<AudioSource>() != null)
        {
            AudioSource MyAudio = gameObject.GetComponent<AudioSource>();
            if (gameObject.tag != "Music")
                MyAudio.volume = volume * PlayerPrefs.GetFloat("SoundVolue") * 5;
            if (gameObject.tag == "Music")
                MyAudio.volume = volume * PlayerPrefs.GetFloat("MusicVolue") * 5;
        }
    }

    public void SoundMute()
    {
        if (gameObject.GetComponent<AudioSource>() != null)
        {
            AudioSource MyAudio = gameObject.GetComponent<AudioSource>();
            if (gameObject.tag != "Music")
                MyAudio.volume = 0;
        }
    }

    public void MusicMute()
    {
        if (gameObject.GetComponent<AudioSource>() != null)
        {
            AudioSource MyAudio = gameObject.GetComponent<AudioSource>();
            if (gameObject.tag == "Music" || gameObject.tag == "MenuMusic")
                MyAudio.volume = 0;
        }
    }

    public void AllMute()
    {
        if (gameObject.GetComponent<AudioSource>() != null)
        {
            AudioSource MyAudio = gameObject.GetComponent<AudioSource>();
            MyAudio.volume = 0;
        }
    }

    public void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name.Contains("Level") && gameObject.tag == "MenuMusic")
        {
            Destroy(gameObject);
            MusicOn = false;
        }
    }

}
