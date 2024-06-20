using CHARACTERS;
using DIALOGUE;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicLayerTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RunningLayers());
    }

    IEnumerator Running()
    {
        //GraphicPanelManager.instance.GetPanel("Background").GetLayer(0, true);

        GraphicPanel panel = GraphicPanelManager.instance.GetPanel("Background");
        GraphicLayer layer = panel.GetLayer(0, true);

        yield return new WaitForSeconds(1);

        Texture blendTex = Resources.Load<Texture>("Graphics/Transition Effects/hurricane");
        layer.SetTexture("Graphics/BG Images/2", blendingTexture: blendTex);

        yield return new WaitForSeconds(1);

        layer.SetVideo("Graphics/BG Videos/Fantasy Landscape", blendingTexture: blendTex);

        yield return new WaitForSeconds(3);

        layer.currentGraphic.FadeOut();

        yield return new WaitForSeconds(2);

        Debug.Log(layer.currentGraphic);

        //layer.SetVideo("Graphics/BG Videos/Fantasy Landscape", transitionSpeed: 0.01f, useAudio: true);

        //layer.currentGraphic.renderer.material.SetColor("_Color", Color.red);
    }

    IEnumerator RunningLayers()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
            DialogueSystem.instance.dialogueContainer.Hide();

        else if (Input.GetKeyDown(KeyCode.UpArrow))
            DialogueSystem.instance.dialogueContainer.Show();

        GraphicPanel panel = GraphicPanelManager.instance.GetPanel("Background");
        GraphicLayer layer0 = panel.GetLayer(0, true);
        GraphicLayer layer1 = panel.GetLayer(1, true);

        layer0.SetVideo("Graphics/BG Videos/Nebula");
        layer1.SetTexture("Graphics/BG Images/Spaceshipinterior");

        yield return new WaitForSeconds(2);

        GraphicPanel cinematic = GraphicPanelManager.instance.GetPanel("Cinematic");
        GraphicLayer cinLayer = cinematic.GetLayer(0, true);

        Character Dayana = CharacterManager.instance.CreateCharacter("Dayana", true);

        yield return Dayana.Say("cinematic layer.");

        cinLayer.SetTexture("Graphics/Gallery/pup");

        yield return DialogueSystem.instance.Say("Narrator", "cinematic layer showing dog.");

        yield return new WaitForSeconds(1);

        yield return DialogueSystem.instance.Say("Narrator", "then clear cinematic layer.");

        yield return new WaitForSeconds(1);

        cinLayer.Clear();

        yield return DialogueSystem.instance.Say("Narrator", "then clear all active panel.");

        yield return new WaitForSeconds(1);

        panel.Clear();
    }
}
