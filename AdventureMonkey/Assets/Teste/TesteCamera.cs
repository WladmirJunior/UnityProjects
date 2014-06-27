using UnityEngine;
using System.Collections;

public class TesteCamera : MonoBehaviour {

    Vector3 p = Vector3.zero;

    void Update()
    {
        p = transform.position;
        p.x = teste.GetPos().x;
        if (p.x < 0)
            p.x = 0;
        transform.position = p;
    }
}
