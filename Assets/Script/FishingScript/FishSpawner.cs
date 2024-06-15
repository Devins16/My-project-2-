using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] commonFishPrefabs;
    [SerializeField] private GameObject[] rareFishPrefabs;
    [SerializeField] private GameObject[] veryRareFishPrefabs;

    private float commonSpawnRate = 0.9f;
    private float rareSpawnRate = 0.1f;
    private float veryRareSpawnRate = 0f;

    [SerializeField] private int minFishOnScreen;
    [SerializeField] private int maxFishOnScreen;
    [SerializeField] private float xBorder = 8f;
    [SerializeField] private float yBorder = 4.5f;

    private List<GameObject> fishes = new List<GameObject>();

    [SerializeField] private PolygonCollider2D visibilityCollider;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        AdjustSpawnRates();
        SpawnFish();
    }

    void AdjustSpawnRates()
    {
        switch (GameManager.Instance.baitLevel)
        {
            case 1:
                // Normal bait, default rates
                commonSpawnRate = 0.9f;
                rareSpawnRate = 0.1f;
                veryRareSpawnRate = 0f;
                break;
            case 2:
                commonSpawnRate -= 0.2f;
                rareSpawnRate += 0.2f;
                veryRareSpawnRate += 0.1f;
                break;
            case 3:
                commonSpawnRate -= 0.2f;
                rareSpawnRate += 0.2f;
                veryRareSpawnRate += 0.1f;
                break;
            case 4:
                commonSpawnRate -= 0.2f;
                rareSpawnRate += 0.2f;
                veryRareSpawnRate += 0.1f;
                break;
        }

        // Ensure the total spawn rate doesn't exceed 1
        float totalSpawnRate = commonSpawnRate + rareSpawnRate + veryRareSpawnRate;
        if (totalSpawnRate > 1f)
        {
            float normalizationFactor = 1f / totalSpawnRate;
            commonSpawnRate *= normalizationFactor;
            rareSpawnRate *= normalizationFactor;
            veryRareSpawnRate *= normalizationFactor;
        }
    }

    void SpawnFish()
    {
        int numberOfFish = Random.Range(minFishOnScreen, maxFishOnScreen + 1);

        for (int i = 0; i < numberOfFish; i++)
        {
            float randomValue = Random.value;
            GameObject[] fishPrefabsToSpawnFrom;

            if (randomValue < commonSpawnRate)
            {
                fishPrefabsToSpawnFrom = commonFishPrefabs;
            }
            else if (randomValue < commonSpawnRate + rareSpawnRate)
            {
                fishPrefabsToSpawnFrom = rareFishPrefabs;
            }
            else if (veryRareSpawnRate > 0 && randomValue < commonSpawnRate + rareSpawnRate + veryRareSpawnRate)
            {
                fishPrefabsToSpawnFrom = veryRareFishPrefabs;
            }
            else
            {
                continue; // If no category matches, skip spawning this fish
            }

            GameObject fishPrefabToSpawn = fishPrefabsToSpawnFrom[Random.Range(0, fishPrefabsToSpawnFrom.Length)];

            Vector3 spawnPos = transform.position + new Vector3(Random.Range(-xBorder, xBorder), Random.Range(-yBorder, yBorder), 0f);

            GameObject fish = Instantiate(fishPrefabToSpawn, spawnPos, Quaternion.identity);

            fishes.Add(fish);
        }
    }

    void Update()
    {
        UpdateVisibilityColliderBounds();
        UpdateFishVisibility();

        if (fishes.Count < minFishOnScreen)
        {
            SpawnFish();
        }
    }

    void UpdateVisibilityColliderBounds()
    {
        Vector3 cameraPosition = mainCamera.transform.position;
        visibilityCollider.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, 0f);
    }

    void UpdateFishVisibility()
    {
        foreach (GameObject fish in fishes)
        {
            if (fish != null)
            {
                bool isVisible = visibilityCollider.OverlapPoint(fish.transform.position);
                fish.GetComponent<SpriteRenderer>().enabled = isVisible;
            }
        }
    }
}
