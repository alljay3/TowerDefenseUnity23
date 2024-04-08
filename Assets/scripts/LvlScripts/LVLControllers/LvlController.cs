  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvlController : MonoBehaviour
{
    [SerializeField] private GameObject SpawnPointsObj;
    [SerializeField] private int spawnDelay = 30;
    [SerializeField] private int LvlCompleteTime = 5;
    [SerializeField] private TMPro.TextMeshProUGUI TimeText;
    private Transform[] _spawnPonintTransforms;
    private int _numberWave = 0;
    private WaveSpawn[] _waveSpawns;
    private int _childCount = 0;
    
    void Start()
    {
        _childCount = SpawnPointsObj.transform.childCount;
        _spawnPonintTransforms = new Transform[_childCount];
        for (int numChild = 0; numChild < _childCount; numChild++)
        {
            _spawnPonintTransforms[numChild] = SpawnPointsObj.transform.GetChild(numChild);
        }

        _waveSpawns = _spawnPonintTransforms[_numberWave].gameObject.GetComponents<WaveSpawn>();
        StartCoroutine(EnableSpawn());
        StartCoroutine(TimeSet());

    }

    void Update()
    {
        bool checkWaveEnable = false;
        foreach (WaveSpawn waveSpawn in _waveSpawns)
        {
            if (waveSpawn.enabled == true)
            {

                checkWaveEnable = true;
            }
        }
        if (!checkWaveEnable)
        {
            if (_numberWave < _childCount)
            {
                _numberWave += 1;
            }
            else if (_numberWave == _childCount)
            {
                int checkMob = GameObject.FindGameObjectsWithTag("enemy").Length + GameObject.FindGameObjectsWithTag("Flyenemy").Length;
                if (checkMob == 0)
                {
                    StartCoroutine(CompliteLVL()); // вызов победы
                }
            }


            if (_numberWave < _childCount)
            {
                _waveSpawns = _spawnPonintTransforms[_numberWave].gameObject.GetComponents<WaveSpawn>();
                StartCoroutine(EnableSpawn());
                StartCoroutine(TimeSet());
            }


        }
    }

    IEnumerator EnableSpawn()
    {
        yield return new WaitForSeconds(spawnDelay);
        _spawnPonintTransforms[_numberWave].gameObject.SetActive(true);
    }

    IEnumerator TimeSet()
    {
        int l = spawnDelay;
        while (l >= 0)
        {
            if (l != 0)
            {
                TimeText.text = string.Format($"Волна {_numberWave + 1}/{_childCount}: {l} секунд ");
            }
            else
                TimeText.text = string.Format($"Волна {_numberWave + 1}/{_childCount}: Идет!!! ");
            yield return new WaitForSeconds(1);
            l -= 1;
        }
    }

    IEnumerator CompliteLVL ()
    {
        TimeText.text = string.Format($"Уровень Пройден!");
        yield return new WaitForSeconds(LvlCompleteTime);
        MeinScript.IsWin = true;
    }

}
