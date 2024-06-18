using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSfx : MonoBehaviour
{
    public AudioSource src;
    public AudioClip button,change;

    public void Button()
    {
        src.clip = button;
        src.Play();
    }

    public void ChangeScene()
    {
        src.clip = change;
        src.Play();
    }
}
