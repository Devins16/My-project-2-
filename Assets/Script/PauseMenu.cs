using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPrefab; 
    public GameObject muteIndicator; 
    public Sprite mutedSprite; 
    public Sprite unmutedSprite; 

    private GameObject pauseMenuUI;
    private bool isPaused = false;
    private bool isMuted = false;

    private static PauseMenu instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
            CreatePauseMenuUI();
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (pauseMenuUI == null)
        {
            CreatePauseMenuUI();
        }
    }

    void CreatePauseMenuUI()
    {
        if (pauseMenuPrefab == null)
        {
            Debug.LogError("PauseMenuPrefab is not assigned in the inspector.");
            return;
        }

        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            pauseMenuUI = Instantiate(pauseMenuPrefab, canvas.transform);
            pauseMenuUI.SetActive(false);
            DontDestroyOnLoad(pauseMenuUI);
        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
    }

    void Pause()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
    }

    public void Save()
    {
        Debug.Log("Game Saved!");
       
    }

    public void OpenSettings()
    {
        Debug.Log("Settings Opened!");
        ToggleMute();
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;

        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.mute = isMuted;
        }

        UpdateMuteIndicator();
    }

    void UpdateMuteIndicator()
    {
        if (muteIndicator != null && mutedSprite != null && unmutedSprite != null)
        {
            Image indicatorImage = muteIndicator.GetComponent<Image>();
            if (indicatorImage != null)
            {
                indicatorImage.sprite = isMuted ? mutedSprite : unmutedSprite;
            }
        }
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
}
