using UnityEngine;
using System.Collections;

public class EnemyHit : MonoBehaviour {

    bool hit = true;

    public void HitOff()
    {
        hit = false;
        Invoke("HitOn", 1.5f);
    }

    public void HitOn()
    {
        hit = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && hit)
        {
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 200));
            this.gameObject.GetComponentInParent<Enemy>().DestroyEnemy();
        }

    }
}
