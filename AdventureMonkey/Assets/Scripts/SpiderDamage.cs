﻿using UnityEngine;
using System.Collections;

public class SpiderDamage : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponentInChildren<SpiderHit>().HitOff();

            other.gameObject.GetComponent<Player>().Die();
            GameObject.Find("Level").GetComponent<Level>().MoveCamera = false;
            Invoke("Restart", 2f);
        }

    }

    void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    } 
}
