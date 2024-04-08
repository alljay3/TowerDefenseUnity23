using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsSet : MonoBehaviour
{
    [SerializeField] private Sprite StarNoneImage, StarFillImage;
    [SerializeField] Transform StarTransforms;

    public void SetStarImage(int numberLvl)
    {
        int countStar = PlayerPrefs.GetInt("Lvl" + numberLvl.ToString());
        for(int numberStar = 0; numberStar < 3; numberStar++)
        {
            if (countStar > numberStar)
            {
                StarTransforms.GetChild(numberStar).gameObject.GetComponent<Image>().sprite = StarFillImage;
            }
            else
            {
                StarTransforms.GetChild(numberStar).gameObject.GetComponent<Image>().sprite = StarNoneImage;
            }
        }
    }    
}
