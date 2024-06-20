using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CHARACTERS;
using DIALOGUE;
using TMPro;

namespace TESTING
{
    public class TestCharacters : MonoBehaviour
    {
        public TMP_FontAsset tempFont;

        private Character CreateCharacter(string name) => CharacterManager.instance.CreateCharacter(name);

        // Start is called before the first frame update
        void Start()
        {

            StartCoroutine(Test2());
        }

        IEnumerator Test()
        {
            //Character_Sprite Girl = CreateCharacter("Girl as Dayana") as Character_Sprite;
            //Character_Sprite GirlRed = CreateCharacter("Girl Red as Dayana") as Character_Sprite;
            Character_Sprite Arkan = CreateCharacter("Arkan") as Character_Sprite;
            Character_Sprite Dayana = CreateCharacter("Dayana") as Character_Sprite;
            //Dayana.isVisible = false;

            Arkan.SetPosition(new Vector2(0, 0));
            Dayana.SetPosition(new Vector2(1, 0));

            yield return new WaitForSeconds(1);

            Dayana.TransitionSprite(Dayana.GetSprite("02 smile"));
            Dayana.Animate("Hop");
            yield return Dayana.Say("Where did this wind chill come from?");

            Arkan.FaceRight();
            Arkan.TransitionSprite(Arkan.GetSprite("01"));
            Arkan.TransitionSprite(Arkan.GetSprite("01 02 oh"), layer: 1);
            Arkan.MoveToPosition(new Vector2(0.1f, 0));
            Arkan.Animate("Shiver", true);
            yield return Arkan.Say("I don't know - but I hate it!{a} It's freezing!");

            yield return Dayana.Say("Oh, it's over!");

            Arkan.TransitionSprite(Arkan.GetSprite("02"));
            Arkan.TransitionSprite(Arkan.GetSprite("01 02 small smile"), layer: 1);
            Arkan.Animate("Shiver", false);
            yield return Arkan.Say("Thank the lord...{a} I'm not wearing enough clothes for that crap.");

            yield return null;

        }

        IEnumerator Test2()
        {
            Character Ibu = CreateCharacter("Ibu as Mother");

            yield return Ibu.Say("Normal dialogue configuration,");

            Ibu.SetDialogueColor(Color.red);
            Ibu.SetNameColor(Color.blue);

            yield return Ibu.Say("Customized dialogue here.");

            Ibu.ResetConfigurationData();

            yield return Ibu.Say("I should be back to normal.");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}