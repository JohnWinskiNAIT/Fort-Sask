using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  

/// <summary>
/// Manages the health (lives) of the boat
/// The boat starts with a set number of lives and loses one when colliding with obstacles.
/// It also displays the remaining lives on the screen and triggers a Game Over when all lives are lost.
/// </summary>
public class BoatHealthManager : MonoBehaviour
{
    [Header("Boat Lives Settings")]
    [Tooltip("Maximum number of lives the boat starts with.")]
    public int maxLives = 3;
    private int currentLives;
    private Vector3 respawnPoint;

    [Header("UI Settings")]
    [Tooltip("TextMeshProUGUI component to display the number of lives.")]
    public TextMeshProUGUI livesText; 


    /// <summary>
    /// Initializes the boat's lives and updates the UI at the start of the game.
    /// </summary>
    void Start()
    {
        // Set the current lives to the maximum value at the start of the game
        currentLives = maxLives;
        UpdateLivesUI();

        //Make sure the respawn point is the starting posiiton
        respawnPoint = transform.position;
    }

    /// <summary>
    /// Updates the UI text to display the current number of lives.
    /// </summary>
    void UpdateLivesUI()
    {
        // Display the current lives on the screen
        livesText.text = "Lives: " + currentLives;
    }

    /// <summary>
    /// Detects collisions with obstacles and decreases lives accordingly.
    /// </summary>
    /// <param name="collision">The collider that the boat enters.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the boat collided with a log or whirlpool
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Call the method to lose a life
            LoseLife();
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CheckPoint"))
        {
            respawnPoint = collision.transform.position;
        }
    }
    /// <summary>
    /// Decreases the boat's lives by one and checks if the game is over.
    /// Respawns the boat at the checkpoint
    /// </summary>
    void LoseLife()
    {
        currentLives--;
        UpdateLivesUI();

        if (currentLives <= 0)
        {
            GameOver();
        }

        //In order to ensure the boat doesn't get moved behind the background only use respawn x and y and keep z position.
        transform.position = new Vector3(respawnPoint.x, respawnPoint.y, transform.position.z);
    }

   

    /// <summary>
    /// Handles the Game Over state when all lives are lost.
    /// </summary>
    void GameOver()
    {
        Debug.Log("Game Over!");
    }
}
