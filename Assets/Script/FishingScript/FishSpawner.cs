using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject commonFishPrefab;
    public GameObject rareFishPrefab;
    public GameObject veryRareFishPrefab;

    
    public float commonSpawnRate = 0.7f;
    public float rareSpawnRate = 0.2f;
    public float veryRareSpawnRate = 0.1f;

    public int minFishOnScreen;
    public int maxFishOnScreen;
    public float xBorder = 8f;
    public float yBorder = 4.5f;
    

    private List<GameObject> fishes = new List<GameObject>();

    void Start()
    {
        SpawnFish();
    }

    void SpawnFish()
    {
        int numberOfFish = Random.Range(minFishOnScreen, maxFishOnScreen + 1);

        for (int i = 0; i < numberOfFish; i++)
        {
            
            float randomValue = Random.value;
            GameObject fishPrefabToSpawn;

            if (randomValue < commonSpawnRate)
            {
                fishPrefabToSpawn = commonFishPrefab;
            }
            else if (randomValue < commonSpawnRate + rareSpawnRate)
            {
                fishPrefabToSpawn = rareFishPrefab;
            }
            else
            {
                fishPrefabToSpawn = veryRareFishPrefab;
            }

          
            Vector3 spawnPos = transform.position + new Vector3(Random.Range(-xBorder, xBorder), Random.Range(-yBorder, yBorder), 0f);

           
            GameObject fish = Instantiate(fishPrefabToSpawn, spawnPos, Quaternion.identity);

           
            fishes.Add(fish);
        }
    }

    void Update()
    {
        
        if (fishes.Count < minFishOnScreen)
        {
            SpawnFish();
        }
    }
}
