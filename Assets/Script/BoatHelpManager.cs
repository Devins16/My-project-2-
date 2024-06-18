using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoatHelpManager : MonoBehaviour
{
    public Button helpButton;   
    public Button okButton;     
    public GameObject helpPanel; 
    public TMP_Text helpText;   

    void Start()
    {
        
        helpButton.onClick.AddListener(ShowHelp);

       
        okButton.onClick.AddListener(CloseHelp);

       
        helpPanel.SetActive(false);
    }

    void ShowHelp()
    {
        
        helpPanel.SetActive(true);

        
        Time.timeScale = 0;
    }

    void CloseHelp()
    {
       
        helpPanel.SetActive(false);

       
        Time.timeScale = 1;
    }
}
