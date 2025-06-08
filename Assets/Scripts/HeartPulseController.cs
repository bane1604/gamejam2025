using UnityEngine;

public class HeartPulseController : MonoBehaviour
{
    public Animator animator;
    public Timer timer; 

    public float maxSpeed = 1.2f; 
    public float minSpeed = 0.3f; 

    private float totalTime;

    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        totalTime = timer.startMinutes * 60f + timer.startSeconds;

        animator.Play("HeartPulse"); 
    }

    void Update()
    {
        float timeLeft = Mathf.Clamp(timerTimeLeft(), 0f, totalTime);

        float t = timeLeft / totalTime;
        animator.speed = Mathf.Lerp(minSpeed, maxSpeed, t);
    }

    float timerTimeLeft()
    {
        System.Reflection.FieldInfo fi = typeof(Timer).GetField("timeRemaining", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        return (float)fi.GetValue(timer);
    }
}
