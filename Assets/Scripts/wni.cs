using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenuManager : MonoBehaviour
{
    public GameObject winPanel;

    public void RestartGame()
    {
        Debug.Log("Restart dugme kliknuto!");
        SceneManager.LoadScene("LalicLevel1");
    }

    public void GoToMainMenu()
    {
        Debug.Log("Main Menu dugme kliknuto!");
        SceneManager.LoadScene("MenuScene");
    }
}