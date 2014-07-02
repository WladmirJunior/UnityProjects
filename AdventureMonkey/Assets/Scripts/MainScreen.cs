using UnityEngine;
using System.Collections;

public class MainScreen : MonoBehaviour {

    public Texture splash;
    public GUIStyle font;

    public bool max = true;

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Application.LoadLevel("Selection");
        }

        if (max)
        {
            font.normal.textColor = new Color(font.normal.textColor.r - 0.01f, font.normal.textColor.g - 0.01f, font.normal.textColor.b - 0.01f, 255);
        }
        else
        {
            font.normal.textColor = new Color(font.normal.textColor.r + 0.01f, font.normal.textColor.g + 0.01f, font.normal.textColor.b + 0.01f, 255);
        }

        if (font.normal.textColor.r < 0.3921569F)
        {
            max = false;
        }
        else if (font.normal.textColor.r == 1)
        {
            max = true;
        }


    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), splash);

        GUI.Label(new Rect(Screen.width / 2, Screen.height * 0.75F, 50, 100), "Touch the screen to continue...", font);
    }
}
