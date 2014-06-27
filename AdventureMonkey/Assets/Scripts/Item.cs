using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().itens++;
            Destroy(this.gameObject);
        }
        
    }



}
