using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed;
    public bool endGame;
    public float velocity = 7.5F;
    public int itens;
    public int points;

    public bool pauseActive;
    public GameObject pauseMenu, GUI;
    public Transform ragDoll;

    public Color[] colors;

    private float motion;
    public float Motion
    {
        get { return motion; }
        set { motion = Mathf.Clamp(value, -1, 1); }
    }

    AudioSource audio;

	void Start () {

        audio = GetComponent<AudioSource>();

        GetComponentInChildren<SkinnedMeshRenderer>().materials[5].color = colors[PlayerPrefs.GetInt("item_equipped_number")];
        GUI.SetActive(false);
        InvokeRepeating("SpeedUp", 10f, 10F);
	}
	
	void Update ()
    {      
        # region Pause

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("PAUSE");

            if (pauseActive)
            {
                pauseActive = false;
                Time.timeScale = 1;                
                var pauseGUI = GameObject.Find("Pause");
                pauseGUI.SetActive(false);

                //Application.LoadLevel("Menu");

                //print("meerrrrrdaaaa");

                //var pauseGUI = GameObject.Find("Pause");
                //pauseGUI.SetActive(false);
                //var pauseMenu = GameObject.Find("Game");
                //Time.timeScale = 1;
                //pauseActive = false;
                //pauseMenu.GetComponent<Pause>().pauseActive = false;


            }
            else if (!Application.loadedLevelName.Equals("Selection") && !pauseActive)
            {
                pauseActive = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }

            if (Application.loadedLevelName.Equals("Selection"))
            {
                Application.LoadLevel("Menu");
            }

            if (Application.loadedLevelName.Equals("Menu"))
            {
                // MenssageBox para confirmar a saida do jogo
                Application.Quit();
            }

            

        }
        #endregion


        if (!endGame)
        {
            points = (int)Time.timeSinceLevelLoad * (int)velocity;


            rigidbody.velocity = new Vector3(motion * speed, rigidbody.velocity.y, -velocity);

            if (motion != 0)
            {
                this.transform.rotation = Quaternion.Euler(new Vector3(0, 180 + (motion * -30), 0));
            }
            else
            {
                this.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }

            #if UNITY_EDITOR
            rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rigidbody.velocity.y, -velocity);

            if (Input.GetAxis("Horizontal") != 0)
            {
                this.transform.rotation =  Quaternion.Euler(new Vector3(0, 180 + (Input.GetAxis("Horizontal") *- 30), 0));
                //transform.rotation.SetEulerAngles(new Vector3(transform.rotation.x, transform.rotation.y + 30, transform.rotation.z));
            }
            else
            {
                this.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }

            #endif
        }
        else
        {
            GUI.SetActive(true);
        }
	}

    void SpeedUp()
    {
        if (velocity <= 35)
        {
            velocity += 2.5F;
        }
        else
        {
            CancelInvoke("SpeedUp");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tree" && !endGame)
        {
            print("PERDEU");
            CancelInvoke("SpeedUp");
            endGame = true;

            audio.Play();

            Instantiate(ragDoll, transform.position, transform.rotation);
            //Destroy(this.gameObject);
            GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
            this.rigidbody.velocity = new Vector3(0, 0, 0);
            this.rigidbody.isKinematic = true;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Tree" && !endGame)
        {
            print("PERDEU");
            CancelInvoke("SpeedUp");
            endGame = true;

            audio.Play();

            Instantiate(ragDoll, transform.position, transform.rotation);
            //Destroy(this.gameObject);
            GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
            this.rigidbody.velocity = new Vector3(0, 0, 0);
            this.rigidbody.isKinematic = true;

        }
    }

}
