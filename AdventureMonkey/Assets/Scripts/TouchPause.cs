using UnityEngine;
using System.Collections;

public class TouchPause : MonoBehaviour {

    private Texture buttonNormal;
    public Texture buttonHold;

	void Start () {
        buttonNormal = this.guiTexture.texture;
	}
	
	// Update is called once per frame
	void Update () {
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
                        Time.timeScale = 0;
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
