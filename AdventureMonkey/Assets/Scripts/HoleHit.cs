using UnityEngine;
using System.Collections;

public class HoleHit : MonoBehaviour {

    private bool active = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (active && other.gameObject.tag == "Player")
        {
            Invoke("Restart", 3f);
            other.gameObject.GetComponent<Player>().controllable = false;
            other.gameObject.GetComponent<Player>().Stop();
            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 800));
            active = false;
        }
        
    }

    void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
