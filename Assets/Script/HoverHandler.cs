using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class HoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject infoPanel; 
    public TextMeshProUGUI locationText; 
    public string locationName; 
    private Animator panelAnimator; 

    void Start()
    {
       
        if (infoPanel != null)
        {
            panelAnimator = infoPanel.GetComponent<Animator>();
            infoPanel.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
     
        if (infoPanel != null && locationText != null)
        {
            infoPanel.SetActive(true);
            locationText.text = locationName;
            panelAnimator.SetTrigger("Open");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(false);
        }
    }
}
