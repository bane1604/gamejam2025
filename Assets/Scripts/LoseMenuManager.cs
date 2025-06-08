using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenuManager : MonoBehaviour
{
    public void RestartGame()
    {
        Debug.Log("Restart button clicked!");
        SceneManager.LoadScene("LalicLevel1"); 
    }

    public void GoToMainMenu()
    {
        Debug.Log("Main Menu button clicked!");
        SceneManager.LoadScene("MenuScene"); 
    }
}
