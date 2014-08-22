using UnityEngine;
using System.Collections;

public enum Actions
{
    RHINHO,
    LAVA,
}

public class Action : MonoBehaviour {

    public Actions ActionState;
    public GameObject Target;
    
    // Acao do rhino
    public GameObject Bridge, Limited;
    GameObject Player;
    
    
    // Acao de Lava

    private bool moveBack = false, moveForward = false, shake = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            switch (ActionState) 
            {
                case Actions.RHINHO:
                    
                    this.collider2D.enabled = false;
                    Player = GameObject.Find("Player");

                    Player.GetComponent<Player>().Stop();
            
                    Player.GetComponent<Player>().controllable = false;
                    this.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
                    this.camera.enabled = true;
                    moveBack = true;

                    break;
                case Actions.LAVA:

                    this.collider2D.enabled = false;
                    Player = GameObject.Find("Player");
                    Player.GetComponent<Player>().Stop();
                    this.camera.enabled = true;
                    Player.GetComponent<Player>().controllable = false;
                    shake = true;
                    Invoke("MoveLava", 1.5F);

                    break;
            }
        }
    }

    void MoveLava()
    {
        shake = false;
        Player.GetComponent<Player>().controllable = true;        
        this.camera.enabled = false;
        Target.transform.position = new Vector3(Target.transform.position.x + 0.1F, Target.transform.position.y, Target.transform.position.z);
        Invoke("MoveLava", 0.0168F);
    }

	void Update () {
        if (moveBack){ 
            if(transform.position.x > 134)
            {
                this.transform.Translate(new Vector3(-0.15F, 0, 0));
            }
            else
            {
                moveBack = false;
                Invoke("MoveForward", 3F);
                Bridge.GetComponent<Brigde>().Initial();
            }
        }
        if (moveForward){
            if (transform.position.x < 168)
            {
                this.transform.Translate(new Vector3(+0.25F, 0, 0));                
            }
            else
            {
                Target.GetComponent<Rhino>().Preparing();
                moveForward = false;
                Invoke("EndAction", 2F);
            }

        }
        if (shake)
        {
            this.transform.position = new Vector3(this.transform.position.x + Random.Range(-0.2F, 0.2F), this.transform.position.y + Random.Range(-0.2F, 0.2F), this.transform.position.z);
        }
	}

    void MoveForward() 
    { 
        moveForward = true;
    }

    void EndAction()
    {
        Limited.SetActive(true);
        this.camera.enabled = false;
        Player.GetComponent<Player>().controllable = true;  
    }

}
