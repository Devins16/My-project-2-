using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class HookController : MonoBehaviour
{
    public static HookController instance;

    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float descendSpeed;
    [SerializeField] private float ascendSpeed;
    [SerializeField] private float pauseDuration;
    public float descendDistance;  // Make public for GearUpgradeManager to modify
    public float MaxWeight;        // Make public for GearUpgradeManager to modify
    private float CurrentWeight;

    [SerializeField] private TextMeshProUGUI descendDistanceText;
    [SerializeField] private TextMeshProUGUI fishCounterText;
    [SerializeField] private Button returnToMapButton;

    // UI elements for results
    [SerializeField] private GameObject resultsPanel;
    [SerializeField] private TextMeshProUGUI depthText;
    [SerializeField] private TextMeshProUGUI totalFishText;
    [SerializeField] private GameObject fishScrollViewContent;
    [SerializeField] private GameObject fishItemPrefab;

    // UI elements for fight back mechanic
    [SerializeField] private Slider fightBackMeter;
    [SerializeField] private float fightBackThreshold = 10f;
    private bool isFightingBack = false;
    private bool fightBackCompleted = false;  // Add this flag
    private float fightBackValue = 0f;

    private float initialYPosition;
    private float deepestDepth = 0f;
    private bool isDescending = false;
    private bool isAscending = false;
    private bool isPaused = false;
    private float pauseTimer = 0f;
    private bool canCatchFish = true;  // Add this flag

    private int totalValue = 0;
    private int fishCount = 0;

    // Define maxDepths and maxWeights here
    public float[] maxDepths = { 0f, 50f, 200f, 400f, 508f };
    public int[] maxWeights = { 0, 1000, 2000, 3000, 5000 };

    [SerializeField] private Vector2 hookAttachmentOffset; // Add this line for the offset

    // References to the panels to hide
    [SerializeField] private GameObject panel1;  // Replace with your actual panel names
    [SerializeField] private GameObject panel2;  // Replace with your actual panel names

    // Audio
    [SerializeField] private AudioSource ascendingSound; // Add this line for the ascending sound
    [SerializeField] private AudioSource fishCatchSound; // Add this line for the fish catch sound

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        initialYPosition = transform.position.y;
        returnToMapButton.gameObject.SetActive(false);
        returnToMapButton.onClick.AddListener(ReturnToMap);

        fishCounterText.enabled = true;
        descendDistanceText.enabled = true;
        resultsPanel.SetActive(false);
        fightBackMeter.gameObject.SetActive(false);

        // Initialize values based on stored levels
        MaxWeight = maxWeights[GameManager.Instance.rodLevel];
        descendDistance = maxDepths[GameManager.Instance.lineLevel];
    }

    void Update()
    {
        if (isFightingBack)
        {
            HandleFightBack();
            return;
        }

        if (!isDescending)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                isDescending = true;
            }
        }
        else if (!isAscending)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float horizontalMovement = horizontalInput * horizontalSpeed * Time.deltaTime;

            // Apply tackle level effects
            switch (GameManager.Instance.tacLevel)
            {
                case 1:
                    // No additional effect
                    break;
                case 2:
                    horizontalMovement *= 3;  // Increase horizontal speed by 3x
                    break;
                case 3:
                    // Handle blackout image removal
                    // Assumes you have a reference to the blackout image and its removal logic
                    // For example:
                    // blackoutImage.SetActive(false);
                    break;
                case 4:
                    if (Input.GetKey(KeyCode.C))
                    {
                        canCatchFish = false;
                    }
                    else
                    {
                        canCatchFish = true;
                    }
                    break;
            }

            transform.Translate(Vector3.right * horizontalMovement);

            // Clamp the horizontal position within the boundary
            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, -50f, 50f);
            transform.position = clampedPosition;

            float descendMovement = descendSpeed * Time.deltaTime;
            transform.Translate(Vector3.down * descendMovement);

            float currentDepth = Mathf.Max(0, initialYPosition - transform.position.y);
            if (descendDistanceText != null)
            {
                descendDistanceText.text = "Depth: " + currentDepth.ToString("F1") + "m";
            }

            if (currentDepth > deepestDepth)
            {
                deepestDepth = currentDepth;
            }

            if (transform.position.y <= initialYPosition - descendDistance || Input.GetKeyDown(KeyCode.W))
            {
                isAscending = true;
                canCatchFish = false;  // Disable catching fish when ascending
                PlayAscendingSound(); // Start the ascending sound effect
            }
        }
        else if (!isPaused)
        {
            // Check if halfway through the ascent and fight back not completed
            if (transform.position.y >= initialYPosition - descendDistance / 2f && !fightBackCompleted)
            {
                isFightingBack = true;
                fightBackMeter.gameObject.SetActive(true);
            }
            else
            {
                float ascendMovement = ascendSpeed * Time.deltaTime;
                transform.Translate(Vector3.up * ascendMovement);

                if (transform.position.y >= initialYPosition)
                {
                    isPaused = true;
                    returnToMapButton.gameObject.SetActive(true);
                    StartCoroutine(HandleFishPositions());
                    StopAscendingSound(); // Stop the ascending sound effect
                }
            }
        }
        else
        {
            pauseTimer += Time.deltaTime;
            if (pauseTimer >= pauseDuration)
            {
                isPaused = false;
                pauseTimer = 0f;
                isDescending = false;
                isAscending = false;
                canCatchFish = true;  // Re-enable catching fish after the pause
                fightBackCompleted = false;  // Reset the fight back flag for the next descent
            }
        }

        UpdateFishCounter();
        UpdateDepthCounter();
    }

    private void HandleFightBack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fightBackValue += 1f;
            fightBackMeter.value = fightBackValue / fightBackThreshold;

            if (fightBackValue >= fightBackThreshold)
            {
                isFightingBack = false;
                fightBackCompleted = true;
                fightBackMeter.gameObject.SetActive(false);
                fightBackValue = 0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (canCatchFish && CurrentWeight < MaxWeight)  // Check the flag before catching fish
        {
            if (col.CompareTag("Fish"))
            {
                FishMovement fish = col.gameObject.GetComponent<FishMovement>();
                if (fish != null)
                {
                    fish.isCatch = true;

                    // Change the body type to Dynamic to allow physics interaction
                    fish.fishRigidbody.bodyType = RigidbodyType2D.Dynamic;

                    Vector3 hookPosition = transform.position;

                    // Align the fish's mouth to the hook with an offset
                    if (fish.mouthTransform != null)
                    {
                        Vector3 mouthOffset = fish.mouthTransform.position - fish.transform.position;
                        fish.transform.position = hookPosition - mouthOffset + (Vector3)hookAttachmentOffset;
                    }
                    else
                    {
                        fish.transform.position = hookPosition + (Vector3)hookAttachmentOffset;
                    }

                    fish.transform.parent = this.transform;

                    // Add a hinge joint to simulate the physics
                    HingeJoint2D hingeJoint = fish.gameObject.AddComponent<HingeJoint2D>();
                    hingeJoint.connectedBody = GetComponent<Rigidbody2D>();
                    hingeJoint.anchor = fish.mouthTransform.localPosition;

                    CurrentWeight += fish.weight;
                    totalValue += fish.value;
                    fishCount++;

                    PlayFishCatchSound(); // Play the fish catch sound effect
                }
            }
        }
    }

    void UpdateFishCounter()
    {
        if (fishCounterText != null)
        {
            fishCounterText.text = "Catch: " + fishCount.ToString();
        }
    }

    void UpdateDepthCounter()
    {
        if (descendDistanceText != null)
        {
            float depth = isAscending ? transform.position.y - initialYPosition : initialYPosition - transform.position.y;
            descendDistanceText.text = "Depth: " + Mathf.Max(0, depth).ToString("F1") + "m";
        }
    }

    void ReturnToMap()
    {
        SceneManager.LoadScene("Map");
    }

    private IEnumerator HandleFishPositions()
    {
        yield return new WaitForSeconds(0.5f);

        Transform[] fishList = GetComponentsInChildren<Transform>();
        int fishCount = 0;
        foreach (Transform fish in fishList)
        {
            if (fish.CompareTag("Fish"))
            {
                fish.parent = null;

                float spread = 1.5f;
                float offsetX = spread * (fishCount - (fishList.Length - 2) / 2f);

                Vector3 fishPosition = transform.position;
                fishPosition.y -= 2f;
                fishPosition.x += offsetX;
                fish.position = fishPosition;
                fishCount++;
            }
        }

        fishCounterText.enabled = false;
        descendDistanceText.enabled = false;

        // Hide the additional panels
        panel1.SetActive(false);
        panel2.SetActive(false);

        resultsPanel.SetActive(true);

        depthText.text = "Reached: " + deepestDepth.ToString("F1") + "m";
        totalFishText.text = "Total Fish: " + fishCount.ToString();

        foreach (Transform child in fishScrollViewContent.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform fish in fishList)
        {
            if (fish.CompareTag("Fish"))
            {
                GameObject fishItem = Instantiate(fishItemPrefab, fishScrollViewContent.transform);
                Image fishImage = fishItem.GetComponent<Image>();
                SpriteRenderer fishSpriteRenderer = fish.GetComponent<SpriteRenderer>();

                if (fishImage != null && fishSpriteRenderer != null)
                {
                    FishMovement fishMovement = fish.GetComponent<FishMovement>();
                    FishData fishData = new FishData();
                    fishData.SetValue(fishMovement.value, fishMovement.fishso);
                    InventoryManager.Instance.AddFish(fishMovement.fishso, fishMovement.value); // Corrected line
                    fishImage.sprite = fishSpriteRenderer.sprite;
                }
            }
        }
    }

    // Methods to control the ascending sound effect
    private void PlayAscendingSound()
    {
        if (ascendingSound != null && !ascendingSound.isPlaying)
        {
            ascendingSound.loop = true;
            ascendingSound.Play();
        }
    }

    private void StopAscendingSound()
    {
        if (ascendingSound != null && ascendingSound.isPlaying)
        {
            ascendingSound.loop = false;
            ascendingSound.Stop();
        }
    }

    // Method to play the fish catch sound effect
    private void PlayFishCatchSound()
    {
        if (fishCatchSound != null)
        {
            fishCatchSound.Play();
        }
    }
}
