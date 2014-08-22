using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

    private bool move = false;
    public float deltaVariation, limit;
    public bool follow;
    public float highTofollow;

    private float yCamera;

    void Start()
    {
        yCamera = Camera.main.transform.position.y;
    }

    void Update()
    {
        if (move && Camera.main.transform.position.y < limit) 
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + deltaVariation, Camera.main.transform.position.z);
        }

        if (follow)
        {
            if (GameObject.Find("Player").transform.position.y > highTofollow)
            {
                GameObject.Find("Level").GetComponent<Level>().levelMode = LevelMode.FOLLOW;
            }
            else 
            {
                GameObject.Find("Level").GetComponent<Level>().levelMode = LevelMode.STATIC;
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, yCamera, Camera.main.transform.position.z);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (!follow) move = true;

            DestroyObject(this.gameObject, 3F);
        }
    }
}
