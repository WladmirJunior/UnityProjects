using UnityEngine;
using System.Collections;

public class CameraLimit : MonoBehaviour {

    public GameObject level;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            level = GameObject.Find("Level");
            level.GetComponent<Level>().MoveCamera = !level.GetComponent<Level>().MoveCamera;
        }

    }
}
