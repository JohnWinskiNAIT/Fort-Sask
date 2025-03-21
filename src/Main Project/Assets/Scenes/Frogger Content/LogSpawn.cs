using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawn : MonoBehaviour
{
    [SerializeField]
    public GameObject log;

    [SerializeField]
    public GameObject crate;

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

        //Instantiate(log, spawnPoint.position, spawnPoint.rotation);

        //randomize what object spawns
        int trashspwner = Random.Range(1, 3);
        if (trashspwner == 1)
        {
            Instantiate(log, spawnPoint.position, spawnPoint.rotation);
        }
        if (trashspwner == 2)
        {
            Instantiate(crate, spawnPoint.position, spawnPoint.rotation);
        }
    }

   
}
