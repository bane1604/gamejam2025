using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenuManager : MonoBehaviour
{
    void Start()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.StopBackgroundMusic();
        }
    }
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