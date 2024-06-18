using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapInteraction : MonoBehaviour
{
    public AudioSource src;
    public AudioClip buttonClip;
    public float delayBeforeSceneChange = 1f; // Adjust this delay based on your SFX length

    public void GoToBoatingScene()
    {
        StartCoroutine(PlaySFXAndChangeScene("Boating"));
    }

    public void GoToMarketScene()
    {
        StartCoroutine(PlaySFXAndChangeScene("Market"));
    }

    public void GoToMapScene()
    {
        StartCoroutine(PlaySFXAndChangeScene("Map"));
    }

    public void GoToUpgradeScene()
    {
        StartCoroutine(PlaySFXAndChangeScene("Upgrade"));
    }

    public void GoToBoatScene()
    {
        StartCoroutine(PlaySFXAndChangeScene("BoatUpgrade"));
    }

    public void GoToDockScene()
    {
        StartCoroutine(PlaySFXAndChangeScene("Dock"));
    }

    public void GoToVillageScene()
    {
        StartCoroutine(PlaySFXAndChangeScene("Village"));
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
