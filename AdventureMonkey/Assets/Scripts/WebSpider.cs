using UnityEngine;
using System.Collections;

public class WebSpider : MonoBehaviour {

    public float liveTime;
    private bool onTarget;

    // direção da projeção da teia,  varia de 1 - 5
    public int direction;

    private GameObject player;
    public GameObject spider;

	void Start () {

        Destroy(this.gameObject, liveTime);      
	}
	
	void Update () {

        if (!onTarget)
        {
            switch (direction)
            {
                case 1:
                    transform.position = new Vector3(transform.position.x - 0.05F, transform.position.y - 0.05F, transform.position.z);
                    break;
                case 2:
                    transform.position = new Vector3(transform.position.x - 0.025F, transform.position.y - 0.05F, transform.position.z);
                    break;
                case 3:
                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.05F, transform.position.z);
                    break;
                case 4:
                    transform.position = new Vector3(transform.position.x + 0.025F, transform.position.y - 0.05F, transform.position.z);
                    break;
                case 5:
                    transform.position = new Vector3(transform.position.x + 0.05F, transform.position.y - 0.05F, transform.position.z);
                    break;
            }
        }
        if (onTarget)
        {
            this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1F, this.transform.position.z);
        }

	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            player = collider.gameObject;
            onTarget = true;
            spider.GetComponent<Spider>().JumpAttack();
            Invoke("End", liveTime/2);
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            player.rigidbody2D.mass = 3;
            player.GetComponent<Player>().speed = 2.5F;
        }
    }

    void End()
    {
        player.rigidbody2D.mass = 1;
        player.GetComponent<Player>().speed = 5;
        DestroyObject(this.gameObject);
    }

}
