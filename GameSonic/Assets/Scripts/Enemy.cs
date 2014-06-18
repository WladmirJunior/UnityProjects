using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float speed;
    public float TimeInverse;

    bool front = false;

    void Start()
    {
        Invoke("InverseDirection", TimeInverse);
    }

    void Update()
    {
        if (front)
        {
            this.transform.Translate((Vector3.right * Time.deltaTime) * speed);
        }
        else
        {
            this.transform.Translate((Vector3.left  * Time.deltaTime) * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponentInChildren<EnemyHit>().HitOff();

            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,200));
            other.gameObject.GetComponent<Player>().life--;
        }

    }

    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }

    public void InverseDirection()
    {
        front = !front;
        Invoke("InverseDirection", TimeInverse);
    }

}
