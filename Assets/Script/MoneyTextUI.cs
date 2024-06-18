using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyTextUI : MonoBehaviour
{
    private TextMeshProUGUI moneyText;

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
          
        }
     
    }

    
}
