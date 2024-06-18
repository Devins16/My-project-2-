using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GearUpgradeManager : MonoBehaviour
{
    public Button upgradeRodButton;
    public Button upgradeLineButton;
    public Button upgradeBaitButton;
    public Button upgradeTacButton;  
    public TextMeshProUGUI rodLevelText;
    public TextMeshProUGUI lineLevelText;
    public TextMeshProUGUI baitLevelText;
    public TextMeshProUGUI tacLevelText;  
    public TextMeshProUGUI rodUpgradeCostText;
    public TextMeshProUGUI lineUpgradeCostText;
    public TextMeshProUGUI baitUpgradeCostText;
    public TextMeshProUGUI tacUpgradeCostText;  

    public GameObject upgradeSuccessPanel;
    public GameObject notEnoughMoneyPanel;
    public Button successPanelOkButton;
    public Button notEnoughMoneyOkButton;

    public Image rodImage;
    public Image lineImage;
    public Image baitImage;
    public Image tacImage; 

    public Sprite[] rodSprites;
    public Sprite[] lineSprites;
    public Sprite[] baitSprites;
    public Sprite[] tacSprites; 

    private int[] upgradeCosts = { 0, 20, 50, 100, 250 };
    private int[] maxWeights = { 0, 1000, 2000, 3000, 5000 };
    private float[] maxDepths = { 0f, 50f, 200f, 400f, 508f };

    void Start()
    {
        upgradeRodButton.onClick.AddListener(UpgradeRod);
        upgradeLineButton.onClick.AddListener(UpgradeLine);
        upgradeBaitButton.onClick.AddListener(UpgradeBait);
        upgradeTacButton.onClick.AddListener(UpgradeTac);  

        successPanelOkButton.onClick.AddListener(HideSuccessPanel);
        notEnoughMoneyOkButton.onClick.AddListener(HideNotEnoughMoneyPanel);

        UpdateUI();
    }

    void UpgradeRod()
    {
        if (GameManager.Instance.rodLevel < 4 && GameManager.Instance.SpendMoney(upgradeCosts[GameManager.Instance.rodLevel + 1]))
        {
            GameManager.Instance.rodLevel++;
            HookController.instance.MaxWeight = maxWeights[GameManager.Instance.rodLevel];
            ShowSuccessPanel();
            UpdateUI();
        }
        else
        {
            ShowNotEnoughMoneyPanel();
        }
    }

    void UpgradeLine()
    {
        if (GameManager.Instance.lineLevel < 4 && GameManager.Instance.SpendMoney(upgradeCosts[GameManager.Instance.lineLevel + 1]))
        {
            GameManager.Instance.lineLevel++;
            HookController.instance.descendDistance = maxDepths[GameManager.Instance.lineLevel];
            ShowSuccessPanel();
            UpdateUI();
        }
        else
        {
            ShowNotEnoughMoneyPanel();
        }
    }

    void UpgradeBait()
    {
        if (GameManager.Instance.baitLevel < 4 && GameManager.Instance.SpendMoney(upgradeCosts[GameManager.Instance.baitLevel + 1]))
        {
            GameManager.Instance.baitLevel++;
            ShowSuccessPanel();
            UpdateUI();
        }
        else
        {
            ShowNotEnoughMoneyPanel();
        }
    }

    void UpgradeTac()
    {
        if (GameManager.Instance.tacLevel < 4 && GameManager.Instance.SpendMoney(upgradeCosts[GameManager.Instance.tacLevel + 1]))
        {
            GameManager.Instance.tacLevel++;
            ShowSuccessPanel();
            UpdateUI();
        }
        else
        {
            ShowNotEnoughMoneyPanel();
        }
    }

    void UpdateUI()
    {
        rodLevelText.text = $"Rod Level: {GameManager.Instance.rodLevel}";
        lineLevelText.text = $"Line Level: {GameManager.Instance.lineLevel}";
        baitLevelText.text = $"Bait Level: {GameManager.Instance.baitLevel}";
        tacLevelText.text = $"Tackle Level: {GameManager.Instance.tacLevel}";  

        rodImage.sprite = rodSprites[GameManager.Instance.rodLevel];
        lineImage.sprite = lineSprites[GameManager.Instance.lineLevel];
        baitImage.sprite = baitSprites[GameManager.Instance.baitLevel];
        tacImage.sprite = tacSprites[GameManager.Instance.tacLevel];  

        if (GameManager.Instance.rodLevel < 4)
        {
            rodUpgradeCostText.text = $"Upgrade Cost: ${upgradeCosts[GameManager.Instance.rodLevel + 1]}";
        }
        else
        {
            rodUpgradeCostText.text = "Max Level";
        }

        if (GameManager.Instance.lineLevel < 4)
        {
            lineUpgradeCostText.text = $"Upgrade Cost: ${upgradeCosts[GameManager.Instance.lineLevel + 1]}";
        }
        else
        {
            lineUpgradeCostText.text = "Max Level";
        }

        if (GameManager.Instance.baitLevel < 4)
        {
            baitUpgradeCostText.text = $"Upgrade Cost: ${upgradeCosts[GameManager.Instance.baitLevel + 1]}";
        }
        else
        {
            baitUpgradeCostText.text = "Max Level";
        }

        if (GameManager.Instance.tacLevel < 4)
        {
            tacUpgradeCostText.text = $"Upgrade Cost: ${upgradeCosts[GameManager.Instance.tacLevel + 1]}";
        }
        else
        {
            tacUpgradeCostText.text = "Max Level";
        }
    }

    void ShowSuccessPanel()
    {
        upgradeSuccessPanel.SetActive(true);
    }

    void HideSuccessPanel()
    {
        upgradeSuccessPanel.SetActive(false);
    }

    void ShowNotEnoughMoneyPanel()
    {
        notEnoughMoneyPanel.SetActive(true);
    }

    void HideNotEnoughMoneyPanel()
    {
        notEnoughMoneyPanel.SetActive(false);
    }
}
