using UnityEngine;
using System.Collections;

public enum GUIButton
{
    MENU,
    RELOAD,
    NEXT,
    EXIT,
    RESUME,
    SOUND,
    OTHERGAMES,
    OTHER,
}

public class TouchGUI : MonoBehaviour
{
    public GUIButton type;

    private Texture buttonNormal;
    public Texture buttonHold;
    public bool sound = true;

    public int otherLevel;

    // sorteio
    public Texture2D[] icons;
    public string[] links;

    private System.Random random;
    private int indice;

    void Awake()
    {
        buttonNormal = this.guiTexture.texture;
        if (type == GUIButton.SOUND)
        {
            if(PlayerPrefs.GetString("Audio").Equals("Off")){
                sound = false;
                this.guiTexture.texture = buttonHold;
            }
        }

        if (type == GUIButton.OTHERGAMES)
        {
            random = new System.Random();
            indice = random.Next(icons.Length);

            this.guiTexture.texture = icons[indice];
            buttonNormal = this.guiTexture.texture;

        }
    }

    void Update()
    {
        // Remover isso daqui

        if (Input.GetKeyDown(KeyCode.M))
        {
            Application.LoadLevel("Menu");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("Level - " + Application.loadedLevel + " SavePoint", 0);
            Time.timeScale = 1;
            Application.LoadLevel(Application.loadedLevel);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            PlayerPrefs.SetInt("Level - " + int.Parse(Application.loadedLevel + 1 + "") + " SavePoint", 0);
            Application.LoadLevel(Application.loadedLevel + 1);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            var pauseMenu = GameObject.Find("Game");
            Time.timeScale = 1;
            var pauseGUI = GameObject.Find("Pause");
            pauseGUI.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (sound)
            {
                sound = false;
                this.guiTexture.texture = buttonHold;
                var camera = GameObject.Find("Main Camera").GetComponent<AudioSource>();
                PlayerPrefs.SetString("Audio", "Off");
                camera.mute = true;
            }
            else
            {
                sound = true;
                this.guiTexture.texture = buttonNormal;
                var camera = GameObject.Find("Main Camera").GetComponent<AudioSource>();
                PlayerPrefs.SetString("Audio", "On");
                camera.mute = false;
            }
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
                                Application.LoadLevel("Menu");
                            break;
                            case GUIButton.RELOAD:
                                PlayerPrefs.SetInt("Level - " + Application.loadedLevel + " SavePoint", 0);
                                Time.timeScale = 1;
                                Application.LoadLevel(Application.loadedLevel);
                            break;
                            case GUIButton.NEXT:
                                PlayerPrefs.SetInt("Level - " + int.Parse(Application.loadedLevel + 1 +"") + " SavePoint", 0);
                                Application.LoadLevel(Application.loadedLevel + 1);
                            break;
                            case GUIButton.EXIT:
                                Application.Quit();
                            break;
                            case GUIButton.RESUME:
                                var pauseMenu = GameObject.Find("Game");
                                Time.timeScale = 1;
                                var pauseGUI = GameObject.Find("Pause");
                                pauseGUI.SetActive(false);                              
                            break;
                            case GUIButton.SOUND:
                            if (sound)
                            {
                                sound = false;
                                this.guiTexture.texture = buttonHold;
                                var camera = GameObject.Find("Main Camera").GetComponent<AudioSource>();
                                PlayerPrefs.SetString("Audio", "Off");
                                camera.mute = true;
                            }
                            else
                            {
                                sound = true;
                                this.guiTexture.texture = buttonNormal;
                                var camera = GameObject.Find("Main Camera").GetComponent<AudioSource>();
                                PlayerPrefs.SetString("Audio", "On");
                                camera.mute = false;
                            }
                            break;
                            case GUIButton.OTHERGAMES:
                                Application.OpenURL(links[indice]);
                            break;                          
                            case GUIButton.OTHER:
                                Time.timeScale = 1;
                                Application.LoadLevel(otherLevel);
                            break;
                        }  
                        break;
                }
            }
            // se este toque não estiver colidindo, verifica quantos toque existe, se for menos de dois, troca a textura para o estador normal
            else if (Input.touchCount < 2 && type != GUIButton.SOUND)
            {
                this.guiTexture.texture = buttonNormal;                
            }
        }
    }
}
