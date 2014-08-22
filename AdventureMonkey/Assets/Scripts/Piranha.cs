using UnityEngine;
using System.Collections;

public class Piranha : MonoBehaviour {

    public float timeToStart, high;

    private Vector3 theScale;

    void Start()
    {

        theScale = transform.localScale;
        Invoke("StartMotion", timeToStart);
        
    }

    void Update()
    {
        //print("Velocity : "+ rigidbody2D.velocity.y);

        if (rigidbody2D.velocity.y > 0)
        {
            transform.localScale = new Vector3(theScale.x, theScale.y, theScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-theScale.x, theScale.y, theScale.z);
        }


    }

    void StartMotion()
    {
        rigidbody2D.AddForce(new Vector2(0, 600));
        this.collider2D.isTrigger = true;
        Invoke("Inverse", high);
    }

    void Jump()
    {
        rigidbody2D.AddForce(new Vector2(0, 600));
        this.collider2D.isTrigger = true;
        Invoke("Inverse", high);
    }

    void Inverse()
    {
        this.collider2D.isTrigger = false;
        Invoke("Jump", 1F);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().Die();
            GameObject.Find("Level").GetComponent<Level>().MoveCamera = false;
            Invoke("Restart", 2f);
        }

    }

    void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
