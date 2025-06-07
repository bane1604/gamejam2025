using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    public UnityEngine.Camera mapCamera;
    public Camera roomCamera;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        if (GameManager.Instance.IsPreparationPhase())
        {
            mapCamera.gameObject.SetActive(true);
            roomCamera.gameObject.SetActive(false);
            Debug.Log("Preparation phase: Map Camera enabled");
        }
        else
        {
            mapCamera.gameObject.SetActive(false);
            roomCamera.gameObject.SetActive(true);
            Debug.Log("Gameplay phase: Room Camera enabled");
        }
    }

    public void SwitchToRoomCamera()
    {
        mapCamera.gameObject.SetActive(false);
        roomCamera.gameObject.SetActive(true);
    }
}
