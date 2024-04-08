using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower11Trigger : MonoBehaviour
{
    [SerializeField]private Tower11 twr11;
    private float _freezFlyEnemy;
    private float _damageEnemy;
    private Material _standartMaterial;
    private Material _fireMaterial;

    private void Start()
    {
        _damageEnemy = twr11.damageEnemy;
        _standartMaterial = twr11.standartMaterial;
        _fireMaterial = twr11.fireMaterial;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        enemy.StartDamageForSecond(1, twr11.damageEnemy);
        other.gameObject.GetComponent<SpriteRenderer>().material = _fireMaterial;
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        enemy.StopDamageForSecond();
        other.gameObject.GetComponent<SpriteRenderer>().material = _standartMaterial;
    }
}
