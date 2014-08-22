using UnityEngine;
using System.Collections;

public class Brigde : MonoBehaviour {

    public Transform[] stumps;

    public bool start = false;
    public bool inverse = false;

    private float delta = 0.05F;

	public void Initial () {
        Shake();
        Invoke("Fall", 1.2F);
	}
	
	void Update () {
        if(start){
            start = false;
            //CancelInvoke("Shake");
            //animation.Play();
        }

            
	}

    public void Fall()
    {
        CancelInvoke("Shake");
        animation.Play();
        Destroy(this.gameObject, 1F);
    }

    public void Inverse()
    {
        inverse = !inverse;
    }

    public void Shake()
    {
        for (int i = 0; i < stumps.Length; i++)
        {
            if (!inverse)
            {
                stumps[i].position = new Vector3(stumps[i].position.x, stumps[i].position.y - delta, stumps[i].position.z);
                delta += 0.01F;
            }
            else
            {
                stumps[i].position = new Vector3(stumps[i].position.x, stumps[i].position.y - delta, stumps[i].position.z);
                delta -= 0.01F;
            }

            if (Mathf.Abs(delta) > 0.05F)
            {
                inverse = !inverse;
                if (inverse)
                    delta -= 0.01F;
                else
                    delta += 0.01F;
            }  

        }
        Invoke("Shake", 0.05F);
    }
}
