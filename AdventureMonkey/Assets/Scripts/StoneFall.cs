    using UnityEngine;
using System.Collections;

public enum TypeDistance
{
    HORIZONTAL,
    VERTICAL,
    HORIZONTAL_VERTICAL,
}

public enum TypeFall 
{
    ONE, 
    TWO,
}

public class StoneFall : MonoBehaviour {


    public float distance, timeFall;
    public bool destroy;
    public TypeDistance DistanceCalc;
    public TypeFall typeFalling;
    public GameObject animation;
    private GameObject Player;

    private Animator anim;

    public GameObject parent;

    void Start()
    {
        if (animation != null) { anim = animation.GetComponent<Animator>(); }
        Player = GameObject.Find("Player");
        rigidbody2D.isKinematic = true;


    }

    void Update()
    {
        if (DistanceCalc == TypeDistance.HORIZONTAL)
        {

            if (Vector2.Distance(new Vector2(Player.transform.position.x, 0), new Vector2(transform.position.x, 0)) < distance)
            {
                print("Cair");

                if (typeFalling == TypeFall.TWO) { anim.SetBool("Swing", true); }
                
                Invoke("Fall", timeFall);
            }
        }
        if (DistanceCalc == TypeDistance.VERTICAL)
        {
            if (Vector2.Distance(new Vector2(Player.transform.position.x, 0), new Vector2(transform.position.x, 0)) < 20F)
            {
                if (Vector2.Distance(new Vector2(0, Player.transform.position.y), new Vector2(0, transform.position.y)) < distance)
                {
                    print("Cair");
                    if (typeFalling == TypeFall.TWO) { anim.SetBool("Swing", true); }
                    Invoke("Fall", timeFall);
                }
            }
        }
        if (DistanceCalc == TypeDistance.HORIZONTAL_VERTICAL)
        {
            if (Vector2.Distance(new Vector2(Player.transform.position.x, Player.transform.position.y), new Vector2(transform.position.x, transform.position.y)) < distance)
            {

                if (typeFalling == TypeFall.TWO) { anim.SetBool("Swing", true); }
                Invoke("Fall", timeFall);
            }
        }
    }

    void Fall()
    {
        if (typeFalling == TypeFall.TWO) { anim.SetBool("Swing", false); }

        rigidbody2D.isKinematic = false;
        if (destroy)
        {
            Destroy(this.gameObject, 2F);
            if (parent != null) { Destroy(parent, 2f); }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {

            other.gameObject.GetComponent<Player>().Die();
            Invoke("Restart", 1f);
        }

    }
    void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

}
