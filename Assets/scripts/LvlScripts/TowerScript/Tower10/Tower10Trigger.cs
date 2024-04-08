using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower10Trigger : MonoBehaviour
{
    [SerializeField]private Tower10 Tower10;
    private float _freezFlyEnemy;
    private float _damageEnemy;
    private Material _standartMaterial;
    private Material _freezMaterial;

    private void Start()
    {
        _freezFlyEnemy = Tower10.freezFlyEnemy;
        _damageEnemy = Tower10.damageEnemy;
        _freezMaterial = Tower10.freezMaterial;
        _standartMaterial = Tower10.standartMaterial;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (!enemy.freezEffect)
        {
            enemy.speed = enemy.speed * _freezFlyEnemy;
            enemy.freezEffect = true;
            other.gameObject.GetComponent<SpriteRenderer>().material = _freezMaterial;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy.freezEffect)
        {
            enemy.speed = enemy.speed / _freezFlyEnemy;
            enemy.freezEffect = false;
            other.gameObject.GetComponent<SpriteRenderer>().material = _standartMaterial;
        }
    }
}
