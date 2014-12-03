using UnityEngine;
using System.Collections;

public class BackPress : MonoBehaviour {

	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Application.loadedLevelName == "Shop")
            {
                Application.LoadLevel("Menu");
            }
            else if (Application.loadedLevelName == "Menu") 
            {
                Application.Quit();
            }
        }
	}
}
