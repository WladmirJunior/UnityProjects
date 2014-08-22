using UnityEngine;
using System.Collections;

public enum RhinoState
{
    IDLE,
    PREPARING,
    RUN,
    BRAKING,
    DIZZY,
}

public class Rhino : MonoBehaviour {

    public RhinoState state;

    public GameObject stone;
    GameObject Player;

    Vector3 startScale;
    int hit;

    private Animator anim;

	void Start () {

        state = RhinoState.IDLE;
        startScale = transform.localScale;
        anim = GetComponent<Animator>();
        Player = GameObject.Find("Player");
        hit = 0;

	}
	
	void Update () {

        anim.SetFloat("Speed", Mathf.Abs(rigidbody2D.velocity.x));

        if (state == RhinoState.RUN && (Mathf.Abs(rigidbody2D.velocity.x) >= 0 && Mathf.Abs(rigidbody2D.velocity.x) < 10))
        {
            state = RhinoState.BRAKING;
            Invoke("Preparing", 0.5F);
        }

        if (state == RhinoState.RUN)
        {
            if (rigidbody2D.velocity.x < 0 && Player.transform.position.x > this.transform.position.x)
            {
                rigidbody2D.velocity = new Vector2(-10, 0);
            }
            else if (rigidbody2D.velocity.x > 0 && Player.transform.position.x + 5 < this.transform.position.x)
            {
                rigidbody2D.velocity = new Vector2(10, 0);
            }
        }
	}

    public void Preparing()
    {
        anim.SetBool("Dizzy", false);

        print("Vezes executadas");
        rigidbody2D.velocity = new Vector2(0, 0);
        state = RhinoState.PREPARING;

        if (Player.transform.position.x < this.transform.position.x)
        {
            transform.localScale = new Vector3(startScale.x, startScale.y, startScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-startScale.x, startScale.y, startScale.z);
        }

        anim.SetBool("Preparing", true);
        
        Invoke("Run", Random.Range(2.5F, 4F));
    }

    public void Run()
    {
        anim.SetBool("Preparing", false);
        state = RhinoState.RUN;

        if (Player.transform.position.x < this.transform.position.x)
        {
            transform.localScale = new Vector3(startScale.x, startScale.y, startScale.z);
            rigidbody2D.velocity = new Vector2(-20, 0);
        }
        else
        {
            transform.localScale = new Vector3(-startScale.x, startScale.y, startScale.z);
            rigidbody2D.velocity = new Vector2(20, 0);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trigger")
        {
            state = RhinoState.DIZZY;
            anim.SetBool("Dizzy", true);
            Dizzy();
            //Invoke("Preparing", 4F);           
        }

        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.GetComponent<Player>().Die();
            GameObject.Find("Level").GetComponent<Level>().MoveCamera = false;
            Invoke("Restart", 2f);
        }
    }

    public void Dizzy()
    {
        hit++;
        stone.GetComponent<Animator>().SetInteger("Hit", hit);

        if (hit < 3)
        {            
            Invoke("Preparing", 4F);                                   
        }
        else
        {
            Invoke("End", 2F);            
        }
        
    }

    void End()
    {
        Destroy(stone);
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<EdgeCollider2D>().enabled = false;
    }

    void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

}
