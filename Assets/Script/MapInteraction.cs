using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapInteraction : MonoBehaviour
{
    public AudioSource src;
    public AudioClip buttonClip;
    public float delayBeforeSceneChange = 1f; 

    public void GoToBoatingScene()
    {
        StartCoroutine(PlaySFXAndChangeScene("Boating"));
    }

    public void GoToSellFishScene()
    {
        StartCoroutine(PlaySFXAndChangeScene("SellFish"));
    }

    public void GoToMapScene()
    {
        StartCoroutine(PlaySFXAndChangeScene("Map"));
    }

    public void GoToUpgradeGearScene()
    {
        StartCoroutine(PlaySFXAndChangeScene("UpgradeGear"));
    }

    public void GoToBoatUpgradeScene()
    {
        StartCoroutine(PlaySFXAndChangeScene("BoatUpgrade"));
    }

    public void GoToDockScene()
    {
        StartCoroutine(PlaySFXAndChangeScene("Dock"));
    }

    public void GoToMamanHutScene()
    {
        StartCoroutine(PlaySFXAndChangeScene("MamanHut"));
    }

    public void GoToMarketScene()
    {
        StartCoroutine(PlaySFXAndChangeScene("Market"));
    }

    public void GoToJokoShopScene()
    {
        StartCoroutine(PlaySFXAndChangeScene("JokoShop"));
    }

    public void GoToAuntShopScene()
    {
        StartCoroutine(PlaySFXAndChangeScene("AuntShop"));
    }

    public void GoToPrologueScene()
    {
        SceneManager.LoadScene("Prologue");
    }

    public void QuitApplication()
    {
        StartCoroutine(PlaySFXAndQuit());
    }

    private IEnumerator PlaySFXAndChangeScene(string sceneName)
    {
        src.clip = buttonClip;
        src.Play();
        yield return new WaitForSeconds(delayBeforeSceneChange);
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator PlaySFXAndQuit()
    {
        src.clip = buttonClip;
        src.Play();
        yield return new WaitForSeconds(delayBeforeSceneChange);
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
