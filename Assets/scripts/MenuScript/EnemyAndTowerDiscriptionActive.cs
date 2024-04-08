using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAndTowerDiscriptionActive : MonoBehaviour
{
    [SerializeField] private int RequiredLevel;
    void Start()
    {
        int availableLevels = PlayerPrefs.GetInt("availableLevels");
        if (availableLevels < RequiredLevel)
        {
            gameObject.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
            if (transform.Find("sprite") != null)
            {
                Transform children = transform.Find("sprite");
                children.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
            }
            Debug.Log(availableLevels);
        }
        else
        {
            gameObject.GetComponent<Button>().enabled = true;
            gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }
}
