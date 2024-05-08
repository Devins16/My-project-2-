using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    private bool fishingAllowed;
    private string sceneToLoad;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Spot>())
        {
            sceneToLoad = "Fishing";
            fishingAllowed = true;
        }
     
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Spot>())
        {
            fishingAllowed = false;
        }
    }

    private void Update()
    {
        if (fishingAllowed && Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}