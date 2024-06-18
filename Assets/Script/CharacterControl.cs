using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float waveFrequency = 1f; 
    [SerializeField] private float waveAmplitude = 0.5f; 

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
        waveOffset = Random.Range(0f, 2f * Mathf.PI); 

        UpdateBoatAttributes(); 
    }

    void Update()
    {
       
        if (Input.GetKey(KeyCode.D))
        {
            spriteRenderer.flipX = false;
            BubbleRight.Play();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            spriteRenderer.flipX = true; 
            BubbleLeft.Play();
        }

       
        float waveRotation = Mathf.Sin(Time.time * waveFrequency + waveOffset) * waveAmplitude;
        transform.rotation = Quaternion.Euler(0f, 0f, waveRotation);
    }

    void FixedUpdate()
    {
       
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

    public void UpdateBoatAttributes() 
    {
        switch (GameManager.Instance.boatLevel)
        {
            case 1:
                moveSpeed = 5f; 
                spriteRenderer.sprite = normalBoatSprite;
                break;
            case 2:
                moveSpeed = 10f; 
                spriteRenderer.sprite = superBoatSprite;
                break;
            case 3:
                moveSpeed = 15f; 
                spriteRenderer.sprite = rareBoatSprite;
                break;
            case 4:
                moveSpeed = 20f; 
                spriteRenderer.sprite = legendaryBoatSprite;
                break;
        }
    }
}
