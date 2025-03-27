using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawn : MonoBehaviour
{
    [SerializeField]
    public GameObject log;

    [SerializeField]
    public GameObject log2;

    [SerializeField]
    public GameObject log3;

    [SerializeField]
    public GameObject crate;

    [SerializeField]
    public GameObject crate2;

    [SerializeField]
    public GameObject crate3;

    //[SerializeField]
    //public GameObject brokenBoat;

    //[SerializeField]
    //public GameObject whirlPool;

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
        int trashspwner = Random.Range(1, 7);
        if (trashspwner == 1)
        {
            Instantiate(log, spawnPoint.position, spawnPoint.rotation);
        }

        if (trashspwner == 2)
        {
            Instantiate(log2, spawnPoint.position, spawnPoint.rotation);
        }

        if (trashspwner == 3)
        {
            Instantiate(log3, spawnPoint.position, spawnPoint.rotation);
        }

        if (trashspwner == 4)
        {
            Instantiate(crate, spawnPoint.position, spawnPoint.rotation);
        }

        if (trashspwner == 5)
        {
            Instantiate(crate2, spawnPoint.position, spawnPoint.rotation);
        }

        if (trashspwner == 6)
        {
            Instantiate(crate3, spawnPoint.position, spawnPoint.rotation);
        }

        //if (trashspwner == 7)
        //{
        //    Instantiate(brokenBoat, spawnPoint.position, spawnPoint.rotation);
        //}

        //if (trashspwner == 8)
        //{
        //    Instantiate(whirlPool, spawnPoint.position, spawnPoint.rotation);
        //}
    }

   
}
