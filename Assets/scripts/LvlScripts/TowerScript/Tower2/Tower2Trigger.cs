using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower2Trigger : MonoBehaviour
{
    public Tower2 twr2;
    public float freezEnemy;
    public float damageFlyEnemy;
    public Material standartMaterial;
    public Material freezMaterial;
    public Material fireMaterial;

    private void Start()
    {
        freezEnemy = twr2.freezEnemy;
        damageFlyEnemy = twr2.damageFlyEnemy;
        freezMaterial = twr2.freezMaterial;
        standartMaterial = twr2.standartMaterial;
        fireMaterial = twr2.fireMaterial;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (other.CompareTag("enemy") && !enemy.freezEffect)
        {
            enemy.speed = enemy.speed * freezEnemy;
            enemy.freezEffect = true;
            other.gameObject.GetComponent<SpriteRenderer>().material = freezMaterial;
        }
        if (other.CompareTag("Flyenemy"))
        {
            enemy.StartDamageForSecond(1, twr2.damageFlyEnemy);
            other.gameObject.GetComponent<SpriteRenderer>().material = fireMaterial;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (other.CompareTag("enemy") && enemy.freezEffect)
        {
            enemy.speed = enemy.speed / freezEnemy;
            enemy.freezEffect = false;
            other.gameObject.GetComponent<SpriteRenderer>().material = standartMaterial;
        }
        if (other.CompareTag("Flyenemy"))
        {
            enemy.StopDamageForSecond();
            other.gameObject.GetComponent<SpriteRenderer>().material = standartMaterial;
        }
    }
}
