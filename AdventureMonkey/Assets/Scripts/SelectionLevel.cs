using UnityEngine;
using System.Collections;

public class SelectionLevel : MonoBehaviour
{

    public float widthButton;
    public float iniX, iniY;

    public Texture star;

    Vector2 scrollPosition = Vector2.zero;


    void Start()
    {
        PlayerPrefs.SetInt("LevelUnlock - 1", 1);
    }

    void Update() // Change to Start()
    {
        widthButton = Screen.width * 0.2F;
        iniX = Screen.width * 0.06F;
        iniY = Screen.height * 0.05F;

    }

    void OnGUI()
    {
        scrollPosition = GUI.BeginScrollView(new Rect(iniX, iniY, Screen.width * 0.92F, Screen.height * 0.75F), scrollPosition, new Rect(iniX, iniY, Screen.width * 0.9F, Screen.height * 1.5F), new GUIStyle(), new GUIStyle());
        //scrollPosition = GUI.BeginScrollView(new Rect(iniX, iniY, Screen.width * 0.92F, Screen.height * 0.75F), scrollPosition, new Rect(iniX, iniY, Screen.width * 0.9F, Screen.height * 1.5F));

        int count = 1;
        float w = 0F;
        float h = 0F;

        float sunW, sunH;

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (j == 0)
                {
                    sunW = 0;
                }
                else
                {
                    sunW = (widthButton * j + Screen.width * w);
                }

                if (i == 0)
                {
                    sunH = 0;
                }
                else
                {
                    sunH = (widthButton * i + Screen.width * h);
                }                                      

                if (PlayerPrefs.GetInt("LevelUnlock - " + count) == 1)
                {                 
                    if (GUI.Button(new Rect(iniX + sunW, iniY + sunH, widthButton, widthButton), "" + count)) { Application.LoadLevel(count); }
                }
                else
                {
                    GUI.Button(new Rect(iniX + sunW, iniY + sunH, widthButton, widthButton), "X");
                }

                int n = PlayerPrefs.GetInt("StarsLevel - "+count);

                // Stars of level complete

                for (int l = 0; l < n; l++)
                {
                    GUI.DrawTexture(new Rect(iniX + sunW + (widthButton * 0.3F) * l + widthButton * 0.05f, iniY + sunH + widthButton * 0.65F, widthButton * 0.3F, widthButton * 0.3F), star);
                }     
                
                w += 0.025F;
                count++;
            }
            w = 0F;
            h += 0.025F;
        }

            //if (GUI.Button(new Rect(iniX, iniY, widthButton, widthButton), "1")) { Application.LoadLevel(1); }
            //GUI.Button(new Rect(iniX + (widthButton + Screen.width * 0.025F), iniY, widthButton, widthButton), "2");
            //GUI.Button(new Rect(iniX + ((widthButton * 2) + Screen.width * 0.05F), iniY, widthButton, widthButton), "3");
            //GUI.Button(new Rect(iniX + ((widthButton * 3) + Screen.width * 0.075F), iniY, widthButton, widthButton), "4");

            //GUI.Button(new Rect(iniX, iniY + (widthButton + Screen.width * 0.025F), widthButton, widthButton), "5");
            //GUI.Button(new Rect(iniX + (widthButton + Screen.width * 0.025F), iniY + (widthButton + Screen.width * 0.025F), widthButton, widthButton), "6");
            //GUI.Button(new Rect(iniX + ((widthButton * 2) + Screen.width * 0.05F), iniY + (widthButton + Screen.width * 0.025F), widthButton, widthButton), "7");
            //GUI.Button(new Rect(iniX + ((widthButton * 3) + Screen.width * 0.075F), iniY + (widthButton + Screen.width * 0.025F), widthButton, widthButton), "8");

            //GUI.Button(new Rect(iniX, iniY + ((widthButton * 2) + Screen.width * 0.05F), widthButton, widthButton), "9");
            //GUI.Button(new Rect(iniX + (widthButton + Screen.width * 0.025F), iniY + ((widthButton * 2) + Screen.width * 0.05F), widthButton, widthButton), "10");
            //GUI.Button(new Rect(iniX + ((widthButton * 2) + Screen.width * 0.05F), iniY + ((widthButton * 2) + Screen.width * 0.05F), widthButton, widthButton), "11");
            //GUI.Button(new Rect(iniX + ((widthButton * 3) + Screen.width * 0.075F), iniY + ((widthButton * 2) + Screen.width * 0.05F), widthButton, widthButton), "12");

            //GUI.Button(new Rect(iniX, iniY + ((widthButton * 3) + Screen.width * 0.075F), widthButton, widthButton), "13");
            //GUI.Button(new Rect(iniX + (widthButton + Screen.width * 0.025F), iniY + ((widthButton * 3) + Screen.width * 0.075F), widthButton, widthButton), "14");
            //GUI.Button(new Rect(iniX + ((widthButton * 2) + Screen.width * 0.05F), iniY + ((widthButton * 3) + Screen.width * 0.075F), widthButton, widthButton), "15");
            //GUI.Button(new Rect(iniX + ((widthButton * 3) + Screen.width * 0.075F), iniY + ((widthButton * 3) + Screen.width * 0.075F), widthButton, widthButton), "16");

            GUI.EndScrollView();

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            scrollPosition.y += Input.GetTouch(0).deltaPosition.y;
        }
    }
}
