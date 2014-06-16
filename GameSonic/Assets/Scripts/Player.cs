using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed;
    public float jumpForce;

    public bool jumping = false;

    public int itens = 0;
    
    private float motion;
    public float Motion
    {
        get { return motion; }
        set { motion = Mathf.Clamp(value, -1, 1); }
    }

    void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(motion * speed, rigidbody2D.velocity.y);
        Debug.Log("Motion: "+ motion);
    }

    void Update()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);

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

    void OnGUI()
    {
        GUI.Label(new Rect(100,100,200,100), "Itens: "+itens);
    }

}
