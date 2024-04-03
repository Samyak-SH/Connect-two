using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemy;
    public float repeatTime;
    public float startTime;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawn", startTime, repeatTime);
        //InvokeRepeating("TimeIncreaser", 10f, 10f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void spawn()
    {
        int rand = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[rand].position, Quaternion.identity);
    }
    void TimeIncreaser()
    {
        repeatTime -= 0.5f;
    }
}
