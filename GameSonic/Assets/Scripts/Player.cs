using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed;
    public float jumpForce;
    public float life;

    public bool jumping = false;
    public bool controllable = true;

    public int itens = 0;
    
    private float motion;
    public float Motion
    {
        get { return motion; }
        set { motion = Mathf.Clamp(value, -1, 1); }
    }

    void FixedUpdate()
    {
        if (controllable)
        {
            rigidbody2D.velocity = new Vector2(motion * speed, rigidbody2D.velocity.y);
            Debug.Log("Motion: " + motion);

            // Para teste na unity
            //rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rigidbody2D.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody2D.AddForce(new Vector2(0, jumpForce));
            }
        }
    }

    void Update()
    {
        // Verifica se esta pulando ou caindo pela sua forca vertical
        jumping = rigidbody2D.velocity.y != 0;
    }

    public void Jump()
    {
        if (!jumping)
        {
            rigidbody2D.AddForce(new Vector2(0, jumpForce));
        }       
    }
    public void Stop()
    {
        rigidbody2D.velocity = new Vector2(0, 0);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(100,100,200,100), "Vida: "+life);
		GUI.Label(new Rect(100,125,200,100), "Itens: "+itens+"/10");
    }

}
