using UnityEngine;
using System.Collections;

public class CoinFollow : MonoBehaviour {

    public GameObject coin, player;

    bool follow;

    Transform startMarker;
    Transform endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;

    public float smooth = 5.0F;

    void Start()
    {
        player = GameObject.Find("Player");

        startMarker = coin.transform;
        endMarker = player.transform;
        follow = false;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }
    void Update()
    {
        speed = player.GetComponent<Player>().velocity * 0.35F;
        

        if (follow)
        {   

            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            if (coin != null)
            {
                coin.transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
            }
            else
            {
                Destroy(this.gameObject, 1F);
            }
        }
    }

    //public GameObject coin, other;

 

    //void Update()
    //{
    //    coin.transform.position = Vector3.Lerp(coin.transform.position, other.gameObject.transform.position, 10);
    //}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            follow = true;
        }

    }
}
