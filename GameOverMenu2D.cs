using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu2D : MonoBehaviour
{
    public void TryAgain()
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        // Load the Main Menu scene (make sure you have a scene for your main menu)
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        // Quit the application (this will work when the game is built)
        Application.Quit();

        // If you're testing in the Unity editor, you can stop playing like this:
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
