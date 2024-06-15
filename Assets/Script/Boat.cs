using UnityEngine;

public class Boat : MonoBehaviour
{
    public SpriteRenderer boatSpriteRenderer;
    public Sprite[] boatSprites; // Array untuk menyimpan sprites kapal sesuai level

    private int currentBoatLevel;

    void Start()
    {
        // Mengatur level kapal sesuai dengan GameManager
        currentBoatLevel = GameManager.Instance.boatLevel;
        UpdateBoatSprite();
    }

    void UpdateBoatSprite()
    {
        if (boatSprites != null && boatSprites.Length > 0 && currentBoatLevel >= 1 && currentBoatLevel <= boatSprites.Length)
        {
            boatSpriteRenderer.sprite = boatSprites[currentBoatLevel - 1];
        }
        else
        {
            Debug.LogWarning("Boat sprites are not properly set or level is out of range.");
        }
    }

    public void SetBoatLevel(int level)
    {
        if (level >= 1 && level <= boatSprites.Length)
        {
            currentBoatLevel = level;
            UpdateBoatSprite();
            Debug.Log($"Boat level set to {currentBoatLevel}. Sprite updated.");
        }
        else
        {
            Debug.LogWarning($"Invalid boat level: {level}. It should be between 1 and {boatSprites.Length}.");
        }
    }
}
