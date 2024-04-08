using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletTower1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Transform target;
    public Tower1 twr;
    [SerializeField] private GameObject ProjectilePrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            Destroy(gameObject);
        else
        {
            gameObject.transform.LookAt2D(gameObject.transform.up, target.position);
            transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        }
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.transform == target)
        {
            target.GetComponent<Enemy>().selfDmg(twr.dmg);
            GameObject projectTile = GameObject.Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
