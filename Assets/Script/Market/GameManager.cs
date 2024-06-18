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

    public int rodLevel = 1; 
    public int lineLevel = 1; 
    public int baitLevel = 1; 
    public int boatLevel = 1; 
    public int tacLevel = 1;  

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
       
    }
}
