using COMMANDS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TESTING
{
    public class CommandTesting : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Running());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                CommandManager.instance.Execute("moveChar", "left");
            if (Input.GetKeyDown(KeyCode.RightArrow))
                CommandManager.instance.Execute("moveChar", "right");
        }

        IEnumerator Running()
        {
            yield return CommandManager.instance.Execute("print");
            yield return CommandManager.instance.Execute("print_1p", "Helllo World!");
            yield return CommandManager.instance.Execute("print_mp", "line1", "line2", "line3");

            yield return CommandManager.instance.Execute("lambda");
            yield return CommandManager.instance.Execute("lambda_1p", "Helllo lambda!");
            yield return CommandManager.instance.Execute("lambda_mp", "lambda1", "lambda2", "lambda3");

            yield return CommandManager.instance.Execute("process");
            yield return CommandManager.instance.Execute("process_1p", "3");
            yield return CommandManager.instance.Execute("process_mp", "process line 1", "process line 2", "process line 3");
        }
    }
}