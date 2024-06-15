using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab; // Prefab Gelembung
    public float spawnInterval = 1f; // Interval waktu antara spawn gelembung
    public float bubbleLifeTime = 5f; // Waktu hidup gelembung sebelum menghilang

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
        // Tentukan posisi random di sekitar kamera
        Vector3 spawnPosition = GetRandomPositionAroundCamera();
        GameObject bubble = Instantiate(bubblePrefab, spawnPosition, Quaternion.identity);
        Destroy(bubble, bubbleLifeTime); // Hancurkan gelembung setelah waktu hidupnya habis
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
