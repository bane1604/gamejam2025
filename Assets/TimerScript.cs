using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{

    [Header("Timer Settings")]
    public float startTime = 60f;        
    private float timeRemaining;
    private bool isRunning = false;

    [Header("UI Reference")]
    public TextMeshProUGUI timeText;              

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
