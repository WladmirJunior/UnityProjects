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
    public float scale = 1.5F;
    private float direction = 1.5F;

    public Transform groundCheck;
    public LayerMask whatIsGround;

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
                direction = (scale) * -1;
            }
            else if (rigidbody2D.velocity.x > 0)
            {
                direction = (scale) * 1;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody2D.AddForce(new Vector2(0, jumpForce));
            }
        }

        transform.localScale = new Vector3(direction, scale, scale);

        anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
    }

    void Update()
    {
        // Verifica se esta pulando ou caindo pela sua forca vertical
        jumping = rigidbody2D.velocity.y != 0 && !Physics2D.OverlapCircle(groundCheck.position, 0.2F, whatIsGround);
        //jumping = !Physics2D.OverlapCircle(groundCheck.position, 1F, whatIsGround);
        anim.SetBool("Grounded", !jumping);

    }

    public void Jump()
    {
        if (!jumping)
        {
            rigidbody2D.AddForce(new Vector2(0, jumpForce));
            anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
        }       
    }
    public void Stop()
    {
        rigidbody2D.velocity = new Vector2(0, 0);
        anim.SetFloat("Speed", Mathf.Abs(rigidbody2D.velocity.x));
    }

}
