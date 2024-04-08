using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToWayPoints : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]public float Speed;
    [HideInInspector]public Transform[] waypoints;
    [HideInInspector]public bool flipX = false;

    SpriteRenderer ObjectSprite;
    int curWaypointIndex = 0;


    // Update is called once per frame

    void Start()
    {
            ObjectSprite = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()   
    {
        if (curWaypointIndex < waypoints.Length)
        {
            if (waypoints[curWaypointIndex].position.x > transform.position.x && !flipX)
                ObjectSprite.flipX = false;
            if (waypoints[curWaypointIndex].position.x > transform.position.x && flipX)
                ObjectSprite.flipX = true;
            if (waypoints[curWaypointIndex].position.x <= transform.position.x && flipX)
                ObjectSprite.flipX = false;
            if (waypoints[curWaypointIndex].position.x <= transform.position.x && !flipX)
                ObjectSprite.flipX = true;

            transform.position = Vector2.MoveTowards(transform.position, waypoints[curWaypointIndex].position, Time.deltaTime * Speed);
            if (Vector2.Distance(transform.position, waypoints[curWaypointIndex].position) < 0.1F)
            {
                curWaypointIndex++;
            }
        }
    }
}
