using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Timer")]
    public float totalTime = 120f; // 2 minutes
    public Text timerText;

    [Header("Cheat Teleport Points")]
    public Transform[] teleportPoints; // Assign in Inspector: F1=trap1, F2=trap2, etc.

    private Transform player;
    private Rigidbody playerRb;
    private float timeRemaining;
    private bool gameOver = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerRb = player.GetComponent<Rigidbody>();
        timeRemaining = totalTime;
    }

    void Update()
    {
        if (gameOver) return;

        // Timer countdown
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            gameOver = true;
            // Restart or show game over
            Debug.Log("Time's up!");
        }

        // Update UI
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        if (timerText != null)
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Cheat teleport keys F1-F10
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
}
