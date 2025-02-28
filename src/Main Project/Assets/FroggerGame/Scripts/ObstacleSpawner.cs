using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    /// <summary>
    /// The spawner is set at a specific location and will spawn obstacles using assigned prefabs in the inspector.
    /// The spawner will spawn the obstacles at random intervals between a set time using a Coroutine. Time intervals and speed can be increased or decreased
    /// to adjust difficulty for each area.
    /// </summary>
    [Header("Obstacle Prefabs to be Spawned")]
    [SerializeField] private List<GameObject> obstacles = new List<GameObject>();

    [Header("Spawn Time Frame")]
    [SerializeField] private float minSpawnTime = 1f;
    [SerializeField] private float maxSpawnTime = 5f;
  
   
    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    /// <summary>
    /// Coroutine used to randomly determine the spawn interval and continiously spawns obstacles. 
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float spawnDelay = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnDelay);
            SpawnObstacle();
        }
    }

    /// <summary>
    ///  Randomly selects an obstacle from the list and spawns it at the spawner's position.
    /// </summary>
    private void SpawnObstacle()
    {
        if (obstacles.Count == 0)
        {
            Debug.LogWarning("Obstacle Prefabs have not been assigned");
        }
        GameObject obsacleToSpawn = obstacles[Random.Range(0,obstacles.Count)];
        Instantiate(obsacleToSpawn,transform.position,Quaternion.identity);
    }

   
}
