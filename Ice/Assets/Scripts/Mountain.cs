using UnityEngine;
using System.Collections;

public class Mountain : MonoBehaviour {

    bool destroy = false;
    GameObject player;

    void Update()
    {
        if (destroy)
        {
            if (Vector3.Distance(this.transform.position, player.transform.position) > 100) Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && !collider.gameObject.GetComponent<Player>().endGame)
        {
            //Destroy(this.gameObject, 10F);
            destroy = true;
            player = collider.gameObject;
        }
    }
}
