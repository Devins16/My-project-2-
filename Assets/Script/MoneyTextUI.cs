using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyTextUI : MonoBehaviour
{
    private TextMeshProUGUI moneyText;

    // Start is called before the first frame update
    void Start()
    {
        moneyText = GetComponent<TextMeshProUGUI>();
        UpdateMoneyText();
        GameManager.Instance.MoneyUpdate.AddListener(UpdateMoneyText);
    }
    private void OnDestroy()
    {
        GameManager.Instance.MoneyUpdate.RemoveListener(UpdateMoneyText);
    }

    void UpdateMoneyText()
    {
        if (moneyText != null)
        {
            moneyText.text = $"Money: ${GameManager.Instance.playerMoney:F2}";
            Debug.Log($"Money text updated: {moneyText.text}");
        }
        else
        {
            Debug.LogError("Money Text is not assigned in the Inspector");
        }
    }

    
}
