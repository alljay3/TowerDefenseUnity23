using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy") || other.CompareTag("Flyenemy"))
        {
            MeinScript.Curhp -= other.gameObject.GetComponent<Enemy>().damage;
            Destroy(other.gameObject);
        }


    }
}
