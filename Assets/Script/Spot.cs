using UnityEngine;

public class Spot : MonoBehaviour
{
    public float minX = 10f;  
    public float maxX = 100f; 
    public float interval = 20f; 

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
