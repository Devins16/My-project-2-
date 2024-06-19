using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<FishData> fishInventory = new List<FishData>();
    public List<FishSo> fishDatabase = new List<FishSo>();
    public string legendaryFishName = "Legendary Fish"; // Name of the legendary fish
    public string endingSceneName = "EndingScene"; // Name of the ending scene

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddFish(FishSo fishSo, float value)
    {
        FishData fishData = new FishData
        {
            Fish = fishSo,
            Value = value,
            FishSprite = fishSo.fishSprite,
            FishName = fishSo.fishName // Ensure the fish name is set
        };
        fishInventory.Add(fishData);

        // Check if the added fish is a legendary fish
        if (fishSo.fishName == legendaryFishName)
        {
            ChangeSceneToEnding();
        }
    }

    public List<FishData> GetFishInventory()
    {
        return new List<FishData>(fishInventory);
    }

    public void RemoveFish(FishData fish)
    {
        fishInventory.Remove(fish);
    }

    private void ChangeSceneToEnding()
    {
        SceneManager.LoadScene(endingSceneName);
    }
}

[System.Serializable]
public struct FishData
{
    public FishSo Fish;
    public float Value;
    public Sprite FishSprite;
    public string FishName;

    public void SetValue(float value, FishSo fish)
    {
        Value = value;
        Fish = fish;
        FishSprite = fish.fishSprite;
        FishName = fish.fishName;
    }
}
