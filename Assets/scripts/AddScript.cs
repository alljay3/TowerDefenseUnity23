using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScript
{
    static public void Show()
    {
        Application.ExternalCall("ShowAd");
        Debug.Log("������� �������");
    }

    static public void ShowReward()
    {
        Application.ExternalCall("ShowRewardedAd");
        Debug.Log("��������� �������");
    }

    static public void GetPlayer()
    {
        Application.ExternalCall("GetPlayer");
    }
    static public void SaveDate(string name, string value)
    {

    }
    static public void LoadDate(string name, string value)
    {

    }
}
