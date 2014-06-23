using UnityEngine;
using System.Collections;

public enum PlatformType
{
    FALL,
    MOVE,
}

public class Platform : MonoBehaviour {

	public PlatformType platformType;

    public float speed;
    public float timeInverse;
    public float timeFall;
    public float timeDestroy;      

    bool front = false;
    public bool colliderWithPlayer = false;
    public bool fall = false;

    public Transform pointA, pointB;
    public LayerMask platformLayer;

    public void Update()
    {
        colliderWithPlayer = Physics2D.OverlapArea(pointA.position, pointB.position, platformLayer);

        switch (platformType)
        {
            case PlatformType.MOVE:
                if (front)
                {
                    this.transform.Translate((Vector3.right * Time.deltaTime) * speed);
                }
                else
                {
                    this.transform.Translate((Vector3.left * Time.deltaTime) * speed);
                }
            break;
            case PlatformType.FALL:

                if (colliderWithPlayer) { Invoke("MoveDown", timeFall); }

                if (fall)
                {
                    GetComponent<BoxCollider2D>().enabled = false;
                    this.transform.Translate((Vector3.down * Time.deltaTime) * speed);
                    Invoke("DestroyPlatform", timeDestroy);
                }
            break;
        }
        
    }

    public void MoveDown() { fall = true; }

    public void DestroyPlatform()
    {
        Destroy(this.gameObject);
    }

    public void InverseDirection()
    {
        front = !front;
        Invoke("InverseDirection", timeInverse);
    }

}
