using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTrigger1 : MonoBehaviour
{
    public Tower1 twr;
    public Transform enemy;
    public bool lockE;
    public GameObject curTarget;
    public int countTarget = 0;



    void OnTriggerStay2D(Collider2D other)
    {
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
        }
        else
        {
            twr.target = curTarget.transform;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("enemy") && other.gameObject == curTarget)
        {
            EndTarget();
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
