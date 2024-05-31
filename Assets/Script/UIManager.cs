using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject fishInfoPanel;
    public Text fishListText;
    public Text depthText;
    public Text valueText;

    // Method to update UI with fish caught, depth, and value
    public void UpdateUI(string[] fishList, float depth, int value)
    {
        fishListText.text = "Fish Caught:\n";
        foreach (string fish in fishList)
        {
            fishListText.text += fish + "\n";
        }
        depthText.text = "Reached Depth: " + depth.ToString("F1");
        valueText.text = "Total Value: $" + value.ToString("N0");

        // Show the UI panel
        fishInfoPanel.SetActive(true);
    }
}
