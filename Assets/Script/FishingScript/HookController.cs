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
    public float descendDistance;  
    public float MaxWeight;        
    private float CurrentWeight;

    [SerializeField] private TextMeshProUGUI descendDistanceText;
    [SerializeField] private TextMeshProUGUI fishCounterText;
    [SerializeField] private Button returnToMapButton;

    [SerializeField] private GameObject resultsPanel;
    [SerializeField] private TextMeshProUGUI depthText;
    [SerializeField] private TextMeshProUGUI totalFishText;
    [SerializeField] private GameObject fishScrollViewContent;
    [SerializeField] private GameObject fishItemPrefab;

    [SerializeField] private Slider fightBackMeter;
    [SerializeField] private float fightBackThreshold = 10f;
    private bool isFightingBack = false;
    private bool fightBackCompleted = false;  
    private float fightBackValue = 0f;

    private float initialYPosition;
    private float deepestDepth = 0f;
    private bool isDescending = false;
    private bool isAscending = false;
    private bool isPaused = false;
    private float pauseTimer = 0f;
    private bool canCatchFish = true;  

    private int totalValue = 0;
    private int fishCount = 0;

    public float[] maxDepths = { 0f, 50f, 200f, 400f, 508f };
    public int[] maxWeights = { 0, 1000, 2000, 3000, 5000 };

    [SerializeField] private Vector2 hookAttachmentOffset; 

    [SerializeField] private GameObject panel1;  
    [SerializeField] private GameObject panel2; 

   
    [SerializeField] private AudioSource ascendingSound;
    [SerializeField] private AudioSource fishCatchSound; 

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

            switch (GameManager.Instance.tacLevel)
            {
                case 1:
                    break;
                case 2:
                    horizontalMovement *= 3;  
                    break;
                case 3:
                  
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
                canCatchFish = false;  
                PlayAscendingSound(); 
            }
        }
        else if (!isPaused)
        {
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
                    StopAscendingSound(); 
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
                canCatchFish = true;  
                fightBackCompleted = false; 
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
        if (canCatchFish && CurrentWeight < MaxWeight)  
        {
            if (col.CompareTag("Fish"))
            {
                FishMovement fish = col.gameObject.GetComponent<FishMovement>();
                if (fish != null)
                {
                    fish.isCatch = true;

                    fish.fishRigidbody.bodyType = RigidbodyType2D.Dynamic;

                    Vector3 hookPosition = transform.position;

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

                    HingeJoint2D hingeJoint = fish.gameObject.AddComponent<HingeJoint2D>();
                    hingeJoint.connectedBody = GetComponent<Rigidbody2D>();
                    hingeJoint.anchor = fish.mouthTransform.localPosition;

                    CurrentWeight += fish.weight;
                    totalValue += fish.value;
                    fishCount++;

                    PlayFishCatchSound(); 
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
                    InventoryManager.Instance.AddFish(fishMovement.fishso, fishMovement.value); 
                    fishImage.sprite = fishSpriteRenderer.sprite;
                }
            }
        }
    }

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

    private void PlayFishCatchSound()
    {
        if (fishCatchSound != null)
        {
            fishCatchSound.Play();
        }
    }
}
