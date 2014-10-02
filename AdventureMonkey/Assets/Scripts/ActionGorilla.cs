using UnityEngine;
using System.Collections;

public class ActionGorilla : MonoBehaviour {

    public Gorila gorilla;
    public GameObject tree, branch;

	void Start () {
	
	}
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            gorilla.rigidbody2D.AddForce(new Vector2(-100, 0));
            Destroy(tree);
            Destroy(branch);
            Invoke("Action", 2f);
        }
    }

    void Action()
    {
        gorilla.StartGorilla();
        Destroy(this.gameObject);
    }
}
