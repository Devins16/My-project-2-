using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
      

        if (scene.name == "Main Menu")
        {
            
            AudioManager.Instance.StopMusic();
        }
        else if (scene.name == "Map" || scene.name == "Dock" || scene.name == "Village" ||
                 scene.name == "gearupgrade" || scene.name == "boatupgrade" || scene.name == "market")
        {
           
            AudioManager.Instance.PlayMapMusic();
        }
        else if (scene.name == "Boating" || scene.name == "Fishing")
        {
            
            AudioManager.Instance.PlayBoatingMusic();
        }
    }

}
