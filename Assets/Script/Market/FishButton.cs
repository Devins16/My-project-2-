using UnityEngine;
using UnityEngine.UI;

public class FishButton : MonoBehaviour
{
    public Image fishIcon;
    public Button button;
    private FishData fishData;

  
    public FishData Fish => fishData;

    public void Initialize(FishData data, System.Action<FishData> onClick)
    {
        fishData = data;
        fishIcon.sprite = data.Fish.fishIcon;
        button.onClick.AddListener(() => onClick(fishData));
    }
}
