using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIALOGUE;

namespace TESTING
{
    public class Testing_Architect : MonoBehaviour
    {
        DialogueSystem ds;
        TextArchitect architect;

        public TextArchitect.BuildMethod bm = TextArchitect.BuildMethod.fade;

        string[] lines = new string[5]
        {
            "this is a random line of dialogue.",
            "rise of into my world.",
            "renew your definition.",
            "world so high.",
            "baby show~"
        };

        // Start is called before the first frame update
        void Start()
        {
            ds = DialogueSystem.instance;
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            architect.buildMethod = TextArchitect.BuildMethod.fade;
            //architect.speed = 0.5f;
        }

        // Update is called once per frame
        void Update()
        {
            if (bm != architect.buildMethod)
            {
                architect.buildMethod = bm;
                architect.Stop();
            }

            if (Input.GetKeyDown(KeyCode.S))
                architect.Stop();

            string longline = "Furina my love, furina my god, furina my beloved, furina furina furina furina furina furina furina furina furina furina";
            // Press space key to build the line. Press once to let the text shows up in natural speed. Press twice to speed up. Press trice to finish it. 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (architect.isBuilding)
                {
                    if (!architect.hurryUp)
                        architect.hurryUp = true;
                    else
                        architect.ForceComplete();
                }
                else
                    architect.Build(longline);
                    //architect.Build(lines[Random.Range(0, lines.Length)]);
            }

            // Press A key to append the text. A bit buggy
            else if (Input.GetKeyDown(KeyCode.A))
            {
                architect.Append(longline);
                //architect.Append(lines[Random.Range(0, lines.Length)]);
            }
        }
    }
}

