using UnityEngine;
using System.Collections;

public enum SpiderState
{
    IDLE,
    RUN, 
    JUMP,
    RUN_UP,
    WEB_ATTACK,
    JUMP_ATTACK,
}

public class Spider : MonoBehaviour {

    public SpiderState state;

    GameObject Player;
    Vector3 startScale;
    public bool front = true;
    private bool endWebAttack, hitOn;

    public int hits = 0, webAttacks = 0;

    public float limitLeft, limitRight;

    public GameObject web, exit;
    public Transform exitPosition;

    private Animator anim;

	void Start()
    {
        endWebAttack = false;
        hitOn = true;
        Player = GameObject.Find("Player");
        startScale = transform.localScale;
        anim = GetComponent<Animator>();

        Run();
        
    }

    void Jump()
    {       
        state = SpiderState.JUMP;
        rigidbody2D.velocity = new Vector2(0, 0);
        rigidbody2D.AddForce(new Vector2(500, 6000));
        Invoke("RunUP", 2F);
    }

    void Run()
    {
        state = SpiderState.RUN;
        webAttacks = 0;
        Invoke("Jump", 5F);
    }

    void RunUP()
    {
        if (state == SpiderState.JUMP || state == SpiderState.WEB_ATTACK)
        {
            endWebAttack = false;            
            state = SpiderState.RUN_UP;
            Invoke("WebAttack", 5F);
        }
    }

    void WebAttack()
    {

        if (state == SpiderState.RUN_UP && webAttacks < 3)
        {
            state = SpiderState.WEB_ATTACK;
            webAttacks++;
            rigidbody2D.velocity = new Vector2(0, 0);

            GameObject web1 = Instantiate(web, this.transform.position, Quaternion.identity) as GameObject;
            web1.GetComponent<WebSpider>().direction = 1;
            web1.GetComponent<WebSpider>().spider = this.gameObject;

            GameObject web2 = Instantiate(web, this.transform.position, Quaternion.identity) as GameObject;
            web2.GetComponent<WebSpider>().direction = 2;
            web2.GetComponent<WebSpider>().spider = this.gameObject;

            GameObject web3 = Instantiate(web, this.transform.position, Quaternion.identity) as GameObject;
            web3.GetComponent<WebSpider>().direction = 3;
            web3.GetComponent<WebSpider>().spider = this.gameObject;

            GameObject web4 = Instantiate(web, this.transform.position, Quaternion.identity) as GameObject;
            web4.GetComponent<WebSpider>().direction = 4;
            web4.GetComponent<WebSpider>().spider = this.gameObject;

            GameObject web5 = Instantiate(web, this.transform.position, Quaternion.identity) as GameObject;
            web5.GetComponent<WebSpider>().direction = 5;
            web5.GetComponent<WebSpider>().spider = this.gameObject;
            Invoke("RunUP", 2F);
        }
        else if (state == SpiderState.RUN_UP)
        {
            state = SpiderState.JUMP_ATTACK;
        }
    }

    void Update()
    {
        switch (state)
        {
            case SpiderState.RUN:

                if (front)
                {
                    transform.localScale = new Vector3(-startScale.x, startScale.y, startScale.z);
                    rigidbody2D.velocity = new Vector2(-10, 0);
                }
                else
                {
                    transform.localScale = new Vector3(startScale.x, startScale.y, startScale.z);
                    rigidbody2D.velocity = new Vector2(10, 0);
                }

                break;

            case SpiderState.RUN_UP:

                if (front)
                {
                    if (transform.position.x > limitLeft)
                    {
                        transform.localScale = new Vector3(-startScale.x, -startScale.y, startScale.z);
                        rigidbody2D.velocity = new Vector2(-5, 0);
                    }
                    else { front = !front; }
                }
                else if (transform.position.x < limitRight)
                {
                    transform.localScale = new Vector3(startScale.x, -startScale.y, startScale.z);
                    rigidbody2D.velocity = new Vector2(5, 0);
                }
                else { front = !front; }

                break;
            case SpiderState.WEB_ATTACK:
                
                // a ação esta no metodo webAttack, não é nescessário estar aqui no update pois acontece apenas uma vez

                break;
            case SpiderState.JUMP_ATTACK:

               // print("Distance: " + Vector2.Distance(new Vector2(transform.position.x, 0), new Vector2(Player.transform.position.x, 0)));

                if (this.transform.position.x > Player.transform.position.x && Vector2.Distance(new Vector2(transform.position.x, 0), new Vector2(Player.transform.position.x, 0)) > 3)
                {
                    transform.localScale = new Vector3(-startScale.x, -startScale.y, startScale.z);
                    rigidbody2D.velocity = new Vector2(-5, 0);
                }
                else if (this.transform.position.x < Player.transform.position.x && Vector2.Distance(new Vector2(transform.position.x, 0), new Vector2(Player.transform.position.x, 0)) > 3)
                {
                    transform.localScale = new Vector3(startScale.x, -startScale.y, startScale.z);
                    rigidbody2D.velocity = new Vector2(5, 0);
                }
                else if (!endWebAttack)
                {
                    state = SpiderState.IDLE;
                    endWebAttack = true;
                    rigidbody2D.isKinematic = false;
                    transform.localScale = new Vector3(transform.localScale.x, startScale.y, startScale.z);
                    Invoke("Run", 4F);
                }

                break;
        }
    }

    public void JumpAttack()
    {
        if (state != SpiderState.IDLE)
        {
         
            state = SpiderState.JUMP_ATTACK;
        }
    }

    public void DestroySpider()
    {
        if (hitOn)
        {
            if (hits >= 4)
            {
                Instantiate(exit, exitPosition.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            else 
            { 
                hits++;
                anim.SetBool("Hit", true);
            }

            hitOn = false;
            Invoke("Hit", 1F);
        }
        
    }

    void Hit()
    {
        hitOn = true;
        anim.SetBool("Hit", false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.tag.Equals("Player"))
        {   
            front = !front;
        }
    }

    public void InverseDirection()
    {
        front = !front;
        Invoke("InverseDirection", 5F);
    }
}
