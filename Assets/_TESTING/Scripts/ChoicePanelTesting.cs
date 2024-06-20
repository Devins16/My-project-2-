using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TESTING
{
    public class ChoicePanelTesting : MonoBehaviour
    {
        ChoicePanel panel;
        // Start is called before the first frame update
        void Start()
        {
            panel = ChoicePanel.instance;
            StartCoroutine(Running());
        }

        IEnumerator Running()
        {
            string[] choices = new string[]
            {
            "Witness? Is that camera on?",
            "Oh, nah!",
            "I didn't see nothin'!",
            "Matta' Fact- I' I'm blind in my left eye and 43% blind in my right eye."
            };

            panel.Show("Did you witness anything strage?", choices);

            while (panel.isWaitingOnUserChoice)
                yield return null;

            var decision = panel.lastDecision;

            Debug.Log($"Made choice {decision.answerIndex} '{decision.choices[decision.answerIndex]}'");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}