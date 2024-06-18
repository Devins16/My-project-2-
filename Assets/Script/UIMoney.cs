using UnityEngine;
using TMPro;

public class UIMoney : MonoBehaviour
{
    public static UIMoney Instance;

    public TextMeshProUGUI moneyText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateMoneyText(float amount)
    {
        if (moneyText != null)
        {
            moneyText.text = $"Money: ${amount:F2}";
          
        }
        else
        {
            Debug.LogError("Money Text is not assigned in the Inspector");
        }
    }
}
