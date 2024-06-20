using CHARACTERS;
using DIALOGUE;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Running3());
    }

    Character CreateCharacter(string name) => CharacterManager.instance.CreateCharacter(name);

    IEnumerator Running()
    {
        Character_Sprite Dayana = CreateCharacter("Dayana") as Character_Sprite;
        Character Me = CreateCharacter("Me");
        Dayana.Show();

        //yield return new WaitForSeconds(0.5f);

        AudioManager1.instance.PlaySoundEffect("Audio/SFX/RadioStatic", loop: true);

        yield return Me.Say("Please turn off the radio.");

        AudioManager1.instance.StopSoundEffect("RadioStatic");
        AudioManager1.instance.PlayVoice("Audio/Voices/exclamation");

        Dayana.Say("Okay!");

        //AudioManager.instance.PlaySoundEffect("Audio/SFX/thunder_strong_01");

        //yield return new WaitForSeconds(1f);
        //Dayana.Animate("Hop");
        //Dayana.TransitionSprite(Dayana.GetSprite("Dayanaa-02"));
        //Dayana.TransitionSprite(Dayana.GetSprite("Dayanaa-02 sad"), 1);
        //Dayana.Say("Yikes!");
    }

    IEnumerator Running2()
    {
        //AudioChannel channel = new AudioChannel(1);

        yield return new WaitForSeconds(1);

        Character_Sprite Dayana = CreateCharacter("Dayana") as Character_Sprite;

        Dayana.Show();

        yield return DialogueSystem.instance.Say("Narrator", "Can we see your ship?");

        GraphicPanelManager.instance.GetPanel("background").GetLayer(0, true).SetTexture("Graphics/BG Images/market");
        AudioManager1.instance.PlayTrack("Audio/Music/Backsound Awal/peritune village", volumeCap: 0.5f);
        AudioManager1.instance.PlayVoice("Audio/Voices/exclamation");

        Dayana.SetSprite(Dayana.GetSprite("Dayanaa-01"), 0);
        Dayana.SetSprite(Dayana.GetSprite("Dayanaa-01 sad"), 1);
        Dayana.MoveToPosition(new Vector2(0.7f, 0), speed: 0.5f);
        yield return Dayana.Say("Yes, of course!");

        yield return Dayana.Say("let me show you the engine room.");

        GraphicPanelManager.instance.GetPanel("background").GetLayer(0, true).SetTexture("Graphics/BG Images/scene bayangan arkan dan sang kakek");
        AudioManager1.instance.PlayTrack("Audio/Music/Visual Novel/mysterious lights", volumeCap: 0.8f);

        yield return null;
    }

    IEnumerator Running3()
    {
        Character_Sprite Dayana = CreateCharacter("Dayana") as Character_Sprite;
        Character Me = CreateCharacter("Me");
        Dayana.Show();

        GraphicPanelManager.instance.GetPanel("background").GetLayer(0, true).SetTexture("Graphics/BG Images/scene bayangan arkan dan sang kakek");
        AudioManager1.instance.PlayTrack("Audio/Ambience/RainyMood", 0);
        AudioManager1.instance.PlayTrack("Audio/Music/Calm", 1, pitch: 0.7f);

        yield return Dayana.Say("We can have multiple channels for playing ambience as well as music!");

        AudioManager1.instance.StopTrack(1);
    }
}
