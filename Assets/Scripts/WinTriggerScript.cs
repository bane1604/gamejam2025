using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTriggerScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {

        AudioManager.Instance.StopBackgroundMusic();
        Player player = collision.gameObject.GetComponent<Player>();
        player.SetMovement(false);
        player.setAnimatorRunning(false);
        SceneManager.LoadScene("win");
        
    }
}
