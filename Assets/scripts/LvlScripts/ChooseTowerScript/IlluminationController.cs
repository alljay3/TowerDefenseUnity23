using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IlluminationController : MonoBehaviour
{
    [SerializeField] private int numButton;
    private Image illumination;


    private void Start()
    {
        illumination = gameObject.GetComponent<Image>();
    }
    private void Update()
    {
        if (MeinScript.ChooseTower == numButton)
        {
            illumination.enabled = true;
        }
        else
        { 
            illumination.enabled = false;
        }
    }
}
