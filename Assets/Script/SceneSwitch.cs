using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public TextMeshProUGUI fishPromptText; // Reference to the TextMeshProUGUI element
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
        if (fishingAllowed && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
