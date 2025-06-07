using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Start Time (min/sec)")]
    [Tooltip("Početne minute")]
    public int startMinutes = 1;
    [Tooltip("Početne sekunde (0–59)")]
    [Range(0, 59)] public int startSeconds = 0;

    private float timeRemaining;
    private bool isRunning;
    private float multiplier;

    [Header("UI Reference")]
    public TextMeshProUGUI timeText;

    void Awake()
    {
        timeRemaining = startMinutes * 60f + Mathf.Clamp(startSeconds, 0, 59);
    }

    void Start()
    {
        multiplier = 1;
        isRunning = false;
        UpdateDisplay();
    }

    void Update()
    {
        if (!isRunning) return;
        float delta = Time.deltaTime * multiplier;
        timeRemaining -= delta;

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            isRunning = false;
            OnTimerEnd();
        }

        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        timeText.text = $"{minutes:00}:{seconds:00}";
    }

    void OnTimerEnd()
    {
        Debug.Log("Vreme je isteklo!");
    }


    public void StartTimer() => isRunning = true;

    public void PauseTimer() => isRunning = false;

    public void ResetTimer(float timeRemaining_)
    {
        isRunning = false;
        multiplier = 1;
        timeRemaining = timeRemaining_;
        UpdateDisplay();
    }

    public void SetAccelerated(float multiplier_)
    {
        multiplier *= multiplier_;
    }
}
