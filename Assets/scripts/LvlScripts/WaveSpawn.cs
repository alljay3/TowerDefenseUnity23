using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    public int WaveSize;
    public GameObject EnemyPrefab;
    public GameObject objWayPoints;
    public float EnemyInterval;
    public float startTime;
    private Transform[] wayPoints;
    int enemyCount = 0;
    [SerializeField] private Transform SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy",startTime,EnemyInterval);
        int childCount = objWayPoints.transform.childCount;
        wayPoints = new Transform[childCount];
        for (int numChild = 0; numChild < childCount; numChild++)
        {
            wayPoints[numChild] = objWayPoints.transform.GetChild(numChild);
        }

    }
    private void Update()
    {
        if(enemyCount == WaveSize)
        {
            CancelInvoke("SpawnEnemy");
            this.enabled = false;
        }
    }

    void SpawnEnemy()
    {
        enemyCount++;
        GameObject enemy = GameObject.Instantiate(EnemyPrefab, SpawnPoint.position, Quaternion.identity) as GameObject;
        enemy.GetComponent<MoveToWayPoints>().waypoints = wayPoints;
    }
}
