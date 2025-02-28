using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    /// <summary>
    /// Moves the obstacle in the x-direction accross the river. 
    /// used for continious movement
    /// </summary>
    [Header("Movement Settings")]
    public float moveSpeed = 2f;

    [Header("Direction of Movement")]
    public float direction = -1f;
   

    /// <summary>
    /// Moves the obstacle in the x direction every frame
    /// </summary>
    void Update()
    {
        Vector3 movement = new Vector3(direction, 0, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
     
    }

    /// <summary>
    /// Collision to destroy obstacle game objects when they leave the frame.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RightBoundary"))
        {
            Destroy(gameObject);
        }
    }
}
