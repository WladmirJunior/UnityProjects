using UnityEngine;
using System.Collections;

public class ChangeParent : MonoBehaviour {

    public GameObject player;

	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.tag == "Player")
        { 
            print("Entrou a colisao");
            player.transform.parent = transform;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Player")
        {
            print("saiu a colisao");
            player.transform.parent = null;
        }
    }
}
