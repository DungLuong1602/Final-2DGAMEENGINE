using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel; // gán panel từ Inspector
    private bool isGameOver = false;

    public void GameOver()
    {
        if (isGameOver) return; // tránh gọi nhiều lần
        isGameOver = true;

        Time.timeScale = 0f; // Dừng game (tùy chọn)
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
