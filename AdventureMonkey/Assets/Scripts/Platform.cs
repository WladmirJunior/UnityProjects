using UnityEngine;
using System.Collections;

public enum PlatformType
{
    FALL,
    MOVE_HORIZONTAL,
    MOVE_VERTICAL,
    NILL,
}

public class Platform : MonoBehaviour {

	public PlatformType platformType;


    public float speed;
    public float timeInverse;
    public float timeFall;
    public float timeDestroy;      

    public bool front = false;
    public bool colliderWithPlayer = false;
    private bool action = false;
    private bool fall = false;
    public bool ghost = true;
    public bool singleMotion = false;

    public Transform pointA, pointB;
    public LayerMask platformLayer;

    public GameObject GroundCheck;

    void Start()
    {
        GroundCheck = GameObject.Find("GroundCheck");
        InvokeRepeating("InverseDirection", timeInverse, timeInverse);
    }

    public void Update()
    {
        if (ghost)
        {
            if (GroundCheck.transform.position.y > pointA.position.y)
            {
                this.collider2D.enabled = true;
                //this.collider2D.isTrigger = false;
            }
            if (GroundCheck.transform.position.y < pointB.position.y)
            {
                this.collider2D.enabled = false;
                //this.collider2D.isTrigger = true;
            }
        }

        colliderWithPlayer = Physics2D.OverlapArea(pointA.position, pointB.position, platformLayer);

        # region Atcion of this platform
        switch (platformType)
        {
            case PlatformType.MOVE_HORIZONTAL:
                if (!singleMotion)
                {
                    if (front)
                    {
                        this.transform.Translate((Vector3.right * Time.deltaTime) * speed);
                    }
                    else
                    {
                        this.transform.Translate((Vector3.left * Time.deltaTime) * speed);
                    }
                }
                else
                {
                    if (colliderWithPlayer) { action = true; }
                    if (action)
                    {
                        Destroy(this, timeInverse);

                        if (front)
                        {
                            this.transform.Translate((Vector3.right * Time.deltaTime) * speed);
                        }
                        else
                        {
                            this.transform.Translate((Vector3.left * Time.deltaTime) * speed);
                        }
                    }
                }
            break;
            case PlatformType.MOVE_VERTICAL:

            if (!singleMotion)
            {
                if (front)
                {
                    this.transform.Translate((Vector3.down * Time.deltaTime) * speed);
                }
                else
                {
                    this.transform.Translate((Vector3.up * Time.deltaTime) * speed);
                }
            }
            else
            {
                if (colliderWithPlayer) { action = true; }
                if (action)
                {
                    Destroy(this, timeInverse);

                    if (front)
                    {
                        this.transform.Translate((Vector3.down * Time.deltaTime) * speed);
                    }
                    else
                    {
                        this.transform.Translate((Vector3.up * Time.deltaTime) * speed);
                    }
                }
            }
                break;
            case PlatformType.FALL:

                if (colliderWithPlayer) { Invoke("Falling", timeFall); }

                if (fall)
                {
                    GetComponent<BoxCollider2D>().enabled = false;
                    this.transform.Translate((Vector3.down * Time.deltaTime) * speed);
                    //Invoke("DestroyPlatform", timeDestroy);
                    Destroy(this.gameObject, timeDestroy);
                }
            break;
        }
        # endregion

        //if (colliderWithPlayer && upPlatform)
        //{
        //    this.collider2D.isTrigger = true;
        //}
        //else
        //{
        //    this.collider2D.isTrigger = false;
        //}


    }

    public void Falling() { fall = true; }

    public void InverseDirection()
    {
        if (!singleMotion)
            front = !front;
    }


    //void OnTriggerEnter2D(Collider2D collider)
    //{
    //    if (collider.gameObject.tag == "Player" && collider.gameObject.transform.position.y + 0.2F > pointA.position.y)
    //    {
    //        upPlatform = true;
    //    }
    //}

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player" && collision.gameObject.transform.position.y + 0.2F > pointA.position.y)
    //    {
    //        upPlatform = true;
    //    }
    //}

}
