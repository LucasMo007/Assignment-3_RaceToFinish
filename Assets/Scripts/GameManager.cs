using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Timer")]
    public float totalTime = 120f;
    public Text timerText;

    [Header("Game Over")]
    public GameObject gameOverPanel;

    [Header("Cheat Teleport Points")]
    public Transform[] teleportPoints;

    private Transform player;
    private Rigidbody playerRb;
    private float timeRemaining;
    private bool gameOver = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerRb = player.GetComponent<Rigidbody>();
        timeRemaining = totalTime;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (gameOver) return;

      
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            gameOver = true;
            ShowGameOver();
        }

     
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        if (timerText != null)
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

      
        for (int i = 0; i < teleportPoints.Length && i < 10; i++)
        {
            if (Input.GetKeyDown(KeyCode.F1 + i) && teleportPoints[i] != null)
            {
                playerRb.linearVelocity = Vector3.zero;
                playerRb.angularVelocity = Vector3.zero;
                player.position = teleportPoints[i].position;
            }
        }
    }

    void ShowGameOver()
    {
        Time.timeScale = 0f;
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Mainmenu");
    }
}