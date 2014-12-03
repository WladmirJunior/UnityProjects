using UnityEngine;
using System.Collections;

public class Bear : MonoBehaviour {

    private Animator anim;
    public float timeInverse;
    public float speed;
    private Vector3 startScale;

    public bool front = false, stop = false ;

	void Start () {
        startScale = transform.localScale;
        //Invoke("InverseDirection", timeInverse);
        anim = GetComponent<Animator>();
	}
	
	void Update () {
        if (front && !stop)
        {
            //this.transform.Translate((Vector3.right * Time.deltaTime) * speed);
            rigidbody.velocity = new Vector3(10, 0, 0);
            //this.transform.localScale = new Vector3(startScale.x, startScale.y, startScale.z);
        }
        else if (!stop)
        {
            //this.transform.Translate((Vector3.left * Time.deltaTime) * speed);
            rigidbody.velocity = new Vector3(-10, 0, 0);
            //this.transform.localScale = new Vector3(startScale.x, startScale.y, -startScale.z);
        }
	}

    public void InverseDirection()
    {
        anim.SetBool("Flip", false);

        front = !front;

        if (front)
        {
            this.transform.localScale = new Vector3(startScale.x, startScale.y, startScale.z);
        }
        else
        {
            this.transform.localScale = new Vector3(startScale.x, startScale.y, -startScale.z);
        }

        Invoke("Walk", 0.25F);
    }

    void Walk()
    {
        stop = false;
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Mount")
        {
            stop = true;
            rigidbody.velocity = Vector3.zero;
            anim.SetBool("Flip", true);
            Invoke("InverseDirection", 0.78F);
            
        }
        else if (collision.gameObject.tag == "Player")
        {
            stop = true;
            rigidbody.velocity = Vector3.zero;
            anim.SetBool("Flip", true);
        }
    }
}
