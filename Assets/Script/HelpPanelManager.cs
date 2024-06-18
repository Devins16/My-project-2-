using UnityEngine;
using UnityEngine.UI;

public class HelpPanelManager : MonoBehaviour
{
    public Button helpRodButton;
    public Button helpBaitButton;
    public Button helpTackleButton;
    public Button helpLineButton;
    public Button rodOkButton;
    public Button baitOkButton;
    public Button tackleOkButton;
    public Button lineOkButton;
    public GameObject rodInfoPanel;
    public GameObject baitInfoPanel;
    public GameObject tackleInfoPanel;
    public GameObject lineInfoPanel;

    private Button[] allButtons;

    void Start()
    {
        // Menambahkan listener untuk setiap tombol help
        helpRodButton.onClick.AddListener(() => ShowInfo("Rod"));
        helpBaitButton.onClick.AddListener(() => ShowInfo("Bait"));
        helpTackleButton.onClick.AddListener(() => ShowInfo("Tackle"));
        helpLineButton.onClick.AddListener(() => ShowInfo("Line"));

        // Menambahkan listener untuk tombol OK
        rodOkButton.onClick.AddListener(() => CloseInfoPanel("Rod"));
        baitOkButton.onClick.AddListener(() => CloseInfoPanel("Bait"));
        tackleOkButton.onClick.AddListener(() => CloseInfoPanel("Tackle"));
        lineOkButton.onClick.AddListener(() => CloseInfoPanel("Line"));

        // Menyembunyikan semua panel informasi saat mulai
        rodInfoPanel.SetActive(false);
        baitInfoPanel.SetActive(false);
        tackleInfoPanel.SetActive(false);
        lineInfoPanel.SetActive(false);

        // Mendapatkan semua tombol dalam scene
        allButtons = FindObjectsOfType<Button>();
    }

    void ShowInfo(string gear)
    {
        // Menampilkan panel informasi sesuai dengan gear yang dipilih
        switch (gear)
        {
            case "Rod":
                rodInfoPanel.SetActive(true);
                break;
            case "Bait":
                baitInfoPanel.SetActive(true);
                break;
            case "Tackle":
                tackleInfoPanel.SetActive(true);
                break;
            case "Line":
                lineInfoPanel.SetActive(true);
                break;
        }

        // Menonaktifkan semua tombol
        SetAllButtonsInteractable(false);
    }

    void CloseInfoPanel(string gear)
    {
        // Menyembunyikan panel informasi sesuai dengan gear yang dipilih
        switch (gear)
        {
            case "Rod":
                rodInfoPanel.SetActive(false);
                break;
            case "Bait":
                baitInfoPanel.SetActive(false);
                break;
            case "Tackle":
                tackleInfoPanel.SetActive(false);
                break;
            case "Line":
                lineInfoPanel.SetActive(false);
                break;
        }

        // Mengaktifkan kembali semua tombol
        SetAllButtonsInteractable(true);
    }

    void SetAllButtonsInteractable(bool state)
    {
        foreach (Button button in allButtons)
        {
            button.interactable = state;
        }
    }
}
