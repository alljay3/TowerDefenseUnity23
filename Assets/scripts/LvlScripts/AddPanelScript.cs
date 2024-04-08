using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddPanelScript : MonoBehaviour
{
    [SerializeField] private GameObject Defeat;
    [SerializeField] private GameObject AddPanel;

    // Start is called before the first frame update

    private void Start()
    {
        Time.timeScale = 0;
        VolumeManager.AllMute();
    }

    void Update()
    {
        MeinScript.GameIsPause = true;
    }

    public void CallDefete()
    {
        gameObject.SetActive(false);
        VolumeManager.AllUnMute();
        Defeat.SetActive(true);
    }

    public void CallAddPanel()
    {
        MeinScript.Curhp = 10;
        AddPanel.SetActive(true);
        gameObject.SetActive(false);
        AddScript.ShowReward();
    }

    public void Continue()
    {
        Time.timeScale = 1;
        VolumeManager.AllUnMute();
        MeinScript.GameIsPause = false;
        gameObject.SetActive(false);
    }
}
