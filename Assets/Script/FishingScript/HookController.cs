using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class HookController : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float descendSpeed;
    [SerializeField] private float ascendSpeed;
    [SerializeField] private float descendDistance;
    [SerializeField] private float pauseDuration;
    public static HookController instance;
    [SerializeField] private float CurrentWeight;
    [SerializeField] private float MaxWeight;

    [SerializeField] private TextMeshProUGUI descendDistanceText;
    [SerializeField] private TextMeshProUGUI fishCounterText;
    [SerializeField] private Button returnToMapButton;

    // UI elements for results
    [SerializeField] private GameObject resultsPanel;
    [SerializeField] private TextMeshProUGUI depthText;
    [SerializeField] private TextMeshProUGUI totalFishText;
    [SerializeField] private GameObject fishScrollViewContent;
    [SerializeField] private GameObject fishItemPrefab;

    private float initialYPosition;
    private float deepestDepth = 0f;
    private bool isDescending = false;
    private bool isAscending = false;
    private bool isPaused = false;
    private float pauseTimer = 0f;
    private bool canCatchFish = true;  // Add this flag

    private int totalValue = 0;
    private int fishCount = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        initialYPosition = transform.position.y;
        returnToMapButton.gameObject.SetActive(false);
        returnToMapButton.onClick.AddListener(ReturnToMap);

        resultsPanel.SetActive(false);
    }

    void Update()
    {
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
            transform.Translate(Vector3.right * horizontalMovement);

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
            }
        }
        else if (!isPaused)
        {
            float ascendMovement = ascendSpeed * Time.deltaTime;
            transform.Translate(Vector3.up * ascendMovement);

            if (transform.position.y >= initialYPosition)
            {
                isPaused = true;

                returnToMapButton.gameObject.SetActive(true);

                StartCoroutine(HandleFishPositions());
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
            }
        }

        UpdateFishCounter();
        UpdateDepthCounter();
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
                    Vector3 fishPosition = fish.transform.position;
                    fishPosition.x = transform.position.x;
                    fish.transform.position = fishPosition;
                    fish.transform.parent = this.transform;
                    fish.FreezePosition();
                    CurrentWeight += fish.weight;
                    totalValue += fish.value;
                    fishCount++;
                }
            }
        }
    }

    void UpdateFishCounter()
    {
        if (fishCounterText != null)
        {
            fishCounterText.text = "Fish Caught: " + fishCount.ToString();
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
        Debug.Log("HandleFishPositions started");

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
                FishMovement fishMovement = fish.GetComponent<FishMovement>();
                fishCount++;
            }
        }

        Debug.Log("Total value: $" + totalValue);

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
                    FishData fishdata = new FishData();
                    fishdata.SetValue(fish.GetComponent<FishMovement>().value, fish.GetComponent<FishMovement>().fishso);
                    InventoryManager.Instance.AddFish(fishdata);
                    fishImage.sprite = fishSpriteRenderer.sprite;
                    Debug.Log("Added fish to results: " + fish.name);
                }
            }
        }
    }
}
