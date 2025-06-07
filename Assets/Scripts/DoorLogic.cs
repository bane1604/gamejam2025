using System;
using System.Collections;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    public float invertDelay = 1f;
    public GameObject colorBlindOverlay;
    private bool isColorBlindActive = false;

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            string doorTag = gameObject.tag;

            switch (doorTag)
            {
                case "BlueDoor":
                    ApplySpeedBoost(collision.gameObject);
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
                case "PurpleDoor":
                    ToggleColorBlindOverlay();
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
        player.ApplySlow();
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


    private void ApplySpeedBoost(GameObject gameObject)
    {
        Player player = gameObject.GetComponent<Player>();
        player.ApplyBoost();
    }
    
    private void ToggleColorBlindOverlay()
    {
        SpriteRenderer sr = colorBlindOverlay.GetComponent<SpriteRenderer>();

        if (!isColorBlindActive)
        {
            sr.color = new Color(0.5f, 0.5f, 0.5f, 0.7f);
            isColorBlindActive = true;
        }
        else
        {
            sr.color = new Color(0.5f, 0.5f, 0.5f, 0f);
            isColorBlindActive = false;
        }
    }

}
