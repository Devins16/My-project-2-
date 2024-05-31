using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UnityEvent MoneyUpdate;

    public TextMeshProUGUI moneyText;
    public float playerMoney = 0f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // Tambahkan event listener untuk scene loaded
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    public void AddMoney(float amount)
    {
        playerMoney += amount;

        Debug.Log($"Money added: {amount}. Total money now: {playerMoney}");
        MoneyUpdate?.Invoke();
    }



    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"Scene '{scene.name}' loaded. Current money: {playerMoney}");

    }
}
