using UnityEngine;
using System.Collections;

public class ControllerCamera : MonoBehaviour {

    GameObject player;
    Vector3 cameraPosition;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (player != null)
        {

            cameraPosition = player.transform.position;
            cameraPosition.y = transform.position.y;
            cameraPosition.z = player.transform.position.z - 18;

            if (cameraPosition.x > 100)
            {
                cameraPosition.x = 100;
                print("Foi pra direita");
            }
            if (cameraPosition.x < 97)
            {
                cameraPosition.x = 97;
            }

            this.transform.position = cameraPosition;

            //this.transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z - 18);
        }
    }
}
