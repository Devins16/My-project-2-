using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoatHelpManager : MonoBehaviour
{
    public Button helpButton;   // Reference to the help button
    public Button okButton;     // Reference to the OK button
    public GameObject helpPanel; // Reference to the help panel
    public TMP_Text helpText;   // Reference to the help text

    void Start()
    {
        // Add listener to help button to show help panel
        helpButton.onClick.AddListener(ShowHelp);

        // Add listener to OK button to close help panel
        okButton.onClick.AddListener(CloseHelp);

        // Hide help panel initially
        helpPanel.SetActive(false);
    }

    void ShowHelp()
    {
        // Show the help panel
        helpPanel.SetActive(true);

        // Pause the game
        Time.timeScale = 0;
    }

    void CloseHelp()
    {
        // Hide the help panel
        helpPanel.SetActive(false);

        // Resume the game
        Time.timeScale = 1;
    }
}
