using UnityEngine;

public class Spot : MonoBehaviour
{
    public float minX = 10f;  // Batas kiri
    public float maxX = 100f; // Batas kanan
    public float interval = 20f; // Interval in seconds

    void Start()
    {
        ChangePosition();
        InvokeRepeating("ChangePosition", interval, interval);
    }

    void ChangePosition()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 newPosition = new Vector3(randomX, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }
}
