using UnityEngine;

public class MainMenuControl : MonoBehaviour
{
    public GameObject mainMenuUI; // Reference to the main menu UI GameObject
    public string gameSceneName = "PlayScene"; // Name of the game scene to load


    public void StartGame()
    {
        // Load the game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameSceneName);
    }
}
