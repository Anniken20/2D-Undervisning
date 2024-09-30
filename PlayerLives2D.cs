using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLives2D : MonoBehaviour
{
    public int lives = 3;  // Player starts with 3 lives
    public Vector3 respawnPosition;  // Where the player respawns after losing a life
    public GameObject gameOverUI;  // Reference to the Game Over UI

    private void Start()
    {
        // Set the initial respawn position to the player's starting position
        respawnPosition = transform.position;
        gameOverUI.SetActive(false);  // Ensure Game Over screen is hidden at the start
    }

    // This method will be called when the player hits the kill wall
    public void LoseLife()
    {
        if (lives > 1)
        {
            // Decrease life and respawn
            lives--;
            Respawn();
        }
        else
        {
            // No lives left, trigger game over
            GameOver();
        }
    }

    private void Respawn()
    {
        // Reset the player to the respawn position
        transform.position = respawnPosition;
    }

    private void GameOver()
    {
        // Show the Game Over UI
        gameOverUI.SetActive(true);

        // Disable the player object or any related controls to stop movement
        gameObject.SetActive(false);
    }
}
