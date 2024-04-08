using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTest : MonoBehaviour
{

    [SerializeField] private GameObject zomby1;
    [SerializeField] private GameObject[] zombys;
    [SerializeField] private GameObject zomby2;

    // Start is called before the first frame update
    void Start()
    {
        zombys = new GameObject[1];
        zombys[0] = zomby1;
        if (zomby1 == zomby2)
            Debug.Log("lol");
        if (zomby1 == zombys[0])
            Debug.Log("lol5");    }
}
