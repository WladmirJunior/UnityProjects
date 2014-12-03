
using UnityEngine;
using System.Collections;

public class SnowMonster : MonoBehaviour {

    public GameObject SnowBall;

    private Animator anim;
    private GameObject player;

    private bool move = false;
    private Transform target;
    private Vector3 normalize;

	void Start () {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        target = this.transform;
	}
	
	void Update () {
        transform.LookAt(player.transform);

        if (move && SnowBall != null)
        {
            Vector3 pos = SnowBall.transform.position;
            SnowBall.transform.Translate(normalize * Time.deltaTime * 20);
            SnowBall.transform.position = new Vector3(SnowBall.transform.position.x, pos.y, SnowBall.transform.position.z);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            normalize =  Vector3.Normalize(other.transform.position);
            anim.SetBool("Attack", true);
            Invoke("EndAttack", 0.50F);
        }

    }

    void EndAttack()
    {
        anim.SetBool("Attack", false);
        SnowBall.transform.parent = null;
        print(SnowBall.transform.position);
        move = true;
        Destroy(SnowBall, 10F);        
    }
}
