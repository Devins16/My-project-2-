using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab; 
    public float spawnInterval = 1f; 
    public float bubbleLifeTime = 5f; 

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(SpawnBubbles());
    }

    IEnumerator SpawnBubbles()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnBubble();
        }
    }

    void SpawnBubble()
    {
        
        Vector3 spawnPosition = GetRandomPositionAroundCamera();
        GameObject bubble = Instantiate(bubblePrefab, spawnPosition, Quaternion.identity);
        Destroy(bubble, bubbleLifeTime); 
    }

    Vector3 GetRandomPositionAroundCamera()
    {
        float x = Random.Range(mainCamera.transform.position.x - mainCamera.orthographicSize * mainCamera.aspect,
                               mainCamera.transform.position.x + mainCamera.orthographicSize * mainCamera.aspect);
        float y = Random.Range(mainCamera.transform.position.y - mainCamera.orthographicSize,
                               mainCamera.transform.position.y + mainCamera.orthographicSize);
        return new Vector3(x, y, 0);
    }
}
