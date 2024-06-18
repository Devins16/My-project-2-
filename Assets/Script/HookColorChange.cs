using UnityEngine;

public class HookColorChange : MonoBehaviour
{
    public Camera mainCamera; 
    public Transform hook; 
    public float maxDepth = -10f;
    public float minDepth = 0f; 
    public Color shallowColor = Color.cyan; 
    public Color deepColor = Color.blue; 

    void Update()
    {
      
        float hookDepth = hook.position.y;

       
        float normalizedDepth = Mathf.InverseLerp(minDepth, maxDepth, hookDepth);

       
        mainCamera.backgroundColor = Color.Lerp(shallowColor, deepColor, normalizedDepth);
    }
}
