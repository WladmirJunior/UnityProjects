using UnityEngine;
using System.Collections;

public class SelectionLevel : MonoBehaviour {

    public float widthButton;
    public float iniX, iniY;

    public Vector2 scrollPosition = Vector2.zero;

    void Update() // Change to Start()
    {
        widthButton = Screen.width * 0.2F;
        iniX = Screen.width * 0.06F;
        iniY = Screen.height * 0.1F;

    }

    void OnGUI()
    {
        scrollPosition = GUI.BeginScrollView(new Rect(iniX, iniY, Screen.width * 0.92F, Screen.height * 0.71F), scrollPosition, new Rect(iniX, iniY, Screen.width * 0.9F, Screen.height * 1.5F), new GUIStyle(), new GUIStyle());

        GUI.Button(new Rect(iniX, iniY, widthButton, widthButton), "1");
        GUI.Button(new Rect(iniX + (widthButton + Screen.width * 0.025F), iniY, widthButton, widthButton), "2");
        GUI.Button(new Rect(iniX + ((widthButton * 2) + Screen.width * 0.05F), iniY, widthButton, widthButton), "3");
        GUI.Button(new Rect(iniX + ((widthButton * 3) + Screen.width * 0.075F), iniY, widthButton, widthButton), "4");

        GUI.Button(new Rect(iniX, iniY + (widthButton + Screen.width * 0.025F), widthButton, widthButton), "5");
        GUI.Button(new Rect(iniX + (widthButton + Screen.width * 0.025F), iniY + (widthButton + Screen.width * 0.025F), widthButton, widthButton), "6");
        GUI.Button(new Rect(iniX + ((widthButton * 2) + Screen.width * 0.05F), iniY + (widthButton + Screen.width * 0.025F), widthButton, widthButton), "7");
        GUI.Button(new Rect(iniX + ((widthButton * 3) + Screen.width * 0.075F), iniY + (widthButton + Screen.width * 0.025F), widthButton, widthButton), "8");

        GUI.Button(new Rect(iniX, iniY + ((widthButton * 2) + Screen.width * 0.05F), widthButton, widthButton), "9");
        GUI.Button(new Rect(iniX + (widthButton + Screen.width * 0.025F), iniY + ((widthButton * 2) + Screen.width * 0.05F), widthButton, widthButton), "10");
        GUI.Button(new Rect(iniX + ((widthButton * 2) + Screen.width * 0.05F), iniY + ((widthButton * 2) + Screen.width * 0.05F), widthButton, widthButton), "11");
        GUI.Button(new Rect(iniX + ((widthButton * 3) + Screen.width * 0.075F), iniY + ((widthButton * 2) + Screen.width * 0.05F), widthButton, widthButton), "12");

        GUI.EndScrollView();
    }
}
