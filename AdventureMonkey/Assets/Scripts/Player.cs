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
        //print("vSpeed: " + rigidbody2D.velocity.y);

        if (rigidbody2D.velocity.y > 8)
        {
            rigidbody2D.velocity = new Vector2(0, 8);
        }

        if (controllable)
        {          

            rigidbody2D.velocity = new Vector2(motion * speed, rigidbody2D.velocity.y);         

#if UNITY_EDITOR //Para teste na unity
            rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rigidbody2D.velocity.y);

            if (Input.GetKeyDown(KeyCode.LeftShift)) speed *= 3;
            if (Input.GetKeyUp(KeyCode.RightShift)) speed /= 3;
#endif

            anim.SetFloat("Speed", Mathf.Abs(rigidbody2D.velocity.x));


            if (rigidbody2D.velocity.x < 0)
            {
                direction = (scale) * -1;
            }
            else if (rigidbody2D.velocity.x > 0)
            {
                direction = (scale) * 1;
            }

            if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                rigidbody2D.AddForce(new Vector2(0, jumpForce));
            }
        }

        transform.localScale = new Vector3(direction, scale, scale);

        anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
    }

    void Update()
    {
        //print("VSpeed: " + rigidbody2D.velocity.y);

        // Debug.Log("Colisor:   " + !Physics2D.OverlapCircle(groundCheck.position, 0.1F, whatIsGround));

        // Verifica se esta pulando ou caindo pela sua forca vertical
        //jumping = rigidbody2D.velocity.y != 0 && !Physics2D.OverlapCircle(groundCheck.position, 0.2F, whatIsGround);
        
        if(rigidbody2D.velocity.y != 0 && !Physics2D.OverlapCircle(groundCheck.position, 0.1F, whatIsGround) && controllable)
        {
            jumping = true;
        }
        if (Mathf.Abs(rigidbody2D.velocity.y) < 2 && Physics2D.OverlapCircle(groundCheck.position, 0.1F, whatIsGround))
        {
            jumping = false;
        }
        
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
        rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(rigidbody2D.velocity.x));
        anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
    }

    public void Die()
    {
        controllable = false;
        anim.SetBool("Die", true);
        rigidbody2D.velocity = new Vector2(0, 0);
        rigidbody2D.AddForce(new Vector2(0, 300));
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
    }

}
