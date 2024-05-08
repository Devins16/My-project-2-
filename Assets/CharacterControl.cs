using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private float verticalAmplitude = 1f; // Amplitude of vertical movement
    private float verticalFrequency = 5f; // Frequency of vertical movement

    
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move right if right arrow key is pressed
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        }

        // Move left if left arrow key is pressed
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        }
    }
}