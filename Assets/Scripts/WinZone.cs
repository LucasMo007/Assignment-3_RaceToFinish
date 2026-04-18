using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour
{
    public GameObject winPanel; 
    public Text winText;

    void Start()
    {
        if (winPanel != null)
            winPanel.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Time.timeScale = 0f;

           
            if (winPanel != null)
                winPanel.SetActive(true);

            if (winText != null)
                winText.text = "You Win!";
        }
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
