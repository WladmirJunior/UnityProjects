using UnityEngine;
using System.Collections;

public class teste : MonoBehaviour {

    private static teste _Singleton; 

    public float Movement;
    private Vector2 v2;

    void Start()
    {
        _Singleton = this;
    }

	// Update is called once per frame
	void Update () {

        float h = Input.GetAxis("Horizontal");

        //Movement = new Vector3(transform.position.x + h, transform.position.y, transform.position.z);

        //transform.position = Movement;

        v2 = rigidbody2D.velocity;
        v2.x = h * Movement;
        rigidbody2D.velocity = v2;

        //rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * Movement, rigidbody.velocity.y, 0);

        //Camera.main.transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
	}

    public static Vector3 GetPos()
    {
        return _Singleton.transform.position;
    }
}
