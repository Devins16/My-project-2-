using UnityEngine;

public class HookColorChange : MonoBehaviour
{
    public Camera mainCamera; // Kamera utama yang akan berubah warnanya
    public Transform hook; // Transform dari hook
    public float maxDepth = -10f; // Kedalaman maksimum hook
    public float minDepth = 0f; // Kedalaman minimum hook (permukaan air)
    public Color shallowColor = Color.cyan; // Warna air di permukaan
    public Color deepColor = Color.blue; // Warna air di kedalaman maksimum

    void Update()
    {
        // Dapatkan posisi hook di sumbu y
        float hookDepth = hook.position.y;

        // Normalisasi kedalaman hook menjadi nilai antara 0 dan 1
        float normalizedDepth = Mathf.InverseLerp(minDepth, maxDepth, hookDepth);

        // Interpolasi warna berdasarkan kedalaman hook
        mainCamera.backgroundColor = Color.Lerp(shallowColor, deepColor, normalizedDepth);
    }
}
