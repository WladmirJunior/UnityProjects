using UnityEngine;
using System.Collections;

public class Duck : MonoBehaviour {

    private Animator anim;
    public float timeToStart, timeToDestroy;

    void Start()
    {
        anim = GetComponent<Animator>();
        Invoke("Flying", timeToStart);
        Invoke("Disapear", timeToDestroy);
    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime);
    }

    void Flying()
    {
        anim.SetBool("Fly", true);
    }

    void Disapear()
    {
        Destroy(this.gameObject);
    }

}
