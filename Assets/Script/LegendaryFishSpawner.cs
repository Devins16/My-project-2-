using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegendaryFishSpawner : MonoBehaviour
{
    [SerializeField] private GameObject legendaryFishPrefab;

    [SerializeField] private int minFishOnScreen;
    [SerializeField] private int maxFishOnScreen;
    [SerializeField] private float xBorder = 8f;
    [SerializeField] private float yBorder = 4.5f;

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
            Vector3 spawnPos = transform.position + new Vector3(Random.Range(-xBorder, xBorder), Random.Range(-yBorder, yBorder), 0f);
            GameObject fish = Instantiate(legendaryFishPrefab, spawnPos, Quaternion.identity);
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
