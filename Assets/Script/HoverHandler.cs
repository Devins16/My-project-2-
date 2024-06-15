using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class HoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject infoPanel; // Reference to the panel
    public TextMeshProUGUI locationText; // Reference to the text component in the panel
    public string locationName; // The name to be displayed
    private Animator panelAnimator; // Reference to the panel's Animator component

    void Start()
    {
        // Ensure the panel is hidden at the start
        if (infoPanel != null)
        {
            panelAnimator = infoPanel.GetComponent<Animator>();
            infoPanel.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Show the panel and update the text when the pointer enters the button
        if (infoPanel != null && locationText != null)
        {
            infoPanel.SetActive(true);
            locationText.text = locationName;
            panelAnimator.SetTrigger("Open");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Hide the panel when the pointer exits the button
        if (infoPanel != null)
        {
            infoPanel.SetActive(false);
        }
    }
}
