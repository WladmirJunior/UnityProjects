using UnityEngine;
using System.Collections;

public enum GUIButton
{
    MENU,
    RELOAD,
    NEXT,
    EXIT,
    OTHER,
}

public class TouchGUI : MonoBehaviour
{
    public GUIButton type;

    private Texture buttonNormal;
    public Texture buttonHold;

    public int otherLevel;

    void Awake()
    {
        buttonNormal = this.guiTexture.texture;
    }

    void Update()
    {
        // Remover isso daqui

        if (Input.GetKeyDown(KeyCode.M))
        {
            Application.LoadLevel("Selection");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("Level - " + Application.loadedLevel + " SavePoint", 0);
            Application.LoadLevel(Application.loadedLevel);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            PlayerPrefs.SetInt("Level - " + int.Parse(Application.loadedLevel + 1 + "") + " SavePoint", 0);
            Application.LoadLevel(Application.loadedLevel + 1);
        }

        //


        // Este for percorre o array que armazena todos os toque do usuario na tela
        for (int i = 0; i < Input.touches.Length; i++)
        {
            Touch touch = Input.touches[i];

            // verifica se o toque atual do usuario esta colidindo com o guiTexture deste botao
            if (this.guiTexture.HitTest(Input.GetTouch(i).position))
            {

                switch (touch.phase)
                {

                    case TouchPhase.Stationary:

                        this.guiTexture.texture = buttonHold;
                        break;

                    case TouchPhase.Began:

                        this.guiTexture.texture = buttonHold;
                        break;

                    case TouchPhase.Ended:

                        this.guiTexture.texture = buttonNormal;

                        switch (type)
                        {
                            case GUIButton.MENU:
                                Application.LoadLevel("Selection");
                            break;
                            case GUIButton.RELOAD:
                                PlayerPrefs.SetInt("Level - " + Application.loadedLevel + " SavePoint", 0);
                                Application.LoadLevel(Application.loadedLevel);
                            break;
                            case GUIButton.NEXT:
                                PlayerPrefs.SetInt("Level - " + int.Parse(Application.loadedLevel + 1 +"") + " SavePoint", 0);
                                Application.LoadLevel(Application.loadedLevel + 1);
                            break;
                            case GUIButton.EXIT:
                            Application.Quit();
                            break;
                            case GUIButton.OTHER:
                                Application.LoadLevel(otherLevel);
                            break;
                        }  
                        break;
                }
            }
            // se este toque não estuver colidindo, verifica quantos toque existe, se for menos de dois, troca a textura para o estador normal
            else if (Input.touchCount < 2)
            {
                this.guiTexture.texture = buttonNormal;                
            }
        }
    }
}
