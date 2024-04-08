using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRangeController : MonoBehaviour
{
    void Update()
    {
        if (TowerRangeButton.RangeIsVisible)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }

    }
}
