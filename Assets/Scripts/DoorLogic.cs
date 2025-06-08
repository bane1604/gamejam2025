using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class DoorLogic : MonoBehaviour
{
    public float invertDelay = 1f;
    //public GameObject colorBlindOverlay;
    private bool isColorBlindActive = false;
    [SerializeField] GameObject timer;
    [SerializeField] float fastTimeMultiplyer = 2f;
    [SerializeField] float slowTimeMultiplyer = 0.5f;
    [SerializeField] string winnerSceneName = "WinnerScene"; // <- Set this to your scene's name

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("kurac triger");
        if (collision.tag == "Player")
        {
            string doorTag = gameObject.tag;
            Debug.Log(doorTag);
            switch (doorTag)
            {
                case "BlueDoor":
                    ApplySpeedBoost(collision.gameObject, timer);
                    break;
                case "RedDoor":
                    StartCoroutine(InvertControlsAfterDelay(collision.gameObject, invertDelay));
                    break;
                case "GreenDoor":
                    SlowDownTime(collision.gameObject);
                    break;
                case "YellowDoor":
                    AddExtraTime();
                    break;
                case "GoldDoor":
                    Exit();
                    break;
                case "PurpleDoor":
                    //ToggleColorBlind(collision.gameObject, isColorBlindActive);
                    break;
                default:
                    Debug.LogWarning("Unrecognized door tag: " + doorTag);

                    break;
            }
        }
    }

    private void ConfusePlayer(object gameObject)
    {
        throw new NotImplementedException();
    }

    private void AddExtraTime()
    {
        throw new NotImplementedException();
    }

    private void SlowDownTime(GameObject gameObject)
    {
        Player player = gameObject.GetComponent<Player>();
        Timer timerManager = timer.GetComponent<Timer>();
        player.ApplySlow();
        timerManager.SetAccelerated(slowTimeMultiplyer);
    }

    private IEnumerator InvertControlsAfterDelay(GameObject playerObject, float delay)
    {
        yield return new WaitForSeconds(delay);

        Player player = playerObject.GetComponent<Player>();
        if (player != null)
        {
            player.InvertControls();
        }
    }

    private void Exit()
    {
        SceneManager.LoadScene(winnerSceneName);
    }
    
    private void ApplySpeedBoost(GameObject gameObject, GameObject timer)
    {
        Player player = gameObject.GetComponent<Player>();
        Timer timerManager = timer.GetComponent<Timer>();
        player.ApplyBoost();
        timerManager.SetAccelerated(fastTimeMultiplyer);

    }
    
    /*private void ToggleColorBlind(GameObject player, bool activate)
    {
        UnityEngine.Camera mainCam = UnityEngine.Camera.main;
        ColorBlindManager manager = mainCam.GetComponent<ColorBlindManager>();
        if (manager != null)
        {
            manager.EnableColorBlind(activate);
        }
    }*/


}
