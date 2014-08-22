using UnityEngine;
using System.Collections;


public class Enemy : MonoBehaviour {

    public float speed;
    
    // o inimigo terá o sprite invertido
    public bool inverse = true;
    public float timeInverse;
    // o inimigo voa
     public bool fly = false;
    public float timeInverseFly;
    // o inimigo tem uma pausa de movimentos
    public bool breakAction = false;
    public float timeBreak;


    private bool breakActive = false;
    public GameObject level;

    private Vector3 startScale;

    public bool front = false, inverseFly = false;

    void Start()
    {
        if(breakAction)
            Invoke("Break", timeInverseFly);

        startScale = transform.localScale;
        Invoke("InverseDirection", timeInverse);
        Invoke("InverseFly", timeInverseFly);
        level = GameObject.Find("Level");
    }

    void Update()
    {
        if (inverse)
        {
            if (front)
            {
                this.transform.Translate((Vector3.right * Time.deltaTime) * speed);
                this.transform.localScale = new Vector3(startScale.x, startScale.y, startScale.z);
            }
            else
            {
                this.transform.Translate((Vector3.left * Time.deltaTime) * speed);
                this.transform.localScale = new Vector3(-startScale.x, startScale.y, startScale.z);
            }
        }

        if (fly)
        {
            if (inverseFly && !breakActive)
            {
                this.transform.Translate((Vector3.down * Time.deltaTime) * speed);
            }
            else if (!breakActive)
                this.transform.Translate((Vector3.up * Time.deltaTime) * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {        

        if (other.gameObject.tag == "Player" && level.GetComponent<Level>().endLevel == false)
        {
            this.gameObject.GetComponentInChildren<EnemyHit>().HitOff();

            other.gameObject.GetComponent<Player>().Die();
            GameObject.Find("Level").GetComponent<Level>().MoveCamera = false;
            Invoke("Restart", 2f);
        }

    }

    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }

    public void Break()
    {
        breakActive = !breakActive;

        if (fly)
        {
            Invoke("Break", timeBreak);
            Invoke("InverseFly", timeBreak * 2);
        }
    }

    public void InverseFly()
    {
        inverseFly = !inverseFly;
        if (!breakActive)
            Invoke("InverseFly", timeInverseFly);

    }

    public void InverseDirection()
    {
        front = !front;
        Invoke("InverseDirection", timeInverse);
    }

    void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

}
