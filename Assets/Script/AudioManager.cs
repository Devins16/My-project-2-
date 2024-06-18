using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public AudioSource audioSource;
    public AudioClip mapMusic;
    public AudioClip boatingMusic;

    void Awake()
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
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void PlayMapMusic()
    {
        if (audioSource.clip != mapMusic)
        {
            audioSource.clip = mapMusic;
            audioSource.Play();
        }
    }

    public void PlayBoatingMusic()
    {
        if (audioSource.clip != boatingMusic)
        {
            audioSource.clip = boatingMusic;
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
