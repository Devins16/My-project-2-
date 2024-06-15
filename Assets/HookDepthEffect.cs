using UnityEngine;
using UnityEngine.UI;

public class HookDepthEffect : MonoBehaviour
{
    public Transform hook;
    public float maxDepth = -10f;
    public float minDepth = 0f;
    public Image blackoutImage;

    public Color shallowColor = Color.cyan;
    public Color middleColor = Color.green;
    public Color deepColor = Color.blue;
    public Color bottomColor = Color.black;

    void Update()
    {
        // Check if tackle level is 3 or greater
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.tacLevel >= 3)
            {
                Debug.Log("Tackle level 3 or higher is active. Changing bottom color to deep color.");
                bottomColor = deepColor;
            }
            else
            {
                bottomColor = Color.black; // Reset to default if below level 3
            }
        }
        else
        {
            Debug.LogWarning("GameManager.Instance is null.");
        }

        // Get the depth of the hook
        float hookDepth = hook.position.y;
        Debug.Log("Hook Depth: " + hookDepth);

        // Normalize hook depth to a value between 0 and 1
        float normalizedDepth = Mathf.InverseLerp(minDepth, maxDepth, hookDepth);
        Debug.Log("Normalized Depth: " + normalizedDepth);

        // Determine the color based on the normalized depth
        Color currentColor;
        if (normalizedDepth < 0.33f)
        {
            currentColor = Color.Lerp(shallowColor, middleColor, normalizedDepth / 0.33f);
        }
        else if (normalizedDepth < 0.66f)
        {
            currentColor = Color.Lerp(middleColor, deepColor, (normalizedDepth - 0.33f) / 0.33f);
        }
        else
        {
            currentColor = Color.Lerp(deepColor, bottomColor, (normalizedDepth - 0.66f) / 0.34f);
        }

        // Set the background color
        Camera.main.backgroundColor = currentColor;
        Debug.Log("Current Background Color: " + currentColor);

        // Adjust the alpha of the blackout image
        if (blackoutImage != null)
        {
            Color blackoutColor = blackoutImage.color;
            blackoutColor.a = Mathf.Lerp(0f, 1f, normalizedDepth);
            blackoutImage.color = blackoutColor;
            Debug.Log("Blackout Image Alpha: " + blackoutColor.a);
        }
        else
        {
            Debug.LogWarning("blackoutImage is null.");
        }
    }
}
