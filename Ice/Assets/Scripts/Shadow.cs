using UnityEngine;
using System.Collections;

public class Shadow : MonoBehaviour {

    GameObject player;
    Vector3 shadowPosition, shadowScale;

    void Start()
    {
        player = GameObject.Find("Player");
        shadowScale = transform.localScale;
        shadowPosition = this.transform.position;
    }

    void Update()
    {

        if (player.GetComponent<Player>().endGame != true)
        {

            float distance = Vector3.Distance(this.transform.position, player.transform.position);
            //print(distance);

            if (distance < 1F)
            {
                shadowScale = new Vector3(0,0,0);
            }
            else
            {
                shadowScale = new Vector3(1, 1, 1);
            }

            //shadowPosition = player.transform.position;
            shadowPosition.x = player.transform.position.x;
            //shadowPosition.y = tion.y;
            shadowPosition.z = player.transform.position.z;

            //shadowScale = new Vector3(distance * 2, distance * 2, distance * 2);
            
            this.transform.localScale = shadowScale;

            this.transform.position = shadowPosition;


            //this.transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z - 18);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
