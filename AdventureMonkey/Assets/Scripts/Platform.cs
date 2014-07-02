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

    bool front = false;
    bool upPlatform = false;
    public bool colliderWithPlayer = false;
    public bool fall = false;

    public Transform pointA, pointB;
    public LayerMask platformLayer;

    public GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    public void Update()
    {
        if (player.transform.position.y > pointA.position.y)
        {
            this.collider2D.isTrigger = false;
        }
        if (player.transform.position.y < pointB.position.y)
        {
            this.collider2D.isTrigger = true;
        }

        colliderWithPlayer = Physics2D.OverlapArea(pointA.position, pointB.position, platformLayer);

        # region Atcion of this platform
        switch (platformType)
        {
            case PlatformType.MOVE_HORIZONTAL:
                if (front)
                {
                    this.transform.Translate((Vector3.right * Time.deltaTime) * speed);
                }
                else
                {
                    this.transform.Translate((Vector3.left * Time.deltaTime) * speed);
                }
            break;
            case PlatformType.FALL:

                if (colliderWithPlayer) { Invoke("Falling", timeFall); }

                if (fall)
                {
                    GetComponent<BoxCollider2D>().enabled = false;
                    this.transform.Translate((Vector3.down * Time.deltaTime) * speed);
                    Invoke("DestroyPlatform", timeDestroy);
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

    public void DestroyPlatform()
    {
        Destroy(this.gameObject);
    }

    public void InverseDirection()
    {
        front = !front;
        Invoke("InverseDirection", timeInverse);
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
