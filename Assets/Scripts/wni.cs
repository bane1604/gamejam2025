using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenuManager : MonoBehaviour
{
    public GameObject winPanel;

    public void RestartGame()
    {
        
        Debug.Log("Restart dugme kliknuto!");

        if (GameManager.Instance != null)
        {
            GameManager.Instance.currentPhase = GameManager.GamePhase.Preparation;
            GameManager.Instance.player.SetMovement(false); // opcionalno - za reset

            // Hide the win panel
            if (winPanel != null)
                winPanel.SetActive(false);
        }
        else
        {
            Debug.LogWarning("GameManager.Instance je null!");
        }
    }

    public void GoToMainMenu()
    {
        Debug.Log("Main Menu dugme kliknuto!");
        SceneManager.LoadScene("MenuScene");
    }
}