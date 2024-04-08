using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerPlace : MonoBehaviour
{
    public Collections Towers;
    public bool empty = true;
    public Vector3 offset;
    private GameObject _curTower;
    private int _numberTowerDelete = 999;
    private int _cocostReductionRatio = 2;
    [SerializeField] ErrorText MyError;
    public void BuildTower()
    {
        if (empty && MeinScript.ChooseTower != _numberTowerDelete)
        {
            TowerEntity twrent = Towers.gameObjects[MeinScript.ChooseTower].GetComponent<TowerEntity>();
            if (twrent.cost <= MeinScript.CurMoney)
            {
                _curTower = GameObject.Instantiate(Towers.gameObjects[MeinScript.ChooseTower], transform.position + offset, Quaternion.identity) as GameObject;
                MeinScript.CurMoney -= twrent.cost;
                empty = false;
            }
            else
            {
                MyError.SandErrorMassage("Не хватает денег для покупки башни!");
            }
        }
        else if (MeinScript.ChooseTower == _numberTowerDelete)
        {
            MeinScript.CurMoney += _curTower.GetComponent<TowerEntity>().cost / _cocostReductionRatio;
            Destroy(_curTower);
            empty = true;
        }
    }
}