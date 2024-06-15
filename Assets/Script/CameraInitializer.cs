using UnityEngine;
using Cinemachine;

public class CameraInitializer : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public Transform target;
    public float initialYOffset = 15f;
    public float followYOffset = 1f;
    public float transitionDuration = 2f;

    private CinemachineTransposer transposer;
    private bool isTransitioning = true;
    private float transitionStartTime;

    void Start()
    {
        // Assign the target to the virtual camera
        virtualCamera.Follow = target;

        // Get the Transposer component to adjust its offset
        transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();

        if (transposer != null)
        {
            // Set the initial offset to the initial Y offset
            Vector3 initialOffset = transposer.m_FollowOffset;
            initialOffset.y = initialYOffset;
            transposer.m_FollowOffset = initialOffset;

            // Start the transition
            transitionStartTime = Time.time;
        }
    }

    void Update()
    {
        if (isTransitioning)
        {
            float t = (Time.time - transitionStartTime) / transitionDuration;
            if (t >= 1f)
            {
                t = 1f;
                isTransitioning = false;
            }

            float currentYOffset = Mathf.Lerp(initialYOffset, followYOffset, t);
            Vector3 currentOffset = transposer.m_FollowOffset;
            currentOffset.y = currentYOffset;
            transposer.m_FollowOffset = currentOffset;
        }
    }
}
