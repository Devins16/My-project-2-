using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public TextMeshProUGUI fishPromptText; // Reference to the TextMeshProUGUI element
    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip fishSoundEffect; // Reference to the sound effect clip

    private bool fishingAllowed;
    private string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Spot>())
        {
            sceneToLoad = "Fishing";
            fishingAllowed = true;
            // Activate TextMeshProUGUI and set its message
            fishPromptText.gameObject.SetActive(true);
            fishPromptText.text = "Press Enter to fish";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Spot>())
        {
            fishingAllowed = false;
            // Deactivate TextMeshProUGUI
            fishPromptText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            PlaySoundEffect();

            if (fishingAllowed)
            {
                LoadFishingScene();
            }
        }
    }

    private void PlaySoundEffect()
    {
        if (audioSource != null && fishSoundEffect != null)
        {
            audioSource.PlayOneShot(fishSoundEffect);
        }
    }

    private void LoadFishingScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
