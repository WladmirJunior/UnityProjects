using UnityEngine;
using System.Collections;

public enum TypeDistance
{
    HORIZONTAL,
    VERTICAL,
    HORIZONTAL_VERTICAL,
}

public class StoneFall : MonoBehaviour {


    public float distance, timeFall;
    public bool destroy;
    public TypeDistance DistanceCalc;
    public Animator anim;
    private GameObject Player;


    void Start()
    {
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
                //anim.SetBool("Swing", true);
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
                    //anim.SetBool("Swing", true);
                    Invoke("Fall", timeFall);
                }
            }
        }
        if (DistanceCalc == TypeDistance.HORIZONTAL_VERTICAL)
        {
            if (Vector2.Distance(new Vector2(Player.transform.position.x, Player.transform.position.y), new Vector2(transform.position.x, transform.position.y)) < distance)
            {
                print("Cair");
                //anim.SetBool("Swing", true);
                Invoke("Fall", timeFall);
            }
        }
    }

    void Fall()
    {
        rigidbody2D.isKinematic = false;
        if(destroy)
            Destroy(this.gameObject, 2F);
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
