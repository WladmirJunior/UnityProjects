﻿using UnityEngine;
using System.Collections;

public enum ButtonFunction
{
    BACK,
    FORWAD,
}

public class TouchButton : MonoBehaviour {

    private Texture buttonNormal;
    public Texture buttonHold;

    public Player controllerPlayer;
    public float deltaAxis;

    //public Motion motionState = Motion.IDLE;
    public ButtonFunction functionSelected = ButtonFunction.BACK;

    void Start()
    {
        buttonNormal = this.guiTexture.texture;
        controllerPlayer = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (controllerPlayer.endGame)
        {
            this.gameObject.GetComponent<GUITexture>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<GUITexture>().enabled = true;
        }

        if (Input.touchCount == 0)
        {
            controllerPlayer.Motion = 0;
        }

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

                        switch (functionSelected)
                        {
                            case ButtonFunction.BACK:
                                MoveController(-1);
                                break;
                            case ButtonFunction.FORWAD:
                                MoveController(1);
                                break;
                        }

                        break;
                    case TouchPhase.Ended:
                        this.guiTexture.texture = buttonNormal;

                        EndController();

                        break;
                }
            }
            // se este toque não estuver colidindo, verifica quantos toque existe, se for menos de dois, troca a textura para o estador normal
            else if(Input.touchCount < 2)
            {
                this.guiTexture.texture = buttonNormal;
                EndController();
            }
        }
    }

    /// <summary>
    /// Depois que a interação do usuário acabar, é terminado o movimento do personagem se necessário (o pulo é finalizado automáticamente)
    /// </summary>
    private void EndController()
    {

        if (functionSelected == ButtonFunction.BACK && controllerPlayer.Motion < 0)
        {
            controllerPlayer.Motion = 0;
        }
        else if (functionSelected == ButtonFunction.FORWAD && controllerPlayer.Motion > 0)
        {
            controllerPlayer.Motion = 0;
        }

        //switch (functionSelected)
        //{
        //    case ButtonFunction.BACK:
        //        controllerPlayer.Motion = 0;
        //        break;
        //    case ButtonFunction.FORWAD:
        //        controllerPlayer.Motion = 0;
        //        break;
        //}
    }

    /// <summary>
    /// controlar o movimento do personagem através dos comandos de Input.Touch.
    /// </summary>
    /// <param name="multiplier"> Utilizada para tranformar o valor em positivo ou negativo</param>
    void MoveController(int multiplier)
    {
        if (!controllerPlayer.endGame)
        {
            controllerPlayer.Motion += (deltaAxis * multiplier);
        }
    }
}
