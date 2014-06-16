using UnityEngine;
using System.Collections;


public enum Motion
{
    FORWARD,
    BACK,
    IDLE,
}

public class TouchInput : MonoBehaviour {

    public GUITexture btnBack, btnForward, btnJump;

    private Texture backNormal, ForwardNormal, jumpNormal;
    public Texture backHold, ForwardHold, jumpHold;

    public Player controllerPlayer;
    public float deltaAxis;

    public Motion motionState = Motion.IDLE;

    private int touchJump;

    void Awake()
    {
        backNormal = btnBack.texture;
        ForwardNormal = btnForward.texture;
        jumpNormal = btnJump.texture;
    }

    void Update()
    {
        if (Input.touchCount <= 0)
        {
            if ((motionState == Motion.BACK || motionState == Motion.FORWARD) && (!controllerPlayer.jumping))
            {
                controllerPlayer.Motion = 0;
                motionState = Motion.IDLE;
            }

            btnJump.texture = jumpNormal;
            //Debug.Log("Não tem toque na tela!");
        }
        else
        {
            // Percorre todos os toques de tela
            for (int i = 0; i < Input.touchCount; i++)
            {



                // Máquina de estados para o botao back
                if (btnBack.guiTexture.HitTest(Input.GetTouch(i).position))
                {
                    //btnBack.texture = backHold;
                    controllerPlayer.Motion -= deltaAxis;
                    motionState = Motion.BACK;
                }
                //else if (motionState == Motion.BACK && !controllerPlayer.jumping)
                //{
                //    //Debug.Log("Tirou o dedo de andar para tras");
                //    controllerPlayer.Motion = 0;
                //}

                // Máquina de estados para o botao forward
                else if (btnForward.guiTexture.HitTest(Input.GetTouch(i).position))
                {
                    controllerPlayer.Motion += deltaAxis;
                    motionState = Motion.FORWARD;
                }
                //else if (motionState == Motion.FORWARD && !controllerPlayer.jumping)
                //{
                //    //Debug.Log("Tirou o dedo de andar para frente");
                //    controllerPlayer.Motion = 0;
                //}

                //// Máquina de estados para o botao jump
                else if (btnJump.guiTexture.HitTest(Input.GetTouch(i).position))
                {
                    //Debug.Log("Salto");
                    // Jump
                    touchJump = i;
                    btnJump.texture = jumpHold;
                    controllerPlayer.Jump();
                    controllerPlayer.jumping = true;
                }
                else
                {
                    btnJump.texture = jumpNormal;
                }
            }

            //if (!btnJump.guiTexture.HitTest(Input.GetTouch(touchJump).position))
            //{
            //    Debug.Log("Tirou o dedo do botao jump");
            //}

        }

        if (controllerPlayer.Motion == 0) { motionState = Motion.IDLE; }

        switch (motionState)
        {
            case Motion.IDLE:
                btnBack.texture = backNormal;
                btnForward.texture = ForwardNormal;
                break;
            case Motion.BACK:
                btnForward.texture = ForwardNormal;
                btnBack.texture = backHold;
                break;
            case Motion.FORWARD:
                btnBack.texture = backNormal;
                btnForward.texture = ForwardHold;
                break;
        }

    }




}
