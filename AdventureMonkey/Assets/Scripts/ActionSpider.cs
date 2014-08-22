using UnityEngine;
using System.Collections;

public class ActionSpider : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Spider")
        {
            Vector3 startPosition = collider.gameObject.transform.position;
            Vector3 startScale = collider.gameObject.transform.localScale;

            collider.gameObject.rigidbody2D.isKinematic = true;

            collider.gameObject.transform.position = new Vector3(startPosition.x, 8.310438F, startPosition.z);
            collider.gameObject.transform.localScale = new Vector3(startScale.x, -startScale.y, startScale.z);
        }
    }
}
