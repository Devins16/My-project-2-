using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<FishData> fishInventory = new List<FishData>();
    public List<FishSo> fishDatabase = new List<FishSo>();

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

    public void AddFish(FishData fish)
    {
        fishInventory.Add(fish);
       
    }

    public List<FishData> GetFishInventory()
    {
        return new List<FishData>(fishInventory);

    }
    public void RemoveFish(FishData fish)
    {
        fishInventory.Remove(fish);
        
    }

}




[System.Serializable]

public struct FishData
{
    public FishSo Fish;
    public float Value;

    public void SetValue(float value, FishSo fish)
    {
        Value = value;
        Fish = fish;
    }
}
