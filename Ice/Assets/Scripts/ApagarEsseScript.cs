using UnityEngine;
using System.Collections;

public class ApagarEsseScript : MonoBehaviour {

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Time.timeScale = 1;
            Application.LoadLevel(2);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Application.LoadLevel("Shop");
        }
    }
}
