using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {


    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //if (!PlayerPrefs.GetString("Audio").Equals("Off"))
            //{
            audio.Play();
            //}
            other.gameObject.GetComponent<Player>().itens++;
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1);
            collider.enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(this.gameObject, 1F);
        }
        
    }



}
