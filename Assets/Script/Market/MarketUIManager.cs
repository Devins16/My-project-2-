using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class MarketUIManager : MonoBehaviour
{
    public GameObject fishButtonPrefab;
    public Transform fishButtonParent;
    public GameObject detailPanel;
    public TextMeshProUGUI fishNameText; // Add this field for fish name
    public Image fishImage; // Add this field for fish image
    public TextMeshProUGUI fishValueText;
    public Button sellButton;
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;

    private FishData currentFish;

    void Start()
    {
        PopulateFishButtons();
        detailPanel.SetActive(false); // Hide detail panel initially
        dialogueBox.SetActive(false); // Hide dialogue box initially
    }

    void PopulateFishButtons()
    {
        List<FishData> fishInventory = InventoryManager.Instance.GetFishInventory();

        if (fishInventory.Count == 0)
        {
            dialogueText.text = "You need to catch fish to sell me one hahaha";
            dialogueBox.SetActive(true);
            return;
        }

        foreach (FishData fish in fishInventory)
        {
            GameObject fishButtonObject = Instantiate(fishButtonPrefab, fishButtonParent);
            FishButton fishButton = fishButtonObject.GetComponent<FishButton>();

            fishButton.Initialize(fish, OnFishButtonClicked);
        }

        if (fishButtonPrefab != null)
        {
            Destroy(fishButtonPrefab);
        }
    }

    void OnFishButtonClicked(FishData fish)
    {
        currentFish = fish;
        fishNameText.text = fish.Fish.fishName; // Display fish name
        fishImage.sprite = fish.Fish.fishIcon; // Display fish image
        fishValueText.text = $"Value: {fish.Value}";
        detailPanel.SetActive(true);
        sellButton.onClick.RemoveAllListeners();
        sellButton.onClick.AddListener(OnSellButtonClicked);
    }

    void OnSellButtonClicked()
    {
        InventoryManager.Instance.RemoveFish(currentFish);
        GameManager.Instance.AddMoney(currentFish.Value); // Add money to the player
        detailPanel.SetActive(false);
        DestroyFishButton(currentFish); // Destroy the sold fish button
    }

    void DestroyFishButton(FishData fish)
    {
        foreach (Transform child in fishButtonParent)
        {
            FishButton fishButton = child.GetComponent<FishButton>();
            if (fishButton != null && fishButton.Fish.Fish == fish.Fish)
            {
                Destroy(child.gameObject);
                break;
            }
        }
    }
}
