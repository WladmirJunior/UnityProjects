
using UnityEngine;
using System.Collections;

public class Web : MonoBehaviour {

    public float time;
    private GameObject player;

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            player = collider.gameObject;
            player.rigidbody2D.mass = 3;
            player.GetComponent<Player>().speed = 0.5F;            
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Invoke("End", time);
        }
    }

    void End()
    {
        player.rigidbody2D.mass = 1;
        player.GetComponent<Player>().speed = 5;
    }
}
