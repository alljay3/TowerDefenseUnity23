using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAndTowerDiscriptionScript : MonoBehaviour
{
    public void CloseWindow(GameObject myObject)
    {
        myObject.SetActive(false);
    }

    public void OpenWindow(GameObject myObject)
    {
        myObject.SetActive(true);
    }
}
