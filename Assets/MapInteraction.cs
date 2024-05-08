using UnityEngine;
using UnityEngine.SceneManagement;

public class MapInteraction : MonoBehaviour
{
   
    public void GoToBoatingScene()
    {
        SceneManager.LoadScene("Boating"); 
    }

  
    public void GoToUpgradeScene()
    {
        SceneManager.LoadScene("UpgradeScene"); 
    }
}
