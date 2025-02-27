using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Obstacle Prefabs to be Spawned")]
    [SerializeField] private GameObject obstacle1;
    [SerializeField] private GameObject obstacle2;

    [Header("Spawn Time Frame")]
    [SerializeField] private float minSpawnTime = 1f;
    [SerializeField] private float maxSpawnTime = 5f;
  
   
    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float spawnDelay = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnDelay);
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        if (obstacle1 == null || obstacle2 == null)
        {
            Debug.LogWarning("Obstacle Prefabs have not been assigned");
        }
        GameObject obsacleToSpawn = Random.value > 0.5f ? obstacle1 : obstacle2;
        Instantiate(obsacleToSpawn,transform.position,Quaternion.identity);
    }
}
