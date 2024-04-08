using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRangeButton : MonoBehaviour
{
    public static bool RangeIsVisible = false;
    public void SwapVisibleRange()
    {
        RangeIsVisible = !RangeIsVisible;
    }
}
