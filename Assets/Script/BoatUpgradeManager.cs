using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BoatUpgradeManager : MonoBehaviour
{
    public Button upgradeBoatButton;
    public TextMeshProUGUI boatLevelText;
    public TextMeshProUGUI boatUpgradeCostText;
    public Image boatImage;

    public Sprite normalBoatSprite;
    public Sprite superBoatSprite;
    public Sprite rareBoatSprite;
    public Sprite legendaryBoatSprite;

    private int[] upgradeCosts = { 0, 0, 10, 20, 30, 40 };

    void Start()
    {
        upgradeBoatButton.onClick.AddListener(UpgradeBoat);
        UpdateUI();
    }

    void UpgradeBoat()
    {
        if (GameManager.Instance.boatLevel < 4 && GameManager.Instance.SpendMoney(upgradeCosts[GameManager.Instance.boatLevel + 1]))
        {
            GameManager.Instance.boatLevel++;
            UpdateUI();
            UpdateBoatSpriteInScene(); // Update the boat sprite in the boating scene
        }
    }

    void UpdateUI()
    {
        boatLevelText.text = $"Boat Level: {GameManager.Instance.boatLevel}";

        if (GameManager.Instance.boatLevel < 4)
        {
            boatUpgradeCostText.text = $"Upgrade Cost: ${upgradeCosts[GameManager.Instance.boatLevel + 1]}";
        }
        else
        {
            boatUpgradeCostText.text = "Max Level";
        }

        switch (GameManager.Instance.boatLevel)
        {
            case 1:
                boatImage.sprite = normalBoatSprite;
                break;
            case 2:
                boatImage.sprite = superBoatSprite;
                break;
            case 3:
                boatImage.sprite = rareBoatSprite;
                break;
            case 4:
                boatImage.sprite = legendaryBoatSprite;
                break;
        }
    }

    void UpdateBoatSpriteInScene()
    {
        // Find the boat in the boating scene and update its sprite
        CharacterControl boat = FindObjectOfType<CharacterControl>();
        if (boat != null)
        {
            boat.UpdateBoatAttributes();
        }
    }
}
