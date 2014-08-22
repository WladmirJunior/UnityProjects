using UnityEngine;
using System.Collections;

public class SavePoint : MonoBehaviour {

    public int savePointNumber = 1;

    //private GameObject Level;

    //void Start()
    //{

    //    Level = GameObject.Find("Level");
    //}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("Level - " + Application.loadedLevel + " SavePoint", savePointNumber);
        }
    }
}
