using UnityEngine;

public class KillWall2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that enters the trigger has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Access the PlayerLives2D script and call the LoseLife function
            PlayerLives2D playerLives = other.GetComponent<PlayerLives2D>();

            if (playerLives != null)
            {
                playerLives.LoseLife();  // Lose one life when the player hits the kill wall
            }
        }
    }
}
