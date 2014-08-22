using UnityEngine;
using System.Collections;

public class FinishLevel : MonoBehaviour {

    private GameObject Level;

	void Start () {

        Level = GameObject.Find("Level");
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Level.GetComponent<Level>().EndLevel();
        }
    }
}
