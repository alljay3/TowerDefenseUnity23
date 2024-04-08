using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTrigger3 : MonoBehaviour
{
    public Tower3 twr;
    public Transform enemy;
    public bool lockE;
    public GameObject curTarget;
    private bool curIsFlyEnemy = false;



    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Flyenemy") && !curIsFlyEnemy)
        {
            curIsFlyEnemy = true;
            StartTarger(other);
        }
        if (other.CompareTag("enemy") && !lockE)
        {
            StartTarger(other);
        }
    }

    void Update()
    {
        if (!curTarget)
        {
            EndTarget();
            curIsFlyEnemy = false;
        }
        else
        {
            twr.target = curTarget.transform;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == curTarget)
        {
            EndTarget();
            curIsFlyEnemy = false;
        }

    }
    void EndTarget()
    {
        twr.target = null;
        curTarget = null;
        lockE = false;
    }

    void StartTarger(Collider2D other)
    {
        curTarget = other.gameObject;
        lockE = true;
    }
}
