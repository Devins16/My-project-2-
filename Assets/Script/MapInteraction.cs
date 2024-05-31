using UnityEngine;
using UnityEngine.SceneManagement;

public class MapInteraction : MonoBehaviour
{
   
    public void GoToBoatingScene()
    {
        SceneManager.LoadScene("Boating"); 
    }

    public void GoToMarketScene()
    {
        SceneManager.LoadScene("Market");
    }

    public void GoToMapScene()
    {
        SceneManager.LoadScene("Map");
    }
    public void GoToUpgradeScene()
    {
        SceneManager.LoadScene("Upgrade");
    }
    public void GoToBoatScene()
    {
        SceneManager.LoadScene("Boat");
    }
}
