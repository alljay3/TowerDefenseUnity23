using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class Spirit : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, (Vector2) transform.position + Vector2.up, Time.deltaTime * speed);
        Invoke("thisDestroy", lifeTime);
    }
    void thisDestroy()
    {
        Destroy(gameObject);
    }    
}
