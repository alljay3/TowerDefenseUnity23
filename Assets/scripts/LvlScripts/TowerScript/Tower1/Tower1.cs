using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower1 : MonoBehaviour
{
    public Transform shootingElement;
    public Transform LoockAtobj;
    public int dmg = 10;
    public GameObject bullet;
    public Transform target;
    public float shootDelay;

    bool isShoot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            LoockAtobj.transform.LookAt2D(LoockAtobj.transform.up, target.position);
            if(!isShoot)
            {
                StartCoroutine(shoot());
            }
        }


    }
    IEnumerator shoot()
    {
        isShoot = true;
        if (target)
        {
            GameObject b = GameObject.Instantiate(bullet, shootingElement.position, Quaternion.identity) as GameObject;
            b.GetComponent<bulletTower1>().target = target;
            b.GetComponent<bulletTower1>().twr = this;
        }
        yield return new WaitForSeconds(shootDelay);
        isShoot = false;
    }


}
