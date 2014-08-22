using UnityEngine;
using System.Collections;

public class Flame : MonoBehaviour {

    public float delta, timeInverse, timeBreak;
    public bool inverse, breakAction;

    private Animator anim;
    private Vector2 initial;

    void Start()
    {
        initial = GetComponent<CircleCollider2D>().center;
        anim = GetComponent<Animator>();
        Invoke("StartMove", 2F); 
    }

    void StartMove()
    {
        GetComponent<CircleCollider2D>().center = initial;
        inverse = false; 
        breakAction = false;
        Invoke("Inverse", timeInverse);
        Invoke("BreakAction", timeInverse * 2);
        anim.SetBool("Move", true);
    }

    void Update()
    {
        if (!breakAction)
        {
            
            if (!inverse)
            {
                GetComponent<CircleCollider2D>().center = new Vector2(GetComponent<CircleCollider2D>().center.x, GetComponent<CircleCollider2D>().center.y + delta);
            }
            else                
                GetComponent<CircleCollider2D>().center = new Vector2(GetComponent<CircleCollider2D>().center.x, GetComponent<CircleCollider2D>().center.y - delta);
        }
    }

    void BreakAction()
    {
        breakAction = true;
        anim.SetBool("Move", false);
        Invoke("StartMove", timeBreak);       
    }

    void Inverse()
    {
        inverse = !inverse;  
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {

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
