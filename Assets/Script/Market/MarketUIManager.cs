using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class MarketUIManager : MonoBehaviour
{
    public GameObject fishButtonPrefab;
    public Transform fishButtonParent;
    public GameObject detailPanel;
    public TextMeshProUGUI fishValueText;
    public Button sellButton;

    private FishData currentFish;

    void Start()
    {
        PopulateFishButtons();
        detailPanel.SetActive(false); // Hide detail panel initially


    }



    void PopulateFishButtons()
    {
        foreach (FishData fish in InventoryManager.Instance.GetFishInventory())
        {
            GameObject fishButtonObject = Instantiate(fishButtonPrefab, fishButtonParent);
            FishButton fishButton = fishButtonObject.GetComponent<FishButton>();
            fishButton.Initialize(fish, OnFishButtonClicked);
        }
    }


    void OnFishButtonClicked(FishData fish)
    {
        currentFish = fish;
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
