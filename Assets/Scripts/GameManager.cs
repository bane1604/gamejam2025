using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Timer timerManager;
    public static GameManager Instance;
    public Player player;
    public enum GamePhase
    {
        Preparation,
        Gameplay,
        End
    }

    public GamePhase currentPhase = GamePhase.Preparation;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public bool IsPreparationPhase()
    {
        return currentPhase == GamePhase.Preparation;
    }

    public void StartGameplayPhase()
    {
        currentPhase = GamePhase.Gameplay;
        CameraManager.Instance.SwitchToRoomCamera();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            timerManager.StartTimer();
            StartGameplayPhase();
            player.SetMovement(true);
        }

        if(timerManager.OutOfTime())
        {
            //TODO: Game over
            player.SetMovement(false);
            currentPhase = GamePhase.End;
        }
    }

    public GamePhase GetGamePhase()
    {
        return currentPhase;
    }
}
