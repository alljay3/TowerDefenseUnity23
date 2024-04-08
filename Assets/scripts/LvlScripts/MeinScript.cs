using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeinScript : MonoBehaviour
{
    static public int ChooseTower = 0;
    static public int CurMoney = 100;
    static public int Curhp;
    static public bool GameIsPause = false;
    static public bool IsWin { get; set; }
    [SerializeField] private int Money = 100;
    [SerializeField] private int Hp = 20;
    [SerializeField] private Slider HpBar;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject LoseMenu;
    [SerializeField] private GameObject WinMenu;
    [SerializeField] private GameObject AddPanel;
    [SerializeField] private TMPro.TextMeshProUGUI MoneyText;
    private float _deltaHp;
    private bool _addFlag = false;



    public void SelectTower(int t)
    {
        ChooseTower = t;
    }

    public void Start()
    {
        IsWin = false;
        GameIsPause = false;
        ChooseTower = 0;
        Curhp = Hp;
        CurMoney = Money;
        _deltaHp = 1.0f / Hp;
    }

    void Update()
    {
        ChangePause();
        FormatCurHp();
        HpBar.value = _deltaHp * Curhp;
        Defeated();
        Win();
        MoneyText.text = CurMoney.ToString();
    }

    public void CallPause()
    {
        VolumeManager.AllMute();
        AddScript.Show();
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
    }


    private void Defeated()
    {
        if (Curhp <= 0)
        {
            if (!_addFlag)
            {
                _addFlag = true;
                AddPanel.SetActive(true);
            }
            else if (!AddPanel.activeSelf)
            {
                LoseMenu.SetActive(true);
                AddScript.Show();
            }

        }
        else
        {
        }
    }

    public void Win()
    {
        if (IsWin)
        {
            WinMenu.SetActive(true);
        }
    }


    private void FormatCurHp()
    {
        if (Curhp < 0)
        {
            Curhp = 0;
        }

    }

    private void ChangePause()
    {
        if (GameIsPause)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }
}
