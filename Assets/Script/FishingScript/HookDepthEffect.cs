using UnityEngine;
using UnityEngine.UI;

public class HookDepthEffect : MonoBehaviour
{
    public Transform hook;
    public float maxDepth = -400f;
    public float minDepth = 0f;
    public Image blackoutImage;

    public Color shallowColor = Color.cyan;
    public Color middleColor = Color.green;
    public Color deepColor = Color.blue;
    public Color bottomColor = Color.black;

    void Update()
    {
        
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.tacLevel >= 3)
            {
                Debug.Log("Tackle level 3 or higher is active. Changing bottom color to deep color.");
                bottomColor = deepColor;
            }
            else
            {
                bottomColor = Color.black; 
            }
        }
        

        
        float hookDepth = hook.position.y;
        

       
        float normalizedDepth = Mathf.InverseLerp(minDepth, maxDepth, hookDepth);
        

       
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

        
        Camera.main.backgroundColor = currentColor;
        

       
        if (blackoutImage != null)
        {
            Color blackoutColor = blackoutImage.color;
            blackoutColor.a = Mathf.Lerp(0f, 1f, normalizedDepth);
            blackoutImage.color = blackoutColor;
          
        }
        else
        {
          
        }
    }
}
