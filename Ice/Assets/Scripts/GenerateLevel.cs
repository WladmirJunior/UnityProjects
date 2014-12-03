using UnityEngine;
using System.Collections;

public class GenerateLevel : MonoBehaviour {

    public GameObject[] pieces;
    public Transform originPoint;

    System.Random random;
    float rate  = 1;
    bool create = false;

    private Player player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<Player>();
        random = new System.Random();
        Invoke("Generate", 1F);
        //Invoke("ChangeRate", 60F);

	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(originPoint.position, player.transform.position) < 200 && !create)
        {
            create = true;
        }

        if (create)
        {
            Generate();
        }
	}

    //void ChangeRate()
    //{
    //    rate = 0.5F;
    //    CancelInvoke("Generate");
    //    InvokeRepeating("Generate", 1F, rate);
    //}

    void Generate()
    {
        if (!player.endGame)
        {
            int i = random.Next(pieces.Length);
            while (i < 2 && player.points < 200)
            {
                i = random.Next(pieces.Length);
            }

            GameObject obj = Instantiate(pieces[i], originPoint.position, pieces[i].transform.rotation) as GameObject;
            originPoint = obj.transform.GetChild(0).gameObject.transform;
            //print(obj.transform.GetChild(0).gameObject.name);
            create = false;
        }
        else
        {
            CancelInvoke();
        }
    }
}
