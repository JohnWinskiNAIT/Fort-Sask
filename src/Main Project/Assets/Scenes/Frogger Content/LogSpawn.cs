using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawn : MonoBehaviour
{
    [SerializeField]
    public GameObject log;

    [SerializeField]
    public Transform[] spawnPoints;

    public float spawnDelay = 0.3f;

    float nextTimeToSpawn = 0f;

    void Update()
    {
        if (nextTimeToSpawn <= Time.time) 
        {
            SpawnLog();
            nextTimeToSpawn = Time.time + spawnDelay;
        }
    }

    void SpawnLog()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        Transform spawnPoint = spawnPoints[randomIndex];

        Instantiate(log, spawnPoint.position, spawnPoint.rotation);
    }
}
