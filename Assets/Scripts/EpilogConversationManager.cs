using CHARACTERS;
using DIALOGUE;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EpilogConversationManager : MonoBehaviour
{
    private Character CreateCharacter(string name) => CharacterManager.instance.CreateCharacter(name);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Epilog());
    }

    IEnumerator Epilog()
    {
        AudioManager.Instance.StopMusic();

        Character_Sprite Arkan = CreateCharacter("Arkan") as Character_Sprite;

        GraphicPanel panel = GraphicPanelManager.instance.GetPanel("Background");
        GraphicLayer layer0 = panel.GetLayer(0, true);

        layer0.SetTexture("Graphics/BG Images/desk lamp");
        AudioManager1.instance.PlayTrack("Audio/Music/Ambience/scribbiling", loop: true, volumeCap: 0.7f);

        List<string> lines = new List<string>() 
        {
            "~a few years later~",
            "It's been a long time since I caught that legendary fish.",
            "just like grandfather said, it's quite difficult to catch that fish.",
            "I need to buy the best fishing rod that Mr. Joko can make. upgrade it to its perfect form.",
            "well, even though the story behind it wasn't pleasant, I managed to collect my money and buy the fishing rod.",
            "only then, I can catch that fish.",
            "Not only that. Dayana and the chief helped me take care of the problems that arose after I caught the legendary fish.",
            "After all, it is a legendary fish that has lived in this lake for a long time.",
            "the legend of it has been spreading for a long time.",
            "Because of that, I received a lot of attention from various media, especially from the angler community in the world.",
            "no one thought that the legend was true. {c}Anglers who have visited this place feel sad and disappointed because they could not be the first to catch the fish.",
            "Of course, because of my achievement of catching a legendary fish at the age of 13, I managed to get what I wanted.",
            "I was named a master angler by the world angler community, and my grandfather's name soared again.",
            "the news that I was the grandson of the legendary master angler spread everywhere.",
            "Many journalists came to me to interview me about my experience as the youngest master angler.",
            "Of course, my parents managed to overcome that problem.",
            "Later, I decided to hunt down other legendary fish in the world.",
            "I want to travel around the world to catch other rare fish species that are still hidden in other mystical places.",
            "Well, this is the end of my story.",
            "I hope that those of you who read this book will be interested in hearing my story again in my next book.",
            "After all, the story of Arkan the master angler is still not over.",
            "~fin~"
        };

        yield return Arkan.Say(lines);

        AudioManager1.instance.StopTrack(channel: 0);

        SceneManager.LoadScene("Main Menu");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
            DialogueSystem.instance.dialogueContainer.Hide();

        else if (Input.GetKeyDown(KeyCode.UpArrow))
            DialogueSystem.instance.dialogueContainer.Show();
    }
}
