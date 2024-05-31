using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Handle input for flipping the character sprite
        if (Input.GetKey(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false; // Facing right
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true; // Facing left
        }
    }

    void FixedUpdate()
    {
        // Handle movement in FixedUpdate for physics consistency
        float moveInput = 0;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveInput = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveInput = -1;
        }

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }
}
    