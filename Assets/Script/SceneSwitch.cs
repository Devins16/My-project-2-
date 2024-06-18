using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public TextMeshProUGUI fishPromptText; 
    public AudioSource audioSource; 
    public AudioClip fishSoundEffect; 

    private bool fishingAllowed;
    private string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Spot>())
        {
            sceneToLoad = "Fishing";
            fishingAllowed = true;
           
            fishPromptText.gameObject.SetActive(true);
            fishPromptText.text = "Press Enter to fish";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Spot>())
        {
            fishingAllowed = false;
           
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
