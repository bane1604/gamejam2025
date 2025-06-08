using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource bgMusicSource;
    public AudioSource heartbeatSource;
    public AudioSource footstepSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        bgMusicSource.loop = true;
        bgMusicSource.volume = 0.2f; // Low volume
        bgMusicSource.Play();
    }

    public void SetHeartbeatRate(float bpm)
    {
        heartbeatSource.pitch = bpm / 60f; // Normalize to 1.0 at 60 BPM
    }

    public void PlayFootstep()
    {
        if (!footstepSource.isPlaying)
        {
            footstepSource.Play();
        }
    }

    public void StopFootstep()
    {
        footstepSource.Stop();
    }

    public void StopBackgroundMusic()
    {
        if (bgMusicSource != null && bgMusicSource.isPlaying)
        {
            bgMusicSource.Stop();
            heartbeatSource.Stop();
            footstepSource.Stop();
        }
    }

}
