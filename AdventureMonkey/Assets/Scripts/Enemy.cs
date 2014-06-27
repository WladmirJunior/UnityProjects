using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float speed;
    public float timeInverse;

    public GameObject level;

    public bool front = false;

    void Start()
    {
        Invoke("InverseDirection", timeInverse);
        level = GameObject.Find("Level");
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

        if (other.gameObject.tag == "Player" && level.GetComponent<Level>().endLevel == false)
        {
            this.gameObject.GetComponentInChildren<EnemyHit>().HitOff();

            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,400));
            Invoke("Restart", 1f);
        }

    }

    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }

    public void InverseDirection()
    {
        front = !front;
        Invoke("InverseDirection", timeInverse);
    }

    void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

}
