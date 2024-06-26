using DIALOGUE;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TESTING
{
    public class TestDialogueFiles : MonoBehaviour
    {
        [SerializeField] private TextAsset file;

        // Start is called before the first frame update
        void Start()
        {
            StartConversation();
        }

        void StartConversation()
        {
            List<string> lines = FileManager.ReadTextAsset(file);

            //foreach (string line in lines)
            //{
            //    if (string.IsNullOrEmpty(line)) 
            //        continue;

            //    DIALOGUE_LINE dl = DialogueParser.Parse(line);

            //    for (int i = 0; i < dl.commandData.commands.Count; i++)
            //    {
            //        DL_COMMAND_DATA.Command command = dl.commandData.commands[i];
            //        Debug.Log($"Command [{i}] '{command.name}' has arguments [{string.Join(", ", command.arguments)}]");
            //    }
            //}

            DialogueSystem.instance.Say(lines);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
                DialogueSystem.instance.dialogueContainer.Hide();

            else if (Input.GetKeyDown(KeyCode.UpArrow))
                DialogueSystem.instance.dialogueContainer.Show();
        }
    }
}