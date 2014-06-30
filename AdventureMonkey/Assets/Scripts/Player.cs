using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed;
    public float jumpForce;
    //public float life;

    public bool jumping = false;
    public bool controllable = true;

    public int itens = 0;

    private Animator anim;
    private int direction = -2;

    private float motion;
    public float Motion
    {
        get { return motion; }
        set { motion = Mathf.Clamp(value, -1, 1); }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (controllable)
        {
            rigidbody2D.velocity = new Vector2(motion * speed, rigidbody2D.velocity.y);         

            // Para teste na unity
            rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rigidbody2D.velocity.y);

            anim.SetFloat("Speed", Mathf.Abs(rigidbody2D.velocity.x));


            if (rigidbody2D.velocity.x < 0)
            {
                direction = 2;
            }
            else if (rigidbody2D.velocity.x > 0)
            {
                direction = -2;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody2D.AddForce(new Vector2(0, jumpForce));
            }
        }

        transform.localScale = new Vector3(direction, 2F, 2F);
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
        anim.SetFloat("Speed", Mathf.Abs(rigidbody2D.velocity.x));
    }

}
