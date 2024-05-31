using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public enum FishType
    {
        Common,
        Rare,
        VeryRare
    }

    public FishType fishType;
    public bool isCatch = false;
    public float weight = 100f;
    public float xBorder = 8f;
    public float yBorder = 4.5f;
    public float moveSpeed = 2f;
    public int value;
    public FishSo fishso;

    private float xOffset;
    private Vector3 originalPosition;
    private SpriteRenderer spriteRenderer;
    private float previousX;

    void Start()
    {
        xOffset = Random.Range(-1f, 1f);
        originalPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        previousX = transform.position.x;

        switch (fishType)
        {
            case FishType.Common:
                value = Random.Range(10, 20);
                break;
            case FishType.Rare:
                value = Random.Range(20, 30);
                break;
            case FishType.VeryRare:
                value = Random.Range(30, 50);
                break;
        }
    }

    void Update()
    {
        if (!isCatch)
        {
            float timeOffset = Time.time * 0.5f + xOffset;
            Vector3 newPosition = transform.position + new Vector3(Mathf.Sin(timeOffset) * moveSpeed * Time.deltaTime, 0f, 0f);
            newPosition.x = Mathf.Clamp(newPosition.x, -xBorder, xBorder);

            // Flip the sprite based on movement direction
            if (newPosition.x > previousX)
            {
                spriteRenderer.flipX = true; // Facing right
            }
            else if (newPosition.x < previousX)
            {
                spriteRenderer.flipX = false; // Facing left
            }

            transform.position = newPosition;
            previousX = newPosition.x;
        }
    }

    public void FreezePosition()
    {
        isCatch = true;
        originalPosition = transform.position;
    }
}
