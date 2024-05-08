using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour
{
    public float horizontalSpeed = 5f; 
    public float descendSpeed = 2f; 
    public float descendDistance = 50f; 
    public Camera mainCamera; 
    public float cameraMoveSpeed = 2f; 

    private float initialYPosition; 

    void Start()
    {
        initialYPosition = transform.position.y;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float horizontalMovement = horizontalInput * horizontalSpeed * Time.deltaTime;
        transform.Translate(Vector3.right * horizontalMovement);
        
        float descendMovement = descendSpeed * Time.deltaTime;
        transform.Translate(Vector3.down * descendMovement); 
     
        Vector3 targetCameraPosition = mainCamera.transform.position;
        targetCameraPosition.x = transform.position.x;
        targetCameraPosition.y -= descendMovement;

       
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetCameraPosition, cameraMoveSpeed * Time.deltaTime);

       
        if (transform.position.y <= initialYPosition - descendDistance)
        {
            gameObject.SetActive(false);
        }
    }
}
