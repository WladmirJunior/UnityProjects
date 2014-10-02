using UnityEngine;
using System.Collections;

public enum GorilaState
{
    IDLE,
    PREPARING,
    RUN,
    JUMPSHAKE,
    JUMPING,
}

public class Gorila : MonoBehaviour {

    private Animator anim;
    public GorilaState state;
    public float speedJump = 3;

    public GameObject coconut, exit;
    public Transform[] positions;

    public Transform exitPosition;

    private bool hitOn;
    public int hits = 0;

    Vector3 startScale;
    System.Random rnd;

	void Start () {
        hitOn = true;
        rnd = new System.Random();
        anim = GetComponent<Animator>();
        state = GorilaState.IDLE;
        startScale = transform.localScale;
	}
	
	void Update () 
    {
        anim.SetFloat("Speed", rigidbody2D.velocity.x);

        if (rigidbody2D.velocity.x < 0)
        {
            transform.localScale = new Vector3(startScale.x, startScale.y, startScale.z);
        }
        else if (rigidbody2D.velocity.x > 0)
        {
            transform.localScale = new Vector3(-startScale.x, startScale.y, startScale.z);
        }
	
	}

    # region Actions

    public void Preparing()
    {
        anim.SetBool("Preparing", true);
        rigidbody2D.velocity = new Vector2(-5, 0);
        state = GorilaState.PREPARING;
        Invoke("BreakAction", 1.2f);
        Invoke("RunAction", 2f);
    }

    void BreakAction()
    {
        anim.SetBool("Preparing", false);
    }

    public void RunAction()
    {       

        if (state != GorilaState.RUN)
        {
            rigidbody2D.velocity = new Vector2(20, 0);
            state = GorilaState.RUN;
            Invoke("JumpAction", 0.3f);
        }       
    }

    public void JumpAction()
    {
        rigidbody2D.velocity = new Vector2(0, 0);
        rigidbody2D.AddForce(new Vector2(4400, 3500));        
        Invoke("BigJump", 1.15f); 
    }

    void BigJump()
    {        
        rigidbody2D.velocity = new Vector2(0, 0);
        rigidbody2D.AddForce(new Vector2(4000, 4500));
        collider2D.enabled = false;
        Invoke("CollisionEnable", 1.3F);
        Invoke("EndJump", 1.5f);
    }

    void EndJump()
    {
        rigidbody2D.velocity = new Vector2(0, 0);
        rigidbody2D.AddForce(new Vector2(3400, 6000));
    }

    # endregion

    public void StartGorilla()
    {        
        state = GorilaState.JUMPSHAKE;
        JumpShake();
        Invoke("SortRegion", 3F); 
    }

    public void StartGorillaOne()
    {
        state = GorilaState.JUMPSHAKE;
        JumpShake();
        Invoke("AttackOne_11", 5F);
    }

    public void StartGorillaTwo()
    {
        state = GorilaState.JUMPSHAKE;
        JumpShake();
        Invoke("AttackTwo_12", 5F);
    }

    public void JumpShake()
    {
        if (state == GorilaState.JUMPSHAKE)
        {
            rigidbody2D.AddForce(new Vector2(0, 3000));            
            Invoke("JumpShake", 3f);
            
            Instantiate(coconut, positions[rnd.Next(0,positions.Length)].position, Quaternion.identity);
            Instantiate(coconut, positions[rnd.Next(0, positions.Length)].position, Quaternion.identity);
            Instantiate(coconut, positions[rnd.Next(0, positions.Length)].position, Quaternion.identity);
            Instantiate(coconut, positions[rnd.Next(0, positions.Length)].position, Quaternion.identity);
            Instantiate(coconut, positions[rnd.Next(0, positions.Length)].position, Quaternion.identity);
        }
    }    

    # region Right Attack

    void AttackOne()
    {
        state = GorilaState.JUMPING;
        collider2D.enabled = false;
        Invoke("CollisionEnable", 1.7F);
        rigidbody2D.AddForce(new Vector2(-2400, 3000));
        SortRegionOne();

    }

    void AttackTwo()
    {
        state = GorilaState.JUMPING;
        collider2D.enabled = false;
        Invoke("CollisionEnable", 1.7F);
        rigidbody2D.AddForce(new Vector2(2000, 3000));
        SortRegionTwo();
    }

    void AttackTwo_1()
    {
        state = GorilaState.JUMPING;
        collider2D.enabled = false;
        Invoke("CollisionEnable", 1F);
        rigidbody2D.AddForce(new Vector2(2500, 5000));
        SortRegionTwo_1();
    }

    void AttackTwo_2()
    {
        state = GorilaState.JUMPING;
        collider2D.enabled = false;
        Invoke("CollisionEnable", 1F);
        rigidbody2D.AddForce(new Vector2(3200, 2500));
        SortRegionTwo_2();
    }

    void AttackTwo_3()
    {
        state = GorilaState.JUMPING;
        collider2D.enabled = false;
        Invoke("CollisionEnable", 1.2F);
        rigidbody2D.AddForce(new Vector2(-2700, 2000));
        SortRegionTwo_3();
    }

    void AttackTwo_4()
    {
        state = GorilaState.JUMPING;
        collider2D.enabled = false;
        Invoke("CollisionEnable", 1.3F);
        rigidbody2D.AddForce(new Vector2(-2500, 5000));
        SortRegion();
    }

    void AttackTwo_11()
    {
        state = GorilaState.JUMPING;
        collider2D.enabled = false;
        Invoke("CollisionEnable", 1.5F);
        rigidbody2D.AddForce(new Vector2(-5000, 4000));
        SortRegion();
    }

    void AttackTwo_12()
    {
        state = GorilaState.JUMPING;
        collider2D.enabled = false;
        Invoke("CollisionEnable", 1.3F);
        rigidbody2D.AddForce(new Vector2(-3200, 2000));
        SortRegionTwo();
    }

    void AttackTwo_21()
    {
        state = GorilaState.JUMPING;
        collider2D.enabled = false;
        Invoke("CollisionEnable", 1.38F);
        rigidbody2D.AddForce(new Vector2(-3100, 4000));
        SortRegionTwo();
    }

    void AttackTwo_31()
    {
        state = GorilaState.JUMPING;
        collider2D.enabled = false;
        Invoke("CollisionEnable", 1F);
        print("novo teste");
        rigidbody2D.AddForce(new Vector2(3200, 3400));
        SortRegionTwo();
    }

    void AttackTwo_32()
    {
        state = GorilaState.JUMPING;
        collider2D.enabled = false;
        Invoke("CollisionEnable", 1.3F);
        print("Teste novooo22222222");
        rigidbody2D.AddForce(new Vector2(-3300, 4000));
        SortRegionOne();
    }

    void AttackOne_1()
    {
        state = GorilaState.JUMPING;
        collider2D.enabled = false;
        Invoke("CollisionEnable", 1F);
        print("atk1");
        rigidbody2D.AddForce(new Vector2(-2500, 4500));
        SortRegionOne_1();
    }

    void AttackOne_2()
    {
        state = GorilaState.JUMPING;
        collider2D.enabled = false;
        Invoke("CollisionEnable", 1F);
        print("atk2");
        rigidbody2D.AddForce(new Vector2(-2700, 2000));
        Invoke("AttackOne_21", 2f);
    }

    void AttackOne_3()
    {
        state = GorilaState.JUMPING;
        collider2D.enabled = false;
        Invoke("CollisionEnable", 1.2F);
        print("atk3");
        rigidbody2D.AddForce(new Vector2(3400, 2000));
        SortRegionTwo_3();
    }

    void AttackOne_4()
    {
        state = GorilaState.JUMPING;
        collider2D.enabled = false;
        Invoke("CollisionEnable", 1.5F);
        print("atk4");
        rigidbody2D.AddForce(new Vector2(2700, 5000));
        SortRegion();
    }

    void AttackOne_11()
    {
        state = GorilaState.JUMPING;
        collider2D.enabled = false;
        Invoke("CollisionEnable", 1.3F);
        rigidbody2D.AddForce(new Vector2(2500, 2000));
        SortRegionOne();
    }

    void AttackOne_21()
    {
        state = GorilaState.JUMPING;
        collider2D.enabled = false;
        Invoke("CollisionEnable", 1.2F);
        rigidbody2D.AddForce(new Vector2(2600,4000));
        SortRegionOne();
    }

    # endregion

    # region Sort Regions of Jumper

    void SortRegion()
    {
        if (state != GorilaState.JUMPSHAKE)
        {
            switch (rnd.Next(2, 3))
            {
                case 1:
                    Invoke("AttackOne", speedJump);
                    break;
                case 2:
                    Invoke("AttackTwo", speedJump);
                    break;
                default:
                    Invoke("StartGorilla", 3F);
                    break;
            }   
        }
        else
        {
            switch (rnd.Next(2, 3))
            {
                case 1:
                    Invoke("AttackOne", 2F);
                    break;
                case 2:
                    Invoke("AttackTwo", 2F);
                    break;
            }
        }
    }

    void SortRegionOne()
    {
        switch (rnd.Next(1, 5))
        {
            case 1:
                Invoke("AttackOne_1", speedJump);
                break;
            case 2:
                Invoke("AttackOne_2", speedJump);
                break;
            case 3:
                Invoke("AttackOne_3", speedJump);
                break;
            case 4:
                Invoke("AttackOne_4", speedJump);
                break;
        } 
    }

    void SortRegionTwo()
    {
        switch (rnd.Next(1, 3))
        {
            case 1:
                Invoke("AttackTwo_1", speedJump);
                break;
            case 2:
                Invoke("AttackTwo_2", speedJump);
                break;
            case 3:
                Invoke("AttackTwo_3", speedJump);
                break;
            case 4:
                Invoke("AttackTwo_4", speedJump);
                break;
        } 
    }

    void SortRegionTwo_1()
    {
        switch (rnd.Next(1, 5))
        {
            case 1:
                Invoke("AttackTwo_11", speedJump);
                break;
            case 2:
                Invoke("AttackTwo_12", speedJump);
                break;
            default:
                Invoke("StartGorillaTwo", 3F);
                break;

        } 
    }
    void SortRegionTwo_2()
    {
        Invoke("AttackTwo_21", speedJump);
    }
    void SortRegionTwo_3()
    {
        switch (rnd.Next(1, 3))
        {
            case 1:
                Invoke("AttackTwo_31", speedJump);
                break;
            case 2:
                Invoke("AttackTwo_32", speedJump);
                break;
        }
    }

    void SortRegionOne_1()
    {
        switch (rnd.Next(1, 4))
        {
            case 1:
                Invoke("AttackOne_11", speedJump);
                break;
            default:
                Invoke("StartGorillaOne", 3F);
                break;
        }
    }

    # endregion

    public void DestroyGorila()
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
                if(speedJump>=2.5F)
                    speedJump -= 0.5F;
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

    void CollisionEnable()
    {
        this.collider2D.enabled = true;
    }
}
