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

    [Header("UI Settings")]
    [Tooltip("TextMeshProUGUI component to display the number of lives.")]
    public TextMeshProUGUI livesText; // Assign this in the Inspector

    /// <summary>
    /// Initializes the boat's lives and updates the UI at the start of the game.
    /// </summary>
    void Start()
    {
        // Set the current lives to the maximum value at the start of the game
        currentLives = maxLives;
        UpdateLivesUI();
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the boat collided with a log or whirlpool
        if (collision.CompareTag("Obstacle"))
        {
            // Call the method to lose a life
            LoseLife();
        }
    }

    /// <summary>
    /// Decreases the boat's lives by one and checks if the game is over.
    /// </summary>
    void LoseLife()
    {
        currentLives--;
        UpdateLivesUI();
        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    /// <summary>
    /// Handles the Game Over state when all lives are lost.
    /// </summary>
    void GameOver()
    {
        Debug.Log("Game Over!");
    }
}
