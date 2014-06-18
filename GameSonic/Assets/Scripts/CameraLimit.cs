using UnityEngine;
using System.Collections;

public class CameraLimit : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Player>().moveCamera = !other.GetComponent<Player>().moveCamera;
        }

    }
}
