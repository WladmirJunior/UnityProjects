using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    public bool pauseActive;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseActive)
            {
                Application.LoadLevel("Selection");
            }

            if (Application.loadedLevelName.Equals("Selection"))
            {
                // MenssageBox para confirmar a saida do jogo
                Application.Quit();
            }

            if (!Application.loadedLevelName.Equals("Selection"))
            {
                pauseActive = true;
            }
        }
    }
}
