using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower4Trigger : MonoBehaviour
{
    [SerializeField]private Tower4 twr4;
    private float _freezFlyEnemy;
    private float _damageEnemy;
    private Material _standartMaterial;
    private Material _freezMaterial;
    private Material _fireMaterial;

    private void Start()
    {
        _freezFlyEnemy = twr4.freezFlyEnemy;
        _damageEnemy = twr4.damageEnemy;
        _freezMaterial = twr4.freezMaterial;
        _standartMaterial = twr4.standartMaterial;
        _fireMaterial = twr4.fireMaterial;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (other.CompareTag("Flyenemy") && !enemy.freezEffect)
        {
            enemy.speed = enemy.speed * _freezFlyEnemy;
            enemy.freezEffect = true;
            other.gameObject.GetComponent<SpriteRenderer>().material = _freezMaterial;
        }
        if (other.CompareTag("enemy"))
        {
            enemy.StartDamageForSecond(1, twr4.damageEnemy);
            other.gameObject.GetComponent<SpriteRenderer>().material = _fireMaterial;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (other.CompareTag("Flyenemy") && enemy.freezEffect)
        {
            enemy.speed = enemy.speed / _freezFlyEnemy;
            enemy.freezEffect = false;
            other.gameObject.GetComponent<SpriteRenderer>().material = _standartMaterial;
        }
        if (other.CompareTag("enemy"))
        {
            enemy.StopDamageForSecond();
            other.gameObject.GetComponent<SpriteRenderer>().material = _standartMaterial;
        }
    }
}
