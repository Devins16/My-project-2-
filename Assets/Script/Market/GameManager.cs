using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UnityEvent MoneyUpdate;

    public TextMeshProUGUI moneyText;
    public float playerMoney = 0f;

    public int rodLevel = 1; // Store the rod level
    public int lineLevel = 1; // Store the line level
    public int baitLevel = 1; // Store the bait level
    public int boatLevel = 1; // Store the boat level
    public int tacLevel = 1; // Store the tackle level

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateMoneyUI();
    }

    public void AddMoney(float amount)
    {
        playerMoney += amount;
        UpdateMoneyUI();
        Debug.Log($"Money added: {amount}. Total money now: {playerMoney}");
        MoneyUpdate?.Invoke();
    }

    public bool SpendMoney(float amount)
    {
        if (playerMoney >= amount)
        {
            playerMoney -= amount;
            UpdateMoneyUI();
            MoneyUpdate?.Invoke();
            return true;
        }
        else
        {
            Debug.Log("Not enough money to upgrade!");
            return false;
        }
    }

    void UpdateMoneyUI()
    {
        if (moneyText != null)
        {
            moneyText.text = $"Money: ${playerMoney}";
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"Scene '{scene.name}' loaded. Current money: {playerMoney}");
    }
}
