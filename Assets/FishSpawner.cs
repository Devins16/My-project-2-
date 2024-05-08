using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject fishPrefab;
    public int minFishOnScreen;
    public int maxFishOnScreen;
    public float xBorder = 8f;
    public float yBorder = 4.5f;
    public float moveSpeed = 2f;

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
            GameObject fish = Instantiate(fishPrefab, spawnPos, Quaternion.identity);
            fishes.Add(fish);
        }
    }

    void Update()
    {
       
        if (fishes.Count < minFishOnScreen)
        {
            SpawnFish();
        }

        
        foreach (GameObject fish in fishes)
        {
            Vector3 newPosition = fish.transform.position + new Vector3(Mathf.Sin(Time.time) * moveSpeed * Time.deltaTime, 0f, 0f);
            newPosition.x = Mathf.Clamp(newPosition.x, -xBorder, xBorder); 
            fish.transform.position = newPosition;
        }
    }
}
