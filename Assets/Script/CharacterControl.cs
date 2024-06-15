using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float waveFrequency = 1f; // Frequency of the wave oscillation
    [SerializeField] private float waveAmplitude = 0.5f; // Amplitude of the wave oscillation

    public Sprite normalBoatSprite;
    public Sprite superBoatSprite;
    public Sprite rareBoatSprite;
    public Sprite legendaryBoatSprite;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private float waveOffset;

    public ParticleSystem BubbleRight;
    public ParticleSystem BubbleLeft;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        waveOffset = Random.Range(0f, 2f * Mathf.PI); // Randomize the starting point of the wave

        UpdateBoatAttributes(); // Update boat speed and sprite based on the upgrade level
    }

    void Update()
    {
        // Handle input for flipping the character sprite
        if (Input.GetKey(KeyCode.D))
        {
            spriteRenderer.flipX = false; // Facing right
            BubbleRight.Play();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            spriteRenderer.flipX = true; // Facing left
            BubbleLeft.Play();
        }

        // Apply wave motion to the boat's rotation
        float waveRotation = Mathf.Sin(Time.time * waveFrequency + waveOffset) * waveAmplitude;
        transform.rotation = Quaternion.Euler(0f, 0f, waveRotation);
    }

    void FixedUpdate()
    {
        // Handle movement in FixedUpdate for physics consistency
        float moveInput = 0;

        if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1;
        }

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    public void UpdateBoatAttributes() // Change to public
    {
        switch (GameManager.Instance.boatLevel)
        {
            case 1:
                moveSpeed = 5f; // Normal boat speed
                spriteRenderer.sprite = normalBoatSprite;
                break;
            case 2:
                moveSpeed = 10f; // Super boat speed
                spriteRenderer.sprite = superBoatSprite;
                break;
            case 3:
                moveSpeed = 15f; // Rare boat speed
                spriteRenderer.sprite = rareBoatSprite;
                break;
            case 4:
                moveSpeed = 20f; // Legendary boat speed
                spriteRenderer.sprite = legendaryBoatSprite;
                break;
        }
    }
}
