using UnityEngine;
using System.Collections;

public class ProcedureMountain : MonoBehaviour {

    public GameObject[] assets;
    public Transform[] positions;
    public int numberOfIntances;

    private System.Random random = new System.Random();
    private ArrayList positionsUsed;

    void Start()
    {
        if (numberOfIntances > positions.Length) { numberOfIntances = positions.Length; }

        
        positionsUsed = new ArrayList();

        for (int i = 0; i < numberOfIntances; i++)
        {
            int asset = random.Next(assets.Length);
            int position = random.Next(positions.Length);

            if (!positionsUsed.Contains(position))
            {
                print("criou");
                GameObject obj = Instantiate(assets[asset], positions[position].position, assets[asset].transform.rotation) as GameObject;                
                obj.transform.parent = transform;
                positionsUsed.Add(position);                
            }
            else
            {
                print("Posicao repetida");
                i--;
            }            
        }
    }


}
