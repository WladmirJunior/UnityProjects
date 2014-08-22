using UnityEngine;
using System.Collections;

public class HoleHit : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (active && other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().Die();
            GameObject.Find("Level").GetComponent<Level>().MoveCamera = false;
            Invoke("Restart", 2f);
            active = false;
        }
        
    }

    void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
